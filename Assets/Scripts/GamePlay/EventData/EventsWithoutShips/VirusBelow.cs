using UnityEngine;
using System.Collections;

public class VirusBelow : EventShip 
{
    public VirusBelow()
    {
        flavorText = "A deadly virus has broken out below.\n Do you risk neutralizing the virus?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Neutralize the virus.", "It's too dangerous."};
        
        card = Resources.Load<Sprite>("VirusBelow");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO rewards and danger for this quest.
                break;
            case 1:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
