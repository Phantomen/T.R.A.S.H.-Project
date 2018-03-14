using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour {

    public GameObject toBeToggled;
    private bool active = false;

	// Use this for initialization
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == true)
            {
                ToggleOff();

            }
            else if (active == false)
            {
                ToggleOn();
            }
        }
	}

    public void ToggleOn()
    {
        toBeToggled.SetActive(true);
        active = true;
    }

    public void ToggleOff()
    {
        toBeToggled.SetActive(false);
        active = false;
    }
}
