using UnityEngine;
using System.Collections;

public class AmicableSlaver : EventShip 
{
    public AmicableSlaver()
    {
        flavorText = "He has no room to add your crew to his cargo.\nWill you make him pay for his crimes?";

        choices = new int[2] { 1, 2 };

        choiceText = new string[2] { "Make him pay for his crimes.", "Leave before he changes his mind." };

        ship = ScriptableObject.CreateInstance<Slaver>();

        card = Resources.Load<Sprite>("AmicableSlaver");
        //TODO implement Slaver
        //ship = 
    }

    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                activateCombat();
                break;
            case 1:

                Debug.Log("You flee.");
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
