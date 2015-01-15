using UnityEngine;
using System.Collections;

public class ScriptableCoroutine : MonoBehaviour {

    public static ScriptableCoroutine Instance;
	// Use this for initialization
	void Start () 
    {
        ScriptableCoroutine.Instance = this;
	}
}
