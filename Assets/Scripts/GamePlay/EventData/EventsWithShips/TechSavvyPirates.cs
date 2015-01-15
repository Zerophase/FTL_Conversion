using UnityEngine;
using System.Collections;

public class TechSavvyPirates : EventShip {

    public TechSavvyPirates()
    {
        flavorText = "Pirates have hacked your shields and navigation";
        
        choices = new int[1] {1 };
        
        choiceText = new string[1] { "Engage the pirates." };
        
        //TODO Need to implement drone ships for this.
        ship = ScriptableObject.CreateInstance<Pirate>();
        
        card = Resources.Load<Sprite>("TechSavvyPirates");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                activateCombat();
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
