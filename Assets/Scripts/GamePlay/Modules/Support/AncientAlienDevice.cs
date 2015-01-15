using UnityEngine;
using System.Collections;

public class AncientAlienDevice : SupportModule, ISupportModule
{
    public AncientAlienDevice()
    {
        moduleName = "Ancient Alien Device";
        bonus = 1;

        weaponSprite = Resources.Load<Texture>("AncientAlienDevice");
    }

    public override void ApplyBonus(IShip ship)
    {
        if (addBonus)
        {
            ship.Maneuverability += bonus;
            ship.PowerRating += bonus;
            ship.Shields += bonus;
            ship.Hull += bonus;
            ship.Crew += bonus;

            addBonus = false;
        }
    }

    public override void RemoveBonus (IShip ship)
    {
        removeBonus = true;

        if (removeBonus)
        {
            ship.Maneuverability -= bonus;
            ship.PowerRating -= bonus;
            ship.Shields -= bonus;
            ship.Hull -= bonus;
            ship.Crew -= bonus; 
        }

        removeBonus = false;
    }
}
