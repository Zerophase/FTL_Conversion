using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//TODO Reset Shields after combat.
public class Combat : MonoBehaviour, IObserver 
{
    private float x;
    private float y;

    private int[] turn = new int[2];

    private int[] mobility = new int[2];
    public int[] Mobility { set { mobility = value; } }

    private static bool inCombat = false;
    public static bool InCombat { get { return inCombat; } set { inCombat = value; } }

    private static bool beginCombat;
    public static bool BeginCombat { get { return beginCombat; } set {beginCombat = value; } }

    private bool victory = false;
    private bool loss = false;

    private bool turnOrderSet = false;

    public GameObject[] CombatSprites;

    public GameObject[] CombatText;

    private int[] manueverability = new int[2];
    private int[] crew = new int[2];
    private int[] hull= new int[2];
    private int[] powerRating = new int[2];
    private int[] shields = new int[2];

    Ship[] ship = new Ship[2];

    //TODO Make Player an array.
    Player player;
    EventShip eventShip;

    private enum turnOrder { NONEASSIGNED, SHIPONE, SHIPTWO };
    private turnOrder orderOfPlay = turnOrder.NONEASSIGNED;

    private Rect weaponRectPlayer;
    private Rect weaponRectEnemy;

    private bool playerTurn;
    private bool turnsSet = false;
    private bool nextTurn;
	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<Player>();

        Resolution.Instance.CorrectResolution();
        
        if (Resolution.Instance != null)
        {
            x = Resolution.Instance.X;
            y = Resolution.Instance.Y;
        }

        for (int i = 0; i < turn.Length; i++)
        {
            turn[i] = 1;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (inCombat)
        {
            startCombat();

            combatTurns();

            endCombat();
            //Debug.Log("Player is in combat.");
        }
	}

    private int mapValue;
    private void endCombat()
    {
        if (turnOrderSet)
        {
            //Loss and victory is set up with
            //Victory corresponding with Federation
            //Loss corresponding with Rebel
            if (ship[0].Hull <= 0)
            {
                //Enemy wins in this case.
                //SHouldn't be true always
                loss = true;
                Debug.Log("Player 2 wins");
            }
            if(ship[1].Hull <= 0)
            {
                victory = true;
                Debug.Log("Player 1 wins");
            }

            if (victory == true)
            {
                switch (mapValue) 
                {
                    case 0:
                        player.XP += 1;
                        break;
                    case 1:
                        player.XP += 2;
                        break;
                    case 2:
                        player.XP += 3;
                        break;
                    default:
                    break;
                }
                player.Detach(this);
                eventShip.Detach(this);
                turnOffSprites();
                inCombat = false;
                turnsSet = false;
                turnOrderSet = false;
                //Might not want to set false.
                victory = false;
                beginCombat = false;
                orderOfPlay = turnOrder.NONEASSIGNED;
                ship[0].RestorePlayerShields();
                for (int i = 0; i < ship.Length; i++) 
                {
                    ship[i] = null;
                }
            }

            if (loss) 
            {
                //TODO Load AfterAction Repot.
                //TODO Button on After Action takes player back to start.
                Debug.Log("You lose.");
                //TODO Make loss reset the game.
            }
        }
        
    }

