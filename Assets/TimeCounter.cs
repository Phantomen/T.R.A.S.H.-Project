using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {


    public Text scoreText, timeText;
    public float startingScore;

    private float timer;
    private int seconds;
    private bool countDown = true;
	// Use this for initialization
	void Start ()
    {
        scoreText.text = startingScore.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (countDown)
        {
            timer += Time.deltaTime;
            //seconds = Convert.ToInt32(timer % 60);
            startingScore -= Time.deltaTime;
            scoreText.text = startingScore.ToString();
            timeText.text = seconds.ToString();
        }
    }
}
