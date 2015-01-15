using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {

    private Rect testRect = new Rect(1f, 0f, 300, 300);
  
    public GameObject testGameObject;

    private bool inRect = false;
	// Use this for initialization
	void Start () 
    {
        testGameObject.transform.position = new Vector3(testRect.x, testRect.y, 10f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (testRect.Contains(Input.mousePosition) ) 
        {

            Debug.Log("You are in the rect");
            if (Input.GetMouseButtonDown(0)) {
                inRect = true;

                Debug.Log("You are clicking in the rect.");
            }
        }
        else
            Debug.Log("You are not in the rect");

        if (inRect)
        {
            testGameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        }
	}
}
