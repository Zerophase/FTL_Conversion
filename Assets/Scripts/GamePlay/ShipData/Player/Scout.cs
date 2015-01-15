using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Scout : Ship, IShip 
{
    public Scout()
    {
        crew = maxCrew = 2;
        maneuverability = maxManeuverability = 10;
        powerRating = maxPowerRating = 10;
        shields = maxShields = 4;
        hull = maxhull = 4;

        currentShipType = ShipType.SCOUT;

        shipName = "Scout";

        shipSprite = Resources.Load<Sprite>("Scout");

        weaponModules.Add(LaserCannon.CreateInstance<LaserCannon>());
        for (int i = 0; i < WeaponModules.Count; i++)
        {
            this.Attach(weaponModules.ElementAt<WeaponModule>(i));
        }
        Notify();
    }

    //Need to test. Might need to be rewritten a bit.
    //TODO Rewrite so it takes a SupportModule
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
