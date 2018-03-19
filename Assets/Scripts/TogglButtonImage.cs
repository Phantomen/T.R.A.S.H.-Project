using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglButtonImage : MonoBehaviour {
    //yes, the name has a typo. Too lazy to fix and go back to the scripts that use this one because of one letter

    //the sprites for showing if the button is on or off
    public Sprite buttonOn, buttonOff;
    Image buttonImage;
    
    void Start ()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = buttonOn;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ToggleSprite()
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
