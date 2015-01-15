using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventDraw : MonoBehaviour {

    int card;
    int maxCards = 61;
    private int innerController = 0;

    float x;
    float y;

    Rect choicePosition;

    private bool selectingChoice = false;
    public bool SelectingChoice { get { return selectingChoice; } set { selectingChoice = value; } }
    bool GUIChoice = false;

    //TODO rewrite for different amounts of players.
    public static Player playerShip1;
    public static Player playerShip2;
    public static Player playerShip3;
    public static Player playership4;

    EventCard testCard;

    EventCard currentCard;

    Dictionary<int, EventCard> cards = new Dictionary<int, EventCard>();
	// Use this for initialization
	void Start () 
    {
        //Place testcard and cases in here.
	    for (int i = 0; i < maxCards; i++) 
        {
            switch (i) 
            {
                case 0:
                    testCard = ScriptableObject.CreateInstance<Deserters>();
                    break;
                case 1:
                    testCard = ScriptableObject.CreateInstance<DecommissionedSpaceStation>();
                    break;
                case 2:
                    testCard = ScriptableObject.CreateInstance<AlienTrader>();
                    break;
                case 3:
                    testCard = ScriptableObject.CreateInstance<ShipGraveyard>();
                    break;
                case 4:
                    testCard = ScriptableObject.CreateInstance<SpaceJunk>();
                    break;
                case 5:
                case 6:
                    testCard = ScriptableObject.CreateInstance<HostileSlaver>();
                    break;
                case 7:
                case 8:
                    testCard = ScriptableObject.CreateInstance<CivilliansInNeed>();
                    break;
                case 9:
                case 10:
                    testCard = ScriptableObject.CreateInstance<LoyalSettlement>();
                    break;
                case 11:
                    testCard = ScriptableObject.CreateInstance<BlackMarketWeapons>();
                    break;
                case 12:
                    testCard = ScriptableObject.CreateInstance<InfamousPirate>();
                    break;
                case 13:
                    testCard = ScriptableObject.CreateInstance<BlackMarketWeapons>();
                    break;
                case 14:
                case 15:
                    testCard = ScriptableObject.CreateInstance<WarningBroadcast>();
                    break;
                case 16:
                    testCard = ScriptableObject.CreateInstance<TechSavvyPirates>();
                    break;
                case 17:
                case 18:
                    testCard = ScriptableObject.CreateInstance<AmicableSlaver>();
                    break;
                case 19:
                case 20:
                    testCard = ScriptableObject.CreateInstance<ScrapeNeutralMilitaryVessel>();
                    break;
                case 21:
                    testCard = ScriptableObject.CreateInstance<AlienExplorers>();
                    break;
                case 22:
                case 23:
                    testCard = ScriptableObject.CreateInstance<MiningColony>();
                    break;
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    testCard = ScriptableObject.CreateInstance<EmptySpace>();
                    break;
                case 30:
                case 31:
                    testCard = ScriptableObject.CreateInstance<Piracy>();
                    break;
                case 32:
                    testCard = ScriptableObject.CreateInstance<RogueWeapon>();
                    break;
                case 33:
                case 34:
                    testCard = ScriptableObject.CreateInstance<EscapePod>();
                    break;
                case 35:
                    testCard = ScriptableObject.CreateInstance<VirusBelow>();
                    break;
                case 36:
                case 37:
                    testCard = ScriptableObject.CreateInstance<PirateToll>();
                    break;
                case 38:
                case 39:
                    testCard = ScriptableObject.CreateInstance<DeactivatedDrone>();
                    break;
                case 40:
                case 41:
                    testCard = ScriptableObject.CreateInstance<DamagedCivilianSpacecraft>();
                    break;
                case 42:
                    testCard = ScriptableObject.CreateInstance<ActiveDrone>();
                    break;
                case 43:
                case 44:
                    testCard = ScriptableObject.CreateInstance<LoneScout>();
                    break;
                case 45:
                    testCard = ScriptableObject.CreateInstance<DistressBeacon>();
                    break;
                case 46:
                case 47:
                    testCard = ScriptableObject.CreateInstance<SupplyCache>();
                    break;
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                    testCard = ScriptableObject.CreateInstance<AncientAlienTech>();
                    break;
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    testCard = ScriptableObject.CreateInstance<Merchant>();
                    break;
                default:
                    Debug.Log("I is going past 61 in EventDraw");
                    break;
            }
            cards.Add(i, testCard);
            testCard = null;
        }

        Resolution.Instance.CorrectResolution();

        if (Resolution.Instance != null)
        {
            x = Resolution.Instance.X;
            y = Resolution.Instance.Y;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!selectingChoice)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            guiText.enabled = false;
        }
	}

    void OnGUI()
    {
        if (GUIChoice)
        {

            GUILayout.BeginArea(choicePosition);
            GUILayout.BeginVertical();
            for (int i = 0; i < currentCard.Choices.Length; i++) 
            {
                if(GUILayout.Button(currentCard.Choices[i] + " " + currentCard.ChoiceText[i]))
                {
                    currentCard.Resolve(i);
                    selectingChoice = false;
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        if (Event.current.type == EventType.Layout)
        {
            innerController = 1;
        }

        if (Event.current.type == EventType.Repaint)
        {
            innerController = 2;
        }

        if (innerController == 2)
        {
            if (currentCard != null) 
            {
                choicePosition = new Rect(x * 450, y * 350, 150, 25 * currentCard.Choices.Length);
            }

            GUIChoice = selectingChoice;
            innerController = 0;
        }
    }

    private void eventActive(bool draw)
    {

        if (draw)
        {
            selectingChoice = true;

            card = Random.Range(0, 61);
            
            cards.TryGetValue(card, out currentCard);

            gameObject.GetComponent<SpriteRenderer>().sprite = currentCard.Card;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            guiText.enabled = true;
            guiText.text = currentCard.FlavorText;

            draw = false;
        }
    }
}
