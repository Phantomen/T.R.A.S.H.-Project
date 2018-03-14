using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingInPlay : MonoBehaviour {

   
    public TogglButtonImage toggleButton;
    public bool muteWithSpacebar = false, isButton = false;
    AudioSource audiosource;
    
	// Use this for initialization
	void Start ()
    {
        audiosource = GetComponent<AudioSource>();
       
        if (isButton)
        {
            toggleButton = toggleButton.GetComponent<TogglButtonImage>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && muteWithSpacebar)
            ToggleSound();
    }

    public void ToggleSound()
    {
        audiosource.mute = !audiosource.mute;
        if (isButton)
        {
            toggleButton.ToggleSprite();

        }
    }
}
