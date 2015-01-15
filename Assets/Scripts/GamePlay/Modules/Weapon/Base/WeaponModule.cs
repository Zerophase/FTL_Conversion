using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IWeaponModule
{
    void ChanceToHit();
    void ApplyDamage(int damageSent);
}

public class WeaponModule : Module, IWeaponModule, IObserver, ISubject
{
    //Need to Check for ship in class.
    //Have combat send ships involved to class.
    protected int damage;
    public int Damage { get { return damage; } }

    protected int damageDealt;
    public int DamageDealt { get {return damageDealt; } }

    protected int powerRatingCost;
    public int PowerRatingCost { get { return powerRatingCost; } }

    protected int rollForHit;

    protected Ship shipEngaged;

    protected Ship playerShip;

    protected bool shieldsAreup = false;

    List<IObserver> observers = new List<IObserver>();
    public WeaponModule()
    {

    }

    public void FindEnemyShip(Ship ship)
    {
        shipEngaged = ship;
    }

    public void FindPlayerShip(Ship ship)
    {
        playerShip = ship;
        playerShip.Attach(this);
    }

	public virtual void ChanceToHit()
    {
        rollForHit = Random.Range(0, 6);

        switch (rollForHit)
        {
            case 0:
            case 1:
            case 2:
                damageDealt = 0;
                break;
            case 3:
            case 4:
            case 5:
                damageDealt = damage;
                break;
            default:
                Debug.Log("Random.Range isn't being applied.");
                break;
        }

        ApplyDamage(damageDealt);

        subtractPowerRating();
    }

    public virtual void ApplyDamage(int damageSent)
    {
        //Figure out Implementation
        //damageSent;
    }

    //TODO Rewrite for incapsulation. SHouldn't be in combat class, but refer directly to owner.
    public int subtractPowerRating()
    {
        return powerRatingCost;
    }

    public void AttachShip(Ship ship)
    {
        ship.Attach(this);
    }

    public virtual void ObserverUpdate(object sender, object message)
    {
        //check if sender is ship, and if sender is ship make sure
        //ApplyDamage goes towards ship's shields.
        if (message is bool && sender is Ship)
        {
            //So it doesn't break in later classes.
        }
    }

    public void Attach(IObserver o)
    {
        this.observers.Add(o);
    }

    public void Detach(IObserver o)
    {
        this.observers.Remove(o);
    }

    //TODO Add Notify to missile launcher upgrade path.
    public void Notify()
    {
        foreach (IObserver o in observers)
        {
            o.ObserverUpdate(this, this);
        }
    }
}
