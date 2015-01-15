using UnityEngine;
using System.Collections;

public class SupplyCache : EventCard {

    public SupplyCache()
    {
        flavorText = "A sturdy cache appears.\n Do you force it open?";
        
        choices = new int[2] { 1, 2};
        
        choiceText = new string[2] {"Leave it floating in space.", "Use missiles to blast the contents out."};
        
        card = Resources.Load<Sprite>("SupplyCache");
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
