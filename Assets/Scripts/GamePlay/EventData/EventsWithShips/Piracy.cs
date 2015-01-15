using UnityEngine;
using System.Collections;

public class Piracy : EventShip {

    public Piracy()
    {
        flavorText = "These pirates want your cargo.\n Will you hand over a module?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Give them a module.", "Refuse to give in."};
        
        //TODO Need to implement drone ships for this.
        ship = ScriptableObject.CreateInstance<Pirate>();
        
        card = Resources.Load<Sprite>("Piracy");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                if (Random.Range(0, 6) < 2) 
                {
                    activateCombat();
                }
                //TODO implement randome mod lost without combat
                
                break;
            case 1:
                activateCombat();
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
    
    private bool flee()
    {
        if (Random.Range(0, 6) > 3)
        {
            return true;
        }
        else
            return false;
    }
}
