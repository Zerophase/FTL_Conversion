using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IObserver
{
    void ObserverUpdate(object sender, object message);
}
