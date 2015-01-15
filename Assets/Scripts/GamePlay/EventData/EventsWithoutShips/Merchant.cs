using UnityEngine;
using System.Collections;

public class Merchant : EventCard 
{
    public Merchant()
    {
        flavorText = "A merchant flies by.\n Are you interested in his wares?.";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Yes.", "No."};
        
        card = Resources.Load<Sprite>("Merchant");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                trade();
                break;
            case 1:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
