using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglButtonImage : MonoBehaviour {

    public Sprite buttonOn, buttonOff;
    Image buttonImage;
    // Use this for initialization
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
