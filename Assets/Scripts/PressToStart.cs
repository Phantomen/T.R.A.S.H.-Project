using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour {

    public GameObject loadingBar;
    public bool useLoadingBar = false;
    public string menuToLoad;
    private AudioSource audio;
    // Update is called once per frame

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
	void Update ()
    {
        if (Input.anyKey)
        {
            if (audio != null)
            {

            audio.Play();
            }
            if (useLoadingBar == true)
            {
                loadingBar.SetActive(true);
            }
            Application.LoadLevel(menuToLoad);

        }

    }
}
