using UnityEngine;
using System.Collections;

public interface ISupportModule
{
    void ApplyBonus(IShip ship);
    void RemoveBonus(IShip ship);
    //Maybe include bonus
}

public class SupportModule : Module, ISupportModule
{
    protected bool addBonus = true;
    protected bool removeBonus = false;

    protected int bonus;
    public int Bonus { get { return bonus; } }

    public SupportModule()
    {

    }

    public virtual void ApplyBonus(IShip ship)
    {

    }

    public virtual void RemoveBonus(IShip ship)
    {

    }
}
