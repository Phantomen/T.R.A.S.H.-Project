﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {

    //public GameObject player;
    public GameObject gameOver, youWin, meterUI, audioSource, powerUpReady, flashingMeterUI, emptyingMeterUI;

    private GameObject player;

    public Text life, meter;
    public int lifeAmount = 3;
    public BackgroundMusic backgroundMusic;
    public List<Sprite> meterBar = new List<Sprite>();
    public int meterGoalvalue;

    public GameObject[] bullets;

    Image meterImage;

    //For when depleteOrFill is true, starts off the value at 0 instead of the meterFilled value
    private int meterStartValue = 0, maxHealth, meterFilled = 0;
    private bool meterFull = false;
    private float tempTime;


    public GameObject blank;


    // Use this for initialization
    void Start () {

        //audio = audioSource.GetComponent<AudioSource>();
        
        meterImage = meterUI.GetComponent<Image>();
        life.text = "Life: " + lifeAmount.ToString();
        maxHealth = lifeAmount;

        //meterGoalvalue = meterFilled;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeLife(int other)
    {

            lifeAmount -= other;
            life.text = "Life: " + lifeAmount.ToString();

        if (lifeAmount <= 0)
        {
            YouLose();
        }
    }

    public void FillMeter(int other)
    {
        meterFilled += other;


        if (meterFull == false)
        {
            meterImage.sprite = meterBar[meterFilled];
        }

        if (meterFilled >= 5)
        {
            //activateMeter thingy
            powerUpReady.SetActive(true);
            flashingMeterUI.SetActive(true);
            meterFull = true;
        }
    }

    public void YouWin()
    {

            youWin.SetActive(true);
            player.SetActive(false);
            backgroundMusic.StopMusic();
    }

    public void YouLose()
    {
        gameOver.SetActive(true);
        player.SetActive(false);
        backgroundMusic.StopMusic();
    }

    void FixedUpdate()
    {
       if (Input.GetKeyDown("space") && meterFull == true)
       {
            powerUpReady.SetActive(false);
            flashingMeterUI.SetActive(false);
            emptyingMeterUI.SetActive(true);
            meterFull = false;
            meterFilled -= 5;

            int filled = meterFilled;

            if (meterFilled >= 5)
            {
                filled = 5;
                meterFull = true;
                powerUpReady.SetActive(true);
                flashingMeterUI.SetActive(true);
            }

            meterImage.sprite = meterBar[filled];

            //bullets = GameObject.FindGameObjectsWithTag("bullet");
            //foreach (GameObject bullet in bullets )
            //{
            //    Destroy(bullet);
            //}

            Instantiate(blank, player.transform.position, new Quaternion());
       }
    }
}
