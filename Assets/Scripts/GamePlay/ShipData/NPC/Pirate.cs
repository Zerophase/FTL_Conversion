using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Pirate : Ship, IShip 
{
    public Pirate()
    {
        crew = maxCrew = 3;
        maneuverability = maxManeuverability = 5;
        powerRating = maxPowerRating = 4;
        shields = maxShields = 4;
        hull = maxhull = 3;
        
        currentShipType = ShipType.PIRATE; 
        
        shipName = "Pirate";
        
        shipSprite = Resources.Load<Sprite>("Pirate");
        
        weaponModules.Add(BurstCannon.CreateInstance<BurstCannon>());
        for (int i = 0; i < WeaponModules.Count; i++)
        {
            this.Attach(weaponModules.ElementAt<WeaponModule>(i));
        }
        
        Notify();
    }
}
