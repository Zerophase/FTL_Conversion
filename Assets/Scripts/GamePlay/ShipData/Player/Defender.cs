using UnityEngine;
using System.Collections;

public class Defender : Ship, IShip 
{
    public Defender()
    {
        maneuverability = 4;
        powerRating = 7;
        shields = 7;
        hull = 7;
        crew = 5;

        currentShipType = ShipType.DEFENDER;

        shipName = "Defender";

        shipSprite = Resources.Load<Sprite>("defender");

        weaponModules.Add(BurstCannon.CreateInstance<BurstCannon>());
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
