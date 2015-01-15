using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MilitaryShip : Ship, IShip 
{
    public MilitaryShip()
    {
        crew = maxCrew = 3;
        maneuverability = maxManeuverability = 5;
        powerRating = maxPowerRating = 4;
        shields = maxShields = 6;
        hull = maxhull = 7;
        
        currentShipType = ShipType.MILITARYSHIP; 
        
        shipName = "Military Ship";
        
        shipSprite = Resources.Load<Sprite>("MilitaryShip");
        
        weaponModules.Add(BurstCannon.CreateInstance<BurstCannon>());
        weaponModules.Add(MissileLauncher.CreateInstance<MissileLauncher>());
        for (int i = 0; i < WeaponModules.Count; i++)
        {
            this.Attach(weaponModules.ElementAt<WeaponModule>(i));
        }
        
        Notify();
    }
}
