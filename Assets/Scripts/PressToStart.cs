using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour {


    public string menuToLoad;
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKey)
        {
            Application.LoadLevel(menuToLoad);
        }

    }
}
