using UnityEngine;
using System.Collections;

public class DeactivatedDrone : EventShip
{
    public DeactivatedDrone()
    {
        flavorText = "A deactivated drone floats by.\nWill you risk activating it?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Take it's precious materials.", "It's too risky."};
        
        ship = ScriptableObject.CreateInstance<Drone>();
        
        card = Resources.Load<Sprite>("DeactivatedDrone");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                if (Random.Range(0, 6) < 3) {
                    activateCombat();
                }//TODO implement rewards for combat and out of combat.
                break;
            case 1:

                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
