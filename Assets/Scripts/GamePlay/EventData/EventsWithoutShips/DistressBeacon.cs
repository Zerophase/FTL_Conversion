using UnityEngine;
using System.Collections;

public class DistressBeacon : EventCard
{
    public DistressBeacon()
    {
        flavorText = "You find a castaway near a distress beacon\nWill you save him?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Take him aboard", "Leave him."};
        
        card = Resources.Load<Sprite>("DistressBeacon");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                break;
            case 1:
                //TODO implement reward and penalty.
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }

}
