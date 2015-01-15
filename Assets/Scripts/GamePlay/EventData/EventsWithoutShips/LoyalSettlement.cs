using UnityEngine;
using System.Collections;

public class LoyalSettlement : EventCard
{
    public LoyalSettlement()
    {
        flavorText = "A loyal settlement offers equipment\n to aid your mission.";
        
        choices = new int[1] {1};
        
        choiceText = new string[1] { "Graciously accept the equipment"};
        
        card = Resources.Load<Sprite>("LoyalSettlement");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                //TODO implement reward
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
