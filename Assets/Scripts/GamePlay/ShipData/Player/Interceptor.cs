using UnityEngine;
using System.Collections;

public class Interceptor : Ship, IShip 
{
    public Interceptor()
    {
        maneuverability = 7;
        powerRating = 10;
        shields = 4;
        hull = 6;
        crew = 3;

        currentShipType = ShipType.INTERCEPTOR;

        shipName = "Interceptor";

        shipSprite = Resources.Load<Sprite>("Interceptor");

        weaponModules.Add(BurstCannon.CreateInstance<BurstCannon>());
        weaponModules.Add(LaserCannon.CreateInstance<LaserCannon>());
    }
	
    //Need to test. Might need to be rewritten a bit.
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
