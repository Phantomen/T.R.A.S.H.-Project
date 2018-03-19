using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToShow : MonoBehaviour {

    public float wait = 3f;
    public GameObject objectToShow;
    // private Timer timer;
    private float timer;

	// Use this for initialization
	void Start ()
    {
        //timer = new Timer(wait, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= wait)
        {
            objectToShow.SetActive(true);
        }
	}
}
