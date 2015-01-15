using UnityEngine;
using System.Collections;

public class Deserters : EventShip 
{
    public Deserters()
    {
        flavorText = "You encounter a group of deserters.\n What will you do?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Offer supplies.", "Make them pay for treason."};
        
        ship = ScriptableObject.CreateInstance<Defender>();
        
        card = Resources.Load<Sprite>("Deserters");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }

    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                break;
            case 1:
                activateCombat();
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
