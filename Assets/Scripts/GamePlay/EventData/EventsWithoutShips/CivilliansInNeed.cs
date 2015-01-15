using UnityEngine;
using System.Collections;

public class CivilliansInNeed : EventCard
{
    public CivilliansInNeed()
    {
        flavorText = "A military ship needs aid saving the crew\n of a damaged civilian ship.";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Help save them with your drone.", "Can't risk resources."};
        
        card = Resources.Load<Sprite>("CivilliansInNeed");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO implement reward and penalty.
                break;
            case 1:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
