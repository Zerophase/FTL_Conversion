using UnityEngine;
using System.Collections;

public class BlackMarketWeapons : EventShip 
{
    public BlackMarketWeapons()
    {
        flavorText = "This weapon trafficker wants to trade.\n Will you associate with him?";
        
        choices = new int[3] {1, 2, 3};
        
        choiceText = new string[3] { "Purchase some cheap high quality goods.", "He must be punished.", "I want nothing to do with you."};
        
        ship = ScriptableObject.CreateInstance<BlackMarketTrader>();
        
        card = Resources.Load<Sprite>("BlackMarketWeapons");
        //ship.ShipSprite = Resources.Load<Sprite>("Drone");
    }
    
    public override void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                trade();//TODO implement prices for Black Market Weapons
                break;
            case 1:
                activateCombat();
                break;
            case 2:
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }
}
