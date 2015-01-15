using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Slaver : Ship, IShip 
{

    public Slaver()
    {
        crew = maxCrew = 4;
        maneuverability = maxManeuverability = 2;
        powerRating = maxPowerRating = 7;
        shields = maxShields = 7;
        hull = maxhull = 6;
        
        currentShipType = ShipType.SLAVER;
        
        shipName = "Slaver";
        
        shipSprite = Resources.Load<Sprite>("Slaver");
        
        weaponModules.Add(LaserCannon.CreateInstance<LaserCannon>());
        weaponModules.Add(MissileLauncher.CreateInstance<MissileLauncher>());
        this.Attach(weaponModules.ElementAt<WeaponModule>(0));
        Notify();
    }
}
