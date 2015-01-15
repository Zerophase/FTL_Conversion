using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IShip
{
    int Maneuverability { get; set; }
    int PowerRating { get; set; }
    int Shields { get; set; }
    int Hull { get; set; }
    int Crew { get; set; }
}

public enum ShipType { DEFENDER, INTERCEPTOR, SCOUT, BLACKMARKETTRADER, BLACKSTAR, DRONE, MILITARYSHIP, PIRATE, SLAVER}

public class Ship : ScriptableObject, IShip, ISubject
{
    protected int maneuverability;
    public int Maneuverability { get { return maneuverability; } set { maneuverability = value; } }

    protected int powerRating;
    public int PowerRating { get { return powerRating; } set {powerRating = value; } }

    protected int shields;
    public int Shields { get { return shields; } set { shields = value; } }

    protected int hull;
    public int Hull { get { return hull; } set { hull = value; } }

    protected int crew;
    public int Crew { get { return crew; } set { crew = value; } }

    protected int maxManeuverability;
    public int MaxManeuverability { get { return maneuverability; } set { maneuverability = value; } }
    
    protected int maxPowerRating;
    public int MaxPowerRating { get { return powerRating; } set {powerRating = value; } }
    
    protected int maxShields;
    public int MaxShields { get { return shields; } set { shields = value; } }
    
    protected int maxhull;
    public int MaxHull { get { return hull; } set { hull = value; } }
    
    protected int maxCrew;
    public int MaxCrew { get { return crew; } set { crew = value; } }

    protected string shipName;
    protected string ShipName { get { return name; } }

    private bool shieldsAreUp;
    public bool ShieldsAreUp
    {
        get { 
            if (shields > 0) 
            {
                shieldsAreUp = true;
                Debug.Log("The Shields are up.");
                Notify();
            }
            else
                shieldsAreUp = false;

            return shieldsAreUp; }
        set
        {
            if (shields > 0) 
            {
                shieldsAreUp = true;
                Debug.Log("The Shields are up.");
                Notify();
            }
            else
                shieldsAreUp = false;
        }
    }

    protected Sprite shipSprite;
    public Sprite ShipSprite { get { return shipSprite; } set { shipSprite = value; } }

    protected ShipType currentShipType;

    protected List<ISupportModule> supportModules = new List<ISupportModule>();
    public List<ISupportModule> SupportModules { get { return supportModules; } }

    protected List<WeaponModule> weaponModules = new List<WeaponModule>();
    public List<WeaponModule> WeaponModules { get { return weaponModules; } } 

    //Need to add weapon modules
    List<IObserver> observers;

    public Ship()
    {
        observers = new List<IObserver>();
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
            if (o is LaserCannon)
                o.ObserverUpdate(this, this.shieldsAreUp);
            if (o is MissileLauncher)
                o.ObserverUpdate(this, this.currentShipType);

            if (o is Trade)
                o.ObserverUpdate(this, this);
        }
    }

    public void FireMissiles(Module module)
    {
        Debug.Log("firing missiles");
        if (module is MissileLauncher)
        {
            Debug.Log("Module is being recognized as missile launcer");
            Notify();
        }
    }

    public void AddModule(Module module)
    {
        if (module  is SupportModule)
            supportModules.Add(module as SupportModule);
        else if (module is WeaponModule)
            weaponModules.Add(module as WeaponModule);
    }

    //Need to test. Might need to be rewritten a bit.
    //TODO Rewrite for SupportModule
    protected void equipSupportModules(ISupportModule addMSupportodule)
    {
        foreach (ISupportModule sModule in supportModules)
        {
            if (sModule == null) 
            {
                supportModules.Find(sm => sm is AncientAlienDevice).ApplyBonus(this);
            }
        }
    }

    protected void equipWeapons(WeaponModule weaponModule)
    {
        foreach (WeaponModule wm in weaponModules)
        {
            
        }
    }

    public void RestorePlayerShields()
    {
        shields = maxShields;
    }

    public void ResetNPCShip()
    {
        hull = maxhull;
        shields = maxShields;
        crew = maxCrew;
        powerRating = maxPowerRating;
        maneuverability = MaxManeuverability;
    }
}
