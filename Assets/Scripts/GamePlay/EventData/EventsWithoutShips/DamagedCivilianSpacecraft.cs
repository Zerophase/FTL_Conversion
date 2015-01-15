using UnityEngine;
using System.Collections;

public class DamagedCivilianSpacecraft : EventCard
{
    public DamagedCivilianSpacecraft()
    {
        flavorText = "You come upon a badly damaged\n civilian spacecraft, in need of repairs.\nWill you help?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Repair them.", "Leave them."};
        
        card = Resources.Load<Sprite>("DamagedCivilian");
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
