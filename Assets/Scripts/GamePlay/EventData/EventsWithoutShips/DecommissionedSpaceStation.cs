using UnityEngine;
using System.Collections;

public class DecommissionedSpaceStation : EventCard 
{
    public DecommissionedSpaceStation()
    {
        flavorText = "This place looks like no one has\n been here for years.\nWill you salvage equipment?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "We could use the supplies.", "Too risky."};
        
        card = Resources.Load<Sprite>("DecommissionedSpaceStation");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                break;
            case 1:
                //TODO implement rewards
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
