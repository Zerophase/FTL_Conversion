using UnityEngine;
using System.Collections;

public class AncientAlienTech : EventCard 
{
    public AncientAlienTech()
    {
        flavorText = "You find unknown alien technology in space. Will you risk bringing it aboard?";

        choices = new int[2] { 1, 2};

        choiceText = new string[2] {"Leave it floating in space.", "Bring it aboard for inspection."};
        
        card = Resources.Load<Sprite>("AncientAlienTech");
    }

    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                break;
            case 1:
                //TODO EXP and threat.
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
