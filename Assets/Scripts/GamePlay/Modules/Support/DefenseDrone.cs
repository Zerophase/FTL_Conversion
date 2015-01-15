using UnityEngine;
using System.Collections;

public class DefenseDrone : SupportModule, ISupportModule 
{
    //Need to make sure stats can change on quality level change
    //consider changing stats on set of public Quality property.
	public DefenseDrone()
    {
        moduleName = "Defense Drone";
        bonus = 1;
        currentQuality = Quality.LOW;

        weaponSprite = Resources.Load<Texture>("DefenseDrone");
    }

    public override void ApplyBonus(IShip ship)
    {
        if (addBonus)
        {
            checkQuality(currentQuality);
            ship.Hull += bonus;
            
            addBonus = false;
        }
    }

    private void checkQuality(Quality qualityLevel)
    {
        switch (qualityLevel)
        {
            case Quality.LOW:
                bonus = 1;
                break;
            case Quality.NORMAL:
                bonus = 2;
                break;
            case Quality.HIGH:
                bonus = 3;
                break;
            default:
                Debug.Log("Module Quality isn't being set.");
                break;
        }
    }

    public override void RemoveBonus (IShip ship)
    {
        removeBonus = true;
        addBonus = true;

        if (removeBonus)
        {
            ship.Hull -= bonus;
        }
        
        removeBonus = false;
    }
}
