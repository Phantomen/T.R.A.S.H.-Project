using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingInPlay : MonoBehaviour {
   
   //refers to the button to press to turn off sound
    public TogglButtonImage toggleButton;
    public bool isButton = false;
    AudioSource audiosource;
   

	void Start ()
    {
        audiosource = GetComponent<AudioSource>();       
        toggleButton = toggleButton.GetComponent<TogglButtonImage>();
        
	}

    //mutes audiosource and toggles the image for the button used
    public void ToggleSound()
    {
        audiosource.mute = !audiosource.mute;
        if (isButton)
        {
            toggleButton.ToggleSprite();

        }
    }
}
