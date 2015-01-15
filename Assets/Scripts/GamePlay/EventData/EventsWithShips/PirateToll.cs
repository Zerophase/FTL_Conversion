using UnityEngine;
using System.Collections;

public class PirateToll : EventShip 
{
    public PirateToll()
    {
        flavorText = "A pirate ship demands you pay their toll.\nWill you?";
        
        choices = new int[3] {1, 2, 3};
        
        choiceText = new string[3] { "Pay the toll.", "Teach the pirates a lesson.", "Attempt to escape."};
        
        //TODO Need to implement drone ships for this.
        ship = ScriptableObject.CreateInstance<Pirate>();
        
        card = Resources.Load<Sprite>("PirateToll");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:

                   //TODO implement toll of -2xp

                break;
            case 1:
                activateCombat();
                break;
            case 2:
                if (Random.Range(0, 6) > 2) 
                {
                    activateCombat();
                }
                //TODO implement escape
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
