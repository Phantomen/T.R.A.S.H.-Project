using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfDestructionHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject TargetedParticle)
    {
        Debug.Log("Collided with particle");
    }
}
