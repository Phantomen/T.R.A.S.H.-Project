using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingInPlay : MonoBehaviour {

    public Sprite buttonOn, buttonOff;
    public GameObject toggleButton;
    public bool muteWithSpacebar = false, isButton = false;
    AudioSource audiosource;
    Image buttonImage;
	// Use this for initialization
	void Start ()
    {
        audiosource = GetComponent<AudioSource>();

        if (isButton)
        {
            buttonImage = toggleButton.GetComponent<Image>();
            buttonImage.sprite = buttonOn;
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
            if (buttonImage.sprite == buttonOn)
            {
                buttonImage.sprite = buttonOff;
            }
            else if (buttonImage.sprite == buttonOff)
            {
                buttonImage.sprite = buttonOn;
            }


        }
    }
}