    private void turnOffSprites()
    {
        foreach (GameObject playSprite in CombatSprites)
        {
            playSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void combatTurns()
    {
        if (ship[0] != null && ship[1] != null)
        {
            determineTurnOrder();

            combatRounds();
        }
    }

    private void combatRounds()
    {
        if (!turnsSet)
        {
            switch (orderOfPlay)
            {
                case turnOrder.SHIPONE:
                    playerTurn = true;
                    break;
                case turnOrder.SHIPTWO:
                    playerTurn = false;
                    break;
                default:
                    Debug.Log("Order of play isn't being set.");
                    break;
            }
        }
        turnsSet = true;
    }

    private void determineTurnOrder()
    {
        if (orderOfPlay == turnOrder.NONEASSIGNED)
        {
            if (ship[0].Maneuverability > ship[1].Maneuverability)
            {
                orderOfPlay = turnOrder.SHIPONE;
                turnOrderSet = true;
                Debug.Log("Ship 0 is going first.");
            }
            else if (ship[1].Maneuverability > ship[0].Maneuverability)
            {
                orderOfPlay = turnOrder.SHIPTWO;
                turnOrderSet = true;
                Debug.Log("Ship 1 is going first.");
            }
            else if (ship[0].Maneuverability == ship[1].Maneuverability)
            {
                Debug.Log("Both ships have the sam maneuverability");
                if(Random.Range(0, 6) > 3)
                    orderOfPlay = turnOrder.SHIPONE;
                else
                    orderOfPlay = turnOrder.SHIPTWO;
                
                turnOrderSet = true;
            }
        }
        else if ((orderOfPlay == turnOrder.SHIPONE || orderOfPlay == turnOrder.SHIPTWO)
                 && turnOrderSet == false)
            Debug.Log("Ship turn order hasn't been reset");
    }

    void OnGUI()
    {
        if (nextTurn) 
        {
            for (int i = 0; i < ship.Length; i++) {
                //Debug.Log("Ship " + i + " " + ship[i].Hull);
            }

            nextTurn = false;
            if(playerTurn)
            {
                playerTurn = false;
                powerRating[1] = ship[1].PowerRating;
            }
            else if(!playerTurn)
            {
                playerTurn = true;
                powerRating[0] = ship[0].PowerRating;
            }
        }

        if (turnOrderSet)
        {
            assignTextToGameObject(0);
            assignTextToGameObject(1);

            if (playerTurn) 
            {
                for (int i = 0; i < ship.Length; i++) {
                    //Debug.Log("Ship " + i + " " + ship[i].Hull);
                }
                GUILayout.BeginArea(weaponRectPlayer);
                GUILayout.BeginHorizontal();
                for (int i = 0; i < ship[0].WeaponModules.Count; i++)
                {
                    //            if(GUILayout.Button(currentCard.Choices[i] + " " + currentCard.ChoiceText[i]))
                    //            {
                    //                currentCard.Resolve(i);
                    //                selectingChoice = false;
                    //            }
                    if (GUILayout.Button(ship[0].WeaponModules.ElementAt<WeaponModule>(i).WeaponSprite)) 
                    {
                        ship[0].WeaponModules.ElementAt<WeaponModule>(i).FindEnemyShip(ship[1]);
                        ship[0].WeaponModules.ElementAt<WeaponModule>(i).FindPlayerShip(ship[0]);
                        ship[0].FireMissiles(ship[0].WeaponModules.ElementAt<WeaponModule>(i));

                        ship[0].WeaponModules.ElementAt<WeaponModule>(i).ChanceToHit();
                        
                        powerRating[0] -= ship[0].WeaponModules.ElementAt<WeaponModule>(i).subtractPowerRating();

                        Debug.Log("Player 1 fires");
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();

                if (powerRating[0] <= 0) 
                {
                    nextTurn = true;
                }
            }

            if (!playerTurn) 
            {
                GUILayout.BeginArea(weaponRectEnemy);
                GUILayout.BeginHorizontal();
                for (int i = 0; i < ship[1].WeaponModules.Count; i++)
                {
                    if (GUILayout.Button(ship[1].WeaponModules.ElementAt<WeaponModule>(i).WeaponSprite)) 
                    {
                        ship[1].WeaponModules.ElementAt<WeaponModule>(i).FindEnemyShip(ship[0]);
                        ship[1].WeaponModules.ElementAt<WeaponModule>(i).ChanceToHit();

                        powerRating[1] -= ship[1].WeaponModules.ElementAt<WeaponModule>(i).subtractPowerRating();
                        //hull[1] = ship[1].Hull;
                        Debug.Log("Player 2 fires");
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();

                if (powerRating[1] <= 0) 
                {
                    nextTurn = true;
                }
            }

            displayDamage();
        }

    }

    private void displayDamage()
    {
        for (int i = 0; i < ship.Length; i++)
        {
            hull[i] = ship[i].Hull;
            crew[i] = ship[i].Crew;
            shields[i] = ship[i].Shields;
        }

    }
    private void startCombat()
    {
        if (beginCombat)
        {
            eventShip = FindObjectOfType<EventShip>();

            player.Attach(this);
            eventShip.Attach(this);

            turnOnSprites();
        }
    }

    private void turnOnSprites()
    {
        foreach (GameObject playSprite in CombatSprites)
        {
            playSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void ObserverUpdate(object sender, object message)
    {
        if (message is Ship)
        {
            if (sender is Player) 
            {
                ship[0] = ((Player)sender).playerShip;

                CombatSprites[1].GetComponent<SpriteRenderer>().sprite = ship[0].ShipSprite;

                //status text
                manueverability[0] = ship[0].Maneuverability;
                powerRating[0] = ship[0].PowerRating;
                shields[0] = ship[0].Shields;
                crew[0] = ship[0].Crew;
                hull[0] = ship[0].Hull; //= 10;
                assignTextToGameObject(0);
                Debug.Log("Stats assigned for Player");
                weaponRectPlayer = new Rect( 300f * x, 500f * y, (200f * ship[0].WeaponModules.Count), 252);
                Debug.Log("Player is attached");
            }

            if (sender is EventShip) 
            {
                ship[1] = ((EventShip)sender).ActiveShip;
                CombatSprites[2].GetComponent<SpriteRenderer>().sprite = ship[1].ShipSprite;

                manueverability[1] = ship[1].Maneuverability;
                powerRating[1] = ship[1].PowerRating;
                shields[1] = ship[1].Shields;
                crew[1] = ship[1].Crew;
                hull[1] = ship[1].Hull;
                assignTextToGameObject(1);
                Debug.Log("Stats assigned for Enemy");
                weaponRectEnemy = new Rect( 300f * x, 100f * y, (200f * ship[1].WeaponModules.Count), 252);
                Debug.Log("ActiveDrone is attached." + sender);
            }
            Debug.Log("Observer pattern is working.");
        }
    }

    private void assignTextToGameObject(int arrayLoc)
    {
        CombatText[arrayLoc].GetComponent<GUIText>().text = manueverability[arrayLoc].ToString() + "\n" +
            powerRating[arrayLoc].ToString() + "\n" + shields[arrayLoc].ToString() + "\n" + hull[arrayLoc].ToString() + "\n" + crew[arrayLoc].ToString();
    }
}
