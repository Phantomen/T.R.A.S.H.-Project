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
            ToggleActive();
        }
	}

    public void ToggleActive()
    {
        if (active == true)
        {

            toBeToggled.SetActive(false);
            active = false;
            Time.timeScale = 1;
        }
        else if (active == false)
        {
            toBeToggled.SetActive(true);
            active = true;
            Time.timeScale = 0;
        }
    }

}
