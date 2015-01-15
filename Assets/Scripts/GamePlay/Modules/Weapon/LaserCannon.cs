using UnityEngine;
using System.Collections;

public class LaserCannon : WeaponModule, IWeaponModule, IObserver
{


    public LaserCannon()
    {
        currentQuality = Quality.LOW;
        damage = 1;
        powerRatingCost = 2;

        moduleName = "Laser Cannon";

        weaponSprite = Resources.Load<Texture>("LaserCannon");
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
            case 5:
                damageDealt = damage;
                break;
            default:
                Debug.Log("Random.Range isn't being applied.");
                break;
        }
        
         ApplyDamage(damageDealt);
    }

    public override void ApplyDamage(int damageSent)
    {
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
                damage = 3;
                break;
            case Quality.HIGH:
                damage = 5;
                break;
            default:
                Debug.Log("Module Quality isn't being set.");
                break;
        }
    }
}
