using UnityEngine;
using System.Collections;

public class RogueWeapon : EventShip 
{
    public RogueWeapon()
    {
        flavorText = "A functional weapon just floats by.\nWithout any questions you take it aboard.";
        
        choices = new int[1] {1};
        
        choiceText = new string[1] { "Take it aboard."};
        
        card = Resources.Load<Sprite>("RogueWeapon");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO implent free weapon.
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
