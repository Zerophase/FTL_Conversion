using UnityEngine;
using System.Collections;

public class LoneScout : EventShip 
{
    public LoneScout()
    {
        flavorText = "You warp in on a lone scout, before he detects you.\nWill you risk combat?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Attack him.", "Don't take the risk."};

        ship = ScriptableObject.CreateInstance<Scout>();

        card = Resources.Load<Sprite>("LoneScout");
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
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
