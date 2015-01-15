using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Drone : Ship, IShip
{
    public Drone()
    {
        maneuverability = maxManeuverability = 6;
        powerRating = maxPowerRating = 7;
        shields = maxShields = 3;
        hull = maxhull = 4;
        crew = maxCrew = 0;

        shipName = "Drone";
        
        currentShipType = ShipType.DRONE;
        
        shipSprite = Resources.Load<Sprite>("Drone");
        
        weaponModules.Add(BurstCannon.CreateInstance<BurstCannon>());
        for (int i = 0; i < WeaponModules.Count; i++)
        {
            this.Attach(weaponModules.ElementAt<WeaponModule>(i));
        }
        
        Notify();
    }
}
