using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, ISubject
{
    private int playerNumber;
    public int PlayerNumber {set { playerNumber = value; } }

    public GameObject Move;
    private GameObject move;

    public GameObject Turn;

    public Ship playerShip;

    private int xp;
    public int XP { get { return xp; } set { xp = value; } }

    List<IObserver> observers;

	// Use this for initialization
	void Start () 
    {
        observers = new List<IObserver>();
        gameObject.name = "Player " + playerNumber;
        move = (GameObject)Instantiate(Move);
        move.transform.parent = gameObject.transform;

        Turn = GameObject.Find("Turn");
        gameObject.transform.parent = Turn.transform;

        //Adds ship to player.
        playerShip = ScriptableObject.CreateInstance<Scout>();
	}

	// Update is called once per frame
	void Update () 
    {
        if (Combat.BeginCombat)
        {
            Notify();

            Combat.BeginCombat = false;
        }

        if (Trade.Trading)
        {
            Notify();
        }
        if (playerShip.Hull <= 0)
        {
            Application.LoadLevel(3);
        }
        //Add code to detach here.
	}

    public void Attach(IObserver o)
    {
        this.observers.Add(o);
    }
    
    public void Detach(IObserver o)
    {
        this.observers.Remove(o);
    }
    
    public void Notify()
    {
        foreach (IObserver o in observers)
        {
            if (o is Combat)
                o.ObserverUpdate(this, this.playerShip);

            if (o is Trade)
                o.ObserverUpdate(this, this.playerShip);

        }
    }


}
