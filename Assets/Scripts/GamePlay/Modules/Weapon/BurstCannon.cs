using UnityEngine;
using System.Collections;

public class BurstCannon : WeaponModule, IObserver 
{
    BurstCannon()
    {
        currentQuality = Quality.LOW;
        damage = 2;
        powerRatingCost = 2;
        
        moduleName = "Burst Cannon";

        weaponSprite = Resources.Load<Texture>("BurstCannon");
    }

    public override void ChanceToHit()
    {
        rollForHit = Random.Range(0, 6);
        
        switch (rollForHit)
        {
            case 0:
            case 1:
            case 2:
                damageDealt = 0;
                break;
            case 3:
            case 4:
                damageDealt = damage;
                break;
            case 5:
                damageDealt = (damage * 2);
                break;
            default:
                Debug.Log("Random.Range isn't being applied.");
                break;
        }
        
        ApplyDamage(damageDealt);
    }



    public override void ApplyDamage(int damageSent)
    {
        //TODO Test if damage bleeds through shields.
        if (shipEngaged.ShieldsAreUp)
            shipEngaged.Shields -= damageSent;
        //Might need to make shieldsAreUp flip off here.
        else
            shipEngaged.Hull -= damageSent;
    }

    public override void ObserverUpdate(object sender, object message)
    {
        //check if sender is ship, and if sender is ship make sure
        //ApplyDamage goes towards ship's shields.
        if (message is bool && sender is Ship)
        {
            shieldsAreup = true;
            //Ship.
        }
    }

    public void ChangeDamae()
    {
        if (qualityHasChanged)
        {
            checkQuality(currentQuality);
            
            qualityHasChanged = false;
        }
    }
    
    private void checkQuality(Quality qualityLevel)
    {
        switch (qualityLevel)
        {
            case Quality.LOW:
                damage = 1;
                break;
            case Quality.NORMAL:
                damage = 2;
                break;
            case Quality.HIGH:
                damage = 3;
                break;
            default:
                Debug.Log("Module Quality isn't being set.");
                break;
        }
    }
}
