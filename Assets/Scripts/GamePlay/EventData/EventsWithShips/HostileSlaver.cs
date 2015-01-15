using UnityEngine;
using System.Collections;

public class HostileSlaver : EventShip
{
    public HostileSlaver()
    {
        flavorText = "This slaver wants one of your crew.\nWill you hand him over?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Yes.", "No."};

        ship = ScriptableObject.CreateInstance<Slaver>();

        card = Resources.Load<Sprite>("HostileSlaver");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                activateCombat();
                break;
            case 1:
                //TODO implement loss of crew.
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
