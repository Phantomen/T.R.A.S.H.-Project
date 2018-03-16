﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMover : MonoBehaviour {

    public int speed = 1;

    Rigidbody2D myRigidbody;


	// Use this for initialization
	void Start ()
    {
        //gets rigidbody component
        myRigidbody = transform.gameObject.GetComponent<Rigidbody2D>();
        //Sets objects velocity
        myRigidbody.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //makes sure that the object always moves up
        myRigidbody.velocity = transform.up * speed;
    }
}
