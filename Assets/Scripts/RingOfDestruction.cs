using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfDestruction : MonoBehaviour {

    private ParticleSystem parSys;

    CircleCollider2D col2D;


    // Use this for initialization
    void Start () {
        parSys = GetComponent<ParticleSystem>();
        col2D = GetComponent<CircleCollider2D>();

        col2D.enabled = false;
    }

    private void Update()
    {
        if (parSys.isPlaying == true)
        {
            col2D.enabled = true;
        }

        else
        {
            col2D.enabled = false;
        }

        col2D.radius = (parSys.time / parSys.startLifetime) * (parSys.startSize / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
