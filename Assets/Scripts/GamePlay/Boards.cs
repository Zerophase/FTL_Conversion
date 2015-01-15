using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//TODO Move 21, 19, and 41 to start position.
public class Boards : MonoBehaviour {
    private static Vector2[] boardPosition = new Vector2[60];
    public static Vector2[] BoardPosition { get {return boardPosition; } }

    private static int mapNumber = 0;
    public static int MapNumber { get { return mapNumber; } }

    public static bool MapSwith = false;

    private float x;
    private float y;

    private float locationX;
    private float locationY;

    private float locationX2;
    private float locationY2;

    public float LocationX;
    public float LocationY;

    private int iterator = 0;

    private static int Location;

    private Sprite board;
    private Sprite board2;
    private Sprite board3;

    private SpriteRenderer boardSprite;
    Dictionary<int, Vector2> locations = new Dictionary<int, Vector2>();

    private static Chart  currentBoard;

	// Use this for initialization
	void Start () 
    {
        Resolution.Instance.CorrectResolution();

        if (Resolution.Instance != null)
        {
            x = Resolution.Instance.X;
            y = Resolution.Instance.Y;
        }

        board = Resources.Load<Sprite>("BOARD-1");
        board2 = Resources.Load<Sprite>("board2");
        board3 = Resources.Load<Sprite>("board3");
        boardSprite = gameObject.GetComponent<SpriteRenderer>();
        boardSprite.sprite = board;

        setUpBoadLocations();
        assignBoardLocations();
	}

    void Update()
    {
        if (Movement.currentChart == Chart.two)
        {
            //Renew turn head start
            boardSprite.sprite = board2;
        } 
        if(Movement.currentChart == Chart.three)
        {
            //TODO REnew turn head start
            boardSprite.sprite = board3;
        }    
    }

    //Consider input value of method drilling in here.
    void assignBoardLocations()
    { 
        Vector2 currentPosition;
        for (int i = 0; i < boardPosition.Length; i++)
        {
            locations.TryGetValue(iterator++, out currentPosition);
            boardPosition[i] = new Vector2(x * currentPosition.x, y * currentPosition.y);
        }
        Debug.Log("Locations dictionary has " + locations.Count);
    }

