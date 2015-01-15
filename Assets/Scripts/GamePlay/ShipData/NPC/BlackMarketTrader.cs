using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BlackMarketTrader : Ship, IShip 
{
    public BlackMarketTrader()
    {
        crew = maxCrew = 1;
        maneuverability = maxManeuverability = 2;
        powerRating = maxPowerRating = 5;
        shields = maxShields = 7;
        hull = maxhull = 5;

        currentShipType = ShipType.BLACKMARKETTRADER; 

        shipName = "Black Market Trader";
        
        shipSprite = Resources.Load<Sprite>("BlackMarketWeapon");
        
        weaponModules.Add(BurstCannon.CreateInstance<BurstCannon>());
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
