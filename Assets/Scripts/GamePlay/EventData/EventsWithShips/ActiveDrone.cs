using UnityEngine;
using System.Collections;

public class ActiveDrone : EventShip 
{
    public ActiveDrone()
    {
        flavorText = "An active drone appears";

        choices = new int[2] {1, 2};

        choiceText = new string[2] { "Fight Drone.", "Attempt to flee."};

        //TODO Need to implement drone ships for this.
        ship = ScriptableObject.CreateInstance<Drone>();

        card = Resources.Load<Sprite>("ActiveDrone");
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
                Combat.InCombat = flee();
                if (Combat.InCombat) {
                    activateCombat();
                }
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
