using UnityEngine;
using System.Collections;

public class MiningColony : EventCard 
{
    public MiningColony()
    {
        flavorText = "The miners here have been trapped by a cave in.\nWill you offer aid?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Yes.", "No."};
        
        card = Resources.Load<Sprite>("MiningColony");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                break;
            case 1:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
