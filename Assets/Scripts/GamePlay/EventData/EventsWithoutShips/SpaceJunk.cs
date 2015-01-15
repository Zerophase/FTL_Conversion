using UnityEngine;
using System.Collections;

public class SpaceJunk : EventCard 
{
    public SpaceJunk()
    {
        flavorText = "Space junk slows your navigation.";
        
        choices = new int[1] {1};
        
        choiceText = new string[1] { "Try to get through the junk."};
        
        card = Resources.Load<Sprite>("SpaceJunk");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO implent movement impairment
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
