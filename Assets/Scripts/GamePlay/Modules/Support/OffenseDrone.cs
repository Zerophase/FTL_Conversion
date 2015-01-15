using UnityEngine;
using System.Collections;

public class OffenseDrone : SupportModule, ISupportModule 
{
    public OffenseDrone()
    {
        moduleName = "Offense Drone";
        bonus = 1;
        currentQuality = Quality.LOW;

        weaponSprite = Resources.Load<Texture>("OffenseDrone");
    }
    
    public override void ApplyBonus(IShip ship)
    {
        if (addBonus)
        {
            checkQuality(currentQuality);
            //Need to implement weapons first
            //and add bonus to damage.
            
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
            //Need to implement Weapons and add bonus to damage.
        }
        
        removeBonus = false;
    }
}
