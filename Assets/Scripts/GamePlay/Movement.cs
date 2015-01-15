using UnityEngine;
using System.Collections;

//Need to make player class that moves to locations.
//Try placing in prefab and have each player instantiate it.

public enum Chart { one = 0, two, three};
public class Movement : MonoBehaviour 
{
    private float width = 50;
    private float height = 50;

    private int locationNorth = -1;
    private int locationEast = 1;
    private int locationSouth = 0;

    private Rect northRect;
    private Rect eastRect;
    private Rect southRect;



    private Turn turn;

    private static bool hasMoved = false;

    private GameObject cardEvents;
    private EventDraw activeEvent;

    public static Player playerShip1;
    public static Player playerShip2;
    public static Player playerShip3;
    public static Player playership4;

    private float x;
    private float y;

    public static Chart currentChart = Chart.one;
	// Use this for initialization
	void Start () 
    {
        //TODO switch locations back.
        locationEast = 1;
        locationSouth = 0;
        locationNorth = -1;
        Resolution.Instance.CorrectResolution();
        
        if (Resolution.Instance != null)
        {
            x = Resolution.Instance.X;
            y = Resolution.Instance.Y;
        }

        switch (Turn.Playeramount)
        {
            case 1:
                playerShip1 = GameObject.Find("Player 0").GetComponent<Player>();
                break;
            case 2:
                playerShip1 = GameObject.Find("Player 1").GetComponent<Player>();
                playerShip2 = GameObject.Find("Player 2").GetComponent<Player>();
                break;
            case 3:
                playerShip1 = GameObject.Find("Player 1").GetComponent<Player>();
                playerShip2 = GameObject.Find("Player 2").GetComponent<Player>();
                playerShip3 = GameObject.Find("Player 3").GetComponent<Player>();
                break;
            case 4:
                playerShip1 = GameObject.Find("Player 1").GetComponent<Player>();
                playerShip2 = GameObject.Find("Player 2").GetComponent<Player>();
                playerShip3 = GameObject.Find("Player 3").GetComponent<Player>();
                playership4 = GameObject.Find("Player 4").GetComponent<Player>();
                break;
            default:
                break;
        }
        northRect = new Rect( x * 0f, y * 0f, width, height);;
        eastRect = new Rect(x * 0f, y * 0f, width, height);
        southRect = new Rect(x * 0f, y * 0f, width, height);

        turn = GameObject.Find("Turn").GetComponent<Turn>();

        cardEvents = GameObject.Find("Events");
        activeEvent = cardEvents.GetComponent<EventDraw>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (locationNorth != -1) 
        {
            northRect.center = Boards.AccessBoard(currentChart, locationNorth);
        }
        
        if (locationEast != -1) 
        {
            eastRect.center = Boards.AccessBoard(currentChart, locationEast);
        }
        
        if (locationSouth != -1) 
        {
            southRect.center = Boards.AccessBoard(currentChart, locationSouth);
        }
	}

    void OnGUI()
    {
        if (hasMoved) 
        {
            cardEvents.SendMessage("eventActive", true);
            setHasMoved(false);
        }

        if (turn.PlayerTurn(transform.parent.gameObject)
            && !activeEvent.SelectingChoice && !hasMoved
            && !Combat.InCombat && !Trade.Trading)
        {
            northMovement();

            if (locationEast != -1) 
            {
                eastMovement();
            }

            if (locationSouth != -1) 
            {
                southMovement();
            }
        }
    }

    void southMovement()
    {
        if (Boards.SouthPath(locationSouth))
        {
            if (GUI.Button(southRect, "move this way"))
            {
                BoardOneSouth();
                boardTwoSouth();
                boardThreeSouth();
                setHasMoved(true);
            }
        }
    }

    void boardThreeSouth()
    {
        if (locationSouth == 52)
        {
            locationEast = -1;
            locationSouth = 56;
            locationNorth = 51;
        }
        else if(locationSouth == 56)
        {
            locationNorth = -1;
            locationSouth = 57;
        }
        else if (locationSouth == 57)
        {
            locationSouth = 58;
        }
        else if(locationSouth == 58)
        {
            locationSouth = 59;
        }
        else if (locationSouth == 59)
        {
            locationSouth = 55;
        }
        else if (locationSouth == 55)
        {
            locationSouth = 20;
        }
        else if (locationSouth == 20)
        {
            locationSouth = -1;
            locationNorth = 54;
        }

    }
    #region SouthBoards
    void boardTwoSouth()
    {
        if (locationSouth == 31)
        {
            locationSouth = 33;
            locationEast = 32;
        }
        else if(locationSouth == 32)
        {
            locationSouth = 33;
        }
        else if(locationSouth == 29)
        {
            locationSouth = -1;
            locationNorth = 28;
        }
        else if (locationSouth == 27)
        {
            locationSouth = 29;
            locationEast = 26;
            locationNorth = -1;
        }
        else if(locationSouth == 33)
        {
            locationEast = 36;
            locationSouth = 35;
        }
        else if (locationSouth == 35)
        {
            locationEast = -1;
            locationSouth = 38;
        }
        else if (locationSouth == 38)
        {
            locationSouth = 39;
        }
        else if (locationSouth == 39)
        {
            locationEast = 37;
            locationSouth = 40;
        }
        else if (locationSouth == 40)
        {
            locationSouth = -1;
            locationEast = -1;
            locationNorth = 30;
        }
    }

