using UnityEngine;
using System.Collections;

public class ScrapeNeutralMilitaryVessel : EventShip
{
    public ScrapeNeutralMilitaryVessel()
    {
        flavorText = "They insult your flying, after you hit them.\nWill you make them pay?";
        
        choices = new int[2] {1, 2};
        
        choiceText = new string[2] { "Make them pay for their insolence.", "Ignore them."};
        
        //TODO Need to implement drone ships for this.
        ship = ScriptableObject.CreateInstance<MilitaryShip>();
        
        card = Resources.Load<Sprite>("ScrapeNeutralMilitaryShip");
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
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
