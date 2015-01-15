using UnityEngine;
using System.Collections;

public class EscapePod : EventCard
{
    public EscapePod()
    {
        flavorText = "You bring an escape pod aboard\nyour ship. Will you open it?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Yes.", "No."};
        
        card = Resources.Load<Sprite>("EscapePod");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO implement reward and danger
                break;
            case 1:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
