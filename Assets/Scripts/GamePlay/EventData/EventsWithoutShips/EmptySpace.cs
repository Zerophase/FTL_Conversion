using UnityEngine;
using System.Collections;

public class EmptySpace : EventCard
{
    public EmptySpace()
    {
        flavorText = "You find your self floating in empty space.";
        
        choices = new int[1] {1 };
        
        choiceText = new string[1] { "You float peacefully."};
        
        card = Resources.Load<Sprite>("EmptySpace");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
