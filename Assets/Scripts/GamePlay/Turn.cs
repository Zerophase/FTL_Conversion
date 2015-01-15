using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour {

    public int Players;

    public static int Playeramount;

    public GameObject Player;
    private GameObject player;

    private int playerTurn = 1;
	// Use this for initialization
	void Start () 
    {

        Playeramount = Players;
	    for (int i = 0; i < Playeramount; i++) 
        {
            Player = (GameObject)Instantiate(Player);
            Player.name = "Player " + (i + 1);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (endOfTurn())
        {
            playerTurn++;
            
            if (playerTurn > Players)
            {
                playerTurn = 1;
            }
        }
	}

    private bool endOfTurn()
    {
        if(Movement.Moved())
            return true;
        else
            return false;
    }
    public bool PlayerTurn (GameObject currentPlayer)
    {
        if (currentPlayer.name == "Player " + playerTurn)
            return true;
        else
            return false;
    }
}
