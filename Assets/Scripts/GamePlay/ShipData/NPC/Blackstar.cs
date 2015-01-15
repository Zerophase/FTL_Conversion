using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Blackstar : Ship, IShip 
{
    public Blackstar()
    {
        crew = maxCrew = 4;
        maneuverability = maxManeuverability = 6;
        powerRating = maxPowerRating = 6;
        shields = maxShields = 5;
        hull = maxhull = 5;
        
        shipName = "Blackstar";

        currentShipType = ShipType.BLACKSTAR;

        shipSprite = Resources.Load<Sprite>("BlackStar");
        
        weaponModules.Add(LaserCannon.CreateInstance<LaserCannon>());
        weaponModules.Add(MissileLauncher.CreateInstance<MissileLauncher>());
        for (int i = 0; i < WeaponModules.Count; i++)
        {
            this.Attach(weaponModules.ElementAt<WeaponModule>(i));
        }

        Notify();
    }

    protected void equipSupportModule(ISupportModule addMSupportodule)
    {
        foreach (ISupportModule sModule in supportModules)
        {
            if (sModule == null) 
            {
                supportModules.Find(sm => sm is AncientAlienDevice).ApplyBonus(this);
            }
        }
    }
}
