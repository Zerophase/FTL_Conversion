using UnityEngine;
using System.Collections;

public class AlienTrader : EventShip
{

    public AlienTrader()
    {
        flavorText = "The alien wants to trade. Will you trade?";
        
        choices = new int[2] {1, 2 };
        
        choiceText = new string[2] { "Make a trade.", "Refuse to trade."};
        
        ship = ScriptableObject.CreateInstance<Scout>();
        card = Resources.Load<Sprite>("AlienTrader");
    }

    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                trade();
                break;
            case 1:
                Debug.Log("You refuse to trade.");
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }

    //Have this call the trade script,
    //which brings up a list of modules at the same
    //quality level as the current system.
    //Also needs exp script.
}
