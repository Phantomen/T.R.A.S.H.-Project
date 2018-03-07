using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Screen.SetResolution(614, 512, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
