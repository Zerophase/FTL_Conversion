using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventShip : EventCard, ISubject
{
    protected Ship ship;
    public Ship ActiveShip { get { return ship; } } 

    List<IObserver> observers = new List<IObserver>();

    protected WeaponModule weaponModule;

    public EventShip()
        :base()
    {

    }

    protected void needsPlayerShip()
    {
        ScriptableCoroutine.Instance.StartCoroutine(waitForNotify());
    }

    protected void activateCombat()
    {
        Combat.InCombat = true;
        Combat.BeginCombat = true;

        ship.ResetNPCShip();

        ScriptableCoroutine.Instance.StartCoroutine(waitForNotify());
    }

    protected IEnumerator waitForNotify()
    {
        yield return new WaitForSeconds(.2f);
        Notify();
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
            o.ObserverUpdate(this, this.ship);
        }
    }
}
