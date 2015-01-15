using UnityEngine;
using System.Collections;

public class ShipGraveyard : EventShip 
{
    public ShipGraveyard()
    {
        flavorText = "Valuable cargo scatters the surroundings\n you decide to salvage.";
        
        choices = new int[1] {1};
        
        choiceText = new string[1] { "Begin salvaging." };
        
        //TODO Need to implement drone ships for this.
        ship = ScriptableObject.CreateInstance<Pirate>();
        
        card = Resources.Load<Sprite>("ActiveDrone");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                if (Random.Range(0, 6) < 3) 
                {
                    activateCombat();
                }

                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
