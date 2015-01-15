using UnityEngine;
using System.Collections;

public class AlienExplorers : EventShip 
{
    public AlienExplorers()
        :base()
    {
        flavorText = "A new species wants to make contact.\nWill you wpeak with them?";

        choices = new int[2] {1, 2 };

        choiceText = new string[2] { "Avoid contact.", "Make contact."};


        card = Resources.Load<Sprite>("AlienExplorers");
        ship = ScriptableObject.CreateInstance<Scout>();
    }

    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                Debug.Log("You avoid contact.");
                break;
            case 1:
                repairHull();
                Debug.Log("need to implement repair method");
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }

    //TODO implement Repair
    //Restores 50 /50 chance of restoring full player hull.
    //find player ship with object sender.
    //if ancient alien devvice give player +2xp and repair full hull
    private void repairHull()
    {
        if (true)
        {
            randomValue = Random.Range(0,6);
            if (randomValue > 3)
            {
                //playerShip.playerShip.Hull = playerShip.playerShip.MaxHull;
            }
            else
                activateCombat();
        }
        else
        {}   //TODO if ancient alien device is owned +2xp and full hull repair.
           
    }
}
