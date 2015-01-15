using UnityEngine;
using System.Collections;

public class LocationTracker
{
    public LocationTracker()
    {

    }

    private int currentLocation;

    public void assignLocation(int location)
    {
        currentLocation = location; 
    }
}
