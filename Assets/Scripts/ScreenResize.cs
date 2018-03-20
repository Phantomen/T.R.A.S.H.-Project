using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResize : MonoBehaviour {

	
	void Start ()
    {
        //resizes the game window upon start to ensure the right resolution
        Screen.fullScreen = !Screen.fullScreen;
        Screen.SetResolution(614, 512, false);
    }
	
}
