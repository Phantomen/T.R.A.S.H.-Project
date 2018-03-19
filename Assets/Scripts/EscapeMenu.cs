using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour {

    public GameObject toBeToggled;
    private bool active = false;


	void Update ()
    {
        //When pressing esc, set chosen gameobject as active, in this case a menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleActive();
        }
	}

    public void ToggleActive()
    {
        //if the menu is active, deactivate it and set timescale to 1 to make everything move again
        if (active == true)
        {

            toBeToggled.SetActive(false);
            active = false;
            Time.timeScale = 1;
        }

        //if the menu isn't active, activate it and set timescale to 0 to stop everything from moving
        else if (active == false)
        {
            toBeToggled.SetActive(true);
            active = true;
            Time.timeScale = 0;
        }
    }

}
