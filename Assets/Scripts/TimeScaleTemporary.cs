using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleTemporary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()

    {
        if (Input.GetKeyDown("space") && Input.GetKeyDown("p"))
        {
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0.7F;
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }
}
