using UnityEngine;
using System.Collections;

public class EventCard : ScriptableObject 
{
    //TODO add resolution text and time for text to show.
    protected int[] choices;
    public int[] Choices { get { return choices; } }

    protected string flavorText;
    public string FlavorText { get { return flavorText; } }

    protected string[] choiceText;
    public string[] ChoiceText { get { return choiceText; } }

    protected Sprite card;
    public Sprite Card { get { return card; } }

    protected int randomValue;
    //TODO send type of ship to here.
    public EventCard()
    {
        //TODO rewrite to work with all players.

    }

    protected void trade()
    {
        Trade.Trading = true;
        //TODO add means of turning trade off.
    }

    public virtual void Resolve(int selection)
    {
        switch (selection)
        {
            case 0:
                Debug.Log("player loses crew.");
                break;
            case 1:
                Debug.Log("Player loses a turn.");
                break;
            case 2:
                Combat.InCombat = true;
                break;
            default:
                Debug.Log("i sends the wrong number.");
                break;
        }
    }

    //TODO implement methods for rewards.
}