    void BoardOneSouth()
    {
        if (locationSouth == 0)
        {
            locationEast = -1;
            locationSouth = 7;
        }
        else
            if (locationSouth == 7)
            {
                locationSouth = 10;
                locationEast = 9;
                locationNorth = 8;
            }
            else
                if (locationSouth == 10)
                {
                    locationSouth = 11;
                    locationNorth = -1;
                    locationEast = -1;
                }
                else
                    if (locationSouth == 11)
                    {
                        locationSouth = 12;
                    }
                    else
                        if (locationSouth == 12)
                        {
                            locationNorth = 13;
                            locationSouth = 18;
                        }
                        else
                            if (locationSouth == 18)
                            {
                                locationNorth = -1;
                                locationSouth = 16;
                            }
                            else
                                if (locationSouth == 16)
                                {
                                    locationSouth = 6;
                                }
                                else
                                    if (locationSouth == 5)
                                    {
                                        locationNorth = -1;
                                        locationSouth = 6;
                                    }
                                    else
                                        if (locationSouth == 6)
                                        {
                                            locationEast = 22;
                                            locationSouth = 31;
                                            currentChart = Chart.two;
                                        }
    }
    #endregion
    void eastMovement()
    {
        if (Boards.EastPath(locationEast))
        {
            if (GUI.Button(eastRect, "Move this way"))
            {
                boardOneEast();
                boardTwoEast();
                boardThreeEast();
                setHasMoved(true);
            }
        }
    }

    void boardThreeEast()
    {
        if (locationEast == 42)
        {
            locationNorth = -1;
            locationSouth = -1;
            locationEast = 43;
        }
        else if (locationEast == 43)
        {
            locationEast = 44;
        }
        else if (locationEast == 44)
        {
            locationEast = 45;
        }
        else if (locationEast == 45)
        {
            locationEast = 46;
        }
        else if (locationEast == 46) 
        {
            locationEast = 47;
            locationNorth = -1;
            locationSouth = -1;
            //TODO Federation Win
        }
        else if(locationEast == 47)
        {
            Application.LoadLevel(3);
        }
    }
    #region east Boards
    void boardTwoEast()
    {
        if (locationEast == 22)
        {
            locationSouth = -1;
            locationEast = 23;
        }
        else if(locationEast == 23)
        {
            locationNorth = 24;
            locationEast = 26;
        }
        else if(locationEast == 26)
        {
            locationEast = -1;
            locationSouth = 27;
            locationNorth = 28;
        }
        else if (locationEast == 32)
        {
            locationSouth = -1;
            locationEast = 34;
        }
        else if(locationEast == 34)
        {
            locationEast = -1;
            locationSouth = 29;
        }
        else if(locationEast == 36)
        {
            locationEast = 37;
            locationSouth = -1;
        }
        else if(locationEast == 37)
        {
            locationNorth = 30;
            locationEast = -1;
        }
    }
    void boardOneEast()
    {
        if (locationEast == 1)
        {
            locationSouth = -1;
            locationEast = 2;
        }
        else
            if (locationEast == 2)
            {
                locationNorth = -1;
                locationEast = 3;
            }
            else
                if (locationEast == 3)
                {
                    locationNorth = -1;
                    locationEast = 4;
                }
                else
                    if (locationEast == 4)
                    {
                        locationSouth = 5;
                        locationEast = -1;
                        locationNorth = 17;
                    }
                    else
                        if (locationEast == 9)
                        {
                            locationNorth = -1;
                            locationSouth = -1;
                            locationEast = 15;
                        }
                        else
                            if (locationEast == 15)
                            {
                                locationEast = -1;
                                locationSouth = 16;
                            }
    }
    #endregion
    void northMovement()
    {
        if (Boards.NorthPath(locationNorth))
        {
            if (GUI.Button(northRect, "Move this way"))
            {
                boardOneNorth();
                boardTwoNorth();
                boardThreeNorth();
                setHasMoved(true);
            }
        }
    }

    void boardThreeNorth()
    {
        if (locationNorth == 48)
        {
            locationEast = -1;
            locationSouth = -1;
            locationNorth = 49;
        }
        else if (locationNorth == 49)
        {
            locationNorth = 50;
        }
        else if(locationNorth == 50)
        {
            locationNorth = -1;
            locationEast = 47;
        }
        else if (locationNorth == 51)
        {
            locationNorth = 53;
        }
        else if(locationNorth == 53)
        {
            locationNorth = 54;
        }
        else if(locationNorth == 54)
        {
            locationNorth = -1;
            locationEast = 47;
        }
    }
    #region North Boards
    void boardTwoNorth()
    {
        if (locationNorth == 24)
        {
            locationEast = -1;
            locationSouth = -1;
            locationNorth = 25;
        }
        else if(locationNorth == 25)
        {
            locationEast = 26;
            locationNorth = -1;
        }
        else if(locationNorth == 28)
        {
            locationSouth = -1;
            locationNorth = 30;
        }
        else if(locationNorth == 30)
        {
            currentChart = Chart.three;
            locationEast = 42;
            locationNorth = 48;
            locationSouth = 52;
        }
    }
    void boardOneNorth()
    {
        if (locationNorth == 8) 
        {
            locationNorth = -1;
            locationEast = 2;
            locationSouth = -1;
        }

        if (locationNorth == 13)
        {
            locationNorth = 14;
            locationSouth = -1;
        }
        else
            if (locationNorth == 14)
            {
                locationNorth = -1;
                locationEast = 9;
            }

        if (locationNorth == 17) 
        {
            locationNorth = -1;
            locationEast = -1;
            locationSouth = 16;
        }
    }
    #endregion
    private void setHasMoved(bool tempHasMoved)
    {
        hasMoved = tempHasMoved;
    }

    public static bool Moved()
    {
        return hasMoved;
    }
}
