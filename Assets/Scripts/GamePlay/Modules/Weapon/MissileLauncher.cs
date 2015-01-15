using UnityEngine;
using System.Collections;

public class MissileLauncher : WeaponModule, IWeaponModule, IObserver
{
    private int ammo;
    //TODO Do after movement
    public int Ammo { 
        get { return ammo; } 
        set 
        { 
            if (ammo < ammoCapacity) 
            {
                ammo++;
            }
             
        } 
    }

    private int ammoCapacity;

    private int ammoCapacityFirstTimeThrough = 0;
    private bool upgradeAmmoCap;

    public MissileLauncher()
    {
        currentQuality = Quality.LOW;
        damage = 2;
        powerRatingCost = 3;

        //TODO check if ammoCapaicty is being applied too late.
        ammo = ammoCapacity;
        upgradeAmmoCap = true;

        moduleName = "Missile Launcher";

        weaponSprite = Resources.Load<Texture>("MissileLauncher");
    }

    public override void ObserverUpdate(object sender, object message)
    {
        //check if sender is ship, and if sender is ship make sure
        //ApplyDamage goes towards ship's shields.
        if (message is Ship && sender is Ship)
        {
            ammoCount((ShipType) message);
        }

        if (sender is Ship && message is ShipType)
        {
            ammoCount((ShipType) message);
        }
    }

    private void ammoCount(ShipType currentShipType)
    {

        switch (currentShipType)
        {
            case ShipType.SCOUT:
                ammoCapacity = 3;
                break;
            case ShipType.INTERCEPTOR:
                ammoCapacity = 4;
                break;
            case ShipType.DEFENDER:
                ammoCapacity = 3;
                break;
            case ShipType.BLACKMARKETTRADER:
                ammoCapacity = 3;
                break;
            case ShipType.BLACKSTAR:
                ammoCapacity = 4;
                break;
            case ShipType.DRONE:
                ammoCapacity = 0;
                break;
            case ShipType.MILITARYSHIP:
                ammoCapacity = 3;
                break;
            case ShipType.PIRATE:
                ammoCapacity = 0;
                break;
            case ShipType.SLAVER:
                ammoCapacity = 5;
                break;
            default:
                Debug.Log("Ship types are not being sent.");
                break;
        }

        upgradeAmmoCapacity();

        if (Combat.InCombat)
        {
            ammo--;
        }
        else if(upgradeAmmoCap) //TODO Add check for upgrade screen not refilling ammo.
        {

            upgradeAmmoCap = false;
        }    
        Debug.Log("ammo = " + ammo);
    }

    private void upgradeAmmoCapacity()
    {
        if (ammoCapacityFirstTimeThrough == 0)
        {
            ammoCapacityFirstTimeThrough = ammoCapacity;
        }
        if (true)
        {
            ammoCapacity = ammoCapacityFirstTimeThrough;
            //ammoCapacityFirstTimeThrough++;
            //TODO add Upgrade ammoCapacity logic here.
            //MaxammoCapacity
        }
    }
    public override void ChanceToHit()
    {

        if (ammo > 0)
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
        Debug.Log("Ammo = " + ammo);
    }
    
    public override void ApplyDamage(int damageSent)
    {
        shipEngaged.Hull -= damageSent;
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
                damage = 2;
                break;
            case Quality.NORMAL:
                damage = 4;
                break;
            case Quality.HIGH:
                damage = 6;
                break;
            default:
                Debug.Log("Module Quality isn't being set.");
                break;
        }
    }
}