    void setUpBoadLocations()
    {
        for (int i = 0; i < 60; i++)
        {
            switch (i)
            {
                case 0:
                    locationX = 165;
                    locationY = 87;
                    break;
                case 1:
                    locationX = 300;
                    locationY = 50;
                    break;
                case 2:
                    locationX = 420;
                    locationY = 55;
                    break;
                case 3:
                    locationX = 490;
                    locationY = 100;
                    break;
                case 4:
                    locationX = 600;
                    locationY = 130;
                    break;
                case 5:
                    locationX = 600;
                    locationY = 195;
                    break;
                case 6:
                    locationX = 530;
                    locationY = 250;
                    break;
                case 7:
                    locationX = 228;
                    locationY = 90;
                    break;
                case 8:
                    locationX = 310;
                    locationY = 80;
                    break;
                case 9:
                    locationX = 360;
                    locationY = 127;
                    break;
                case 10:
                    locationX = 195;
                    locationY = 143;
                    break;
                case 11:
                    locationX = 192;
                    locationY = 200;
                    break;
                case 12:
                    locationX = 189;
                    locationY = 245;
                    break;
                case 13:
                    locationX = 322;
                    locationY = 189;
                    break;
                case 14:
                    locationX = 280;
                    locationY = 158;
                    break;
                case 15:
                    locationX = 450;
                    locationY = 150;
                    break;
                case 16:
                    locationX = 440;
                    locationY = 230;
                    break;
                case 17:
                    locationX = 510;
                    locationY = 164;
                    break;
                case 18:
                    locationX = 280;
                    locationY = 233;
                    break;
                case 19:
                    locationX = 380;
                    locationY = 380;
                    break;
                case 20:
                    locationX = 200;
                    locationY = 240;
                    break;
                case 21:
                    locationX = 40;
                    locationY = 40;
                    break;
                case 22:
                    locationX = 310;
                    locationY = 80;
                    break;
                case 23:
                    locationX = 413;
                    locationY = 90;
                    break;
                case 24:
                    locationX = 510;
                    locationY = 37;
                    break;
                case 25:
                    locationX = 600;
                    locationY = 90;
                    break;
                case 26:
                    locationX = 510;
                    locationY = 110;
                    break;
                case 27:
                    locationX = 440;
                    locationY = 130;
                    break;
                case 28:
                    locationX = 530;
                    locationY = 160;
                    break;
                case 29:
                    locationX = 400;
                    locationY = 170;
                    break;
                case 30:
                    locationX = 530;
                    locationY = 210;
                    break;
                case 31:
                    locationX = 190;
                    locationY = 130;
                    break;
                case 32:
                    locationX = 320;
                    locationY = 120;
                    break;
                case 33:
                    locationX = 180;
                    locationY = 160;
                    break;
                case 34:
                    locationX = 280;
                    locationY = 155;
                    break;
                case 35:
                    locationX = 160;
                    locationY = 210;
                    break;
                case 36:
                    locationX = 250;
                    locationY = 190;
                    break;
                case 37:
                    locationX = 350;
                    locationY = 200;
                    break;
                case 38:
                    locationX = 190;
                    locationY = 270;
                    break;
                case 39:
                    locationX = 300;
                    locationY = 240;
                    break;
                case 40:
                    locationX = 420;
                    locationY = 220;
                    break;
                case 41:
                    locationX = 40;
                    locationY = 40;
                    break;
                case 42:
                    locationX = 450;
                    locationY = 52;
                    break;
                case 43:
                    locationX = 340;
                    locationY = 52;
                    break;
                case 44:
                    locationX = 210;
                    locationY = 52;
                    break;
                case 45:
                    locationX = 270;
                    locationY = 75;
                    break;
                case 46:
                    locationX = 340;
                    locationY = 120;
                    break;
                case 47:
                    locationX = 220;
                    locationY = 140;
                    break;
                case 48:
                    locationX = 480;
                    locationY = 100;
                    break;
                case 49:
                    locationX = 425;
                    locationY = 113;
                    break;
                case 50:
                    locationX = 340;
                    locationY = 160;
                    break;
                case 51:
                    locationX = 470;
                    locationY = 155;
                    break;
                case 52:
                    locationX = 527;
                    locationY = 137;
                    break;
                case 53:
                    locationX = 430;
                    locationY = 200;
                    break;
                case 54:
                    locationX = 270;
                    locationY = 200;
                    break;
                case 55:
                    locationX = 305;
                    locationY = 270;
                    break;
                case 56:
                    locationX = 560;
                    locationY = 195;
                    break;
                case 57:
                    locationX = 560;
                    locationY = 240;
                    break;
                case 58:
                    locationX = 470;
                    locationY = 270;
                    break;
                case 59:
                    locationX = 380;
                    locationY = 260;
                    break;
                default:
                    Debug.Log("Incorrect value going into setup boad locations");
                    break;
            }
            locations.Add(i, new Vector2(locationX * x, locationY * y));
        }
    }
	
    public static Vector2 AccessBoard(Chart boards, int location)
    {
        currentBoard = boards;
        return BoardPosition[location];
    }

    //TODO add locations for next map.  Map switches every 20,
    // so 19, and 39.
    public static bool NorthPath(int location)
    {
        assignLocation(location);

        if (location == 8 || location == 13 || location == 14 || location == 17
            || location == 24 || location == 25 || location == 28 || location == 30
            || location == 48 || location == 49 || location == 50 || location == 51
            || location == 53 || location == 54 )
            return true;
        else
            return false;
    }

    public static bool EastPath(int location)
    {
        assignLocation(location);

        if (location == 1 || location == 2 || location == 3 
            || location == 4 || location == 9 || location == 15
            || location == 22 || location == 23 || location == 26
            || location == 32 || location == 34 || location == 29 ||
            location == 36 || location == 37 || location == 42 || location == 43
            || location == 44 || location == 45 || location == 46 || location == 47)
            return true;
        else
            return false;
    }

    public static bool SouthPath(int location)
    {
        assignLocation(location);

        if (location == 0 || location == 5 || location == 6 
            || location == 7 || location == 10 || location == 11 
            || location == 12 || location == 17 || location == 18
            || location == 16 || location == 27 || location == 29 || location == 31 ||
            location == 33 || location == 35 || location == 38 ||
            location == 39 || location == 40 || location == 52 || location == 56 || location == 57
            || location == 58 || location == 59 || location == 60 || location == 55
            || location == 20)
            return true;
        else
            return false;
    }

    private static void assignLocation(int location)
    {
        Location = location; 
    }
}
