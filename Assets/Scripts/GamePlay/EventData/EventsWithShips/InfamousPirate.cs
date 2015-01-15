using UnityEngine;
using System.Collections;

public class InfamousPirate : EventShip
{
    public InfamousPirate()
    {
        flavorText = "The infamous pirate Blackstar desires\n a telepahtic duel with\n one of your crew.";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Accept.", "Decline."};

        ship = ScriptableObject.CreateInstance<Blackstar>();

        card = Resources.Load<Sprite>("InfamousPirate");
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
