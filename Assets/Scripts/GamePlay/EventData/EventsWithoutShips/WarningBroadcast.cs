using UnityEngine;
using System.Collections;

public class WarningBroadcast : EventCard 
{
    public WarningBroadcast()
    {
        flavorText = "You overhear a broadcast warning of hostile ships.";
        
        choices = new int[1] {1 };
        
        choiceText = new string[1] { "Take an extra turn."};
        
        card = Resources.Load<Sprite>("ActiveDrone");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO implement multi turn script.
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
