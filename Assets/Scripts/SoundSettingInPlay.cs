using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingInPlay : MonoBehaviour {

   
    public TogglButtonImage toggleButton;
    public bool isButton = false;
    AudioSource audiosource;
    
	// Use this for initialization
	void Start ()
    {
        audiosource = GetComponent<AudioSource>();
       
        
            toggleButton = toggleButton.GetComponent<TogglButtonImage>();
        
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
