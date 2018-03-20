using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGotHit : MonoBehaviour {

    public GameObject activeLaser, inviciBarrier;
    public PointSystem pointSystem;
    public int damageTakenByHits = 1;
    public float invincibleTime = 1f;
    public bool invincible = false;
    public AudioSource sound;



    private int boopCount;
    private Timer timer;
    private Timer deathTimer;
    private bool timerOn = false;
    private bool gotHit = false;
    private PlayerAnimationController playerAnim;




    // Use this for initialization
    void Start()
    {
        sound = sound.GetComponent<AudioSource>();
        timer = new Timer(invincibleTime, 0);
        deathTimer = new Timer(0.25f, 0);
        playerAnim = gameObject.GetComponent<PlayerAnimationController>();

    }

    void FixedUpdate()
    {
        if (timerOn)
        {
            timer.Time += Time.deltaTime;
            if (timer.Expired == true)
            {
                timer.Time = 0;
                timerOn = false;
                invincible = false;
                inviciBarrier.SetActive(false);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet" && invincible == false)
        {

            sound.Play();
            boopCount++;
            pointSystem.ChangeLife(damageTakenByHits);
            timerOn = true;
            invincible = true;
            playerAnim.GotHit();
            Destroy(other.gameObject, 0.1f);
            inviciBarrier.SetActive(true);

        }
        else if (other.gameObject.tag == "laser" && invincible == false)
        {

            sound.Play();
            boopCount++;
            pointSystem.ChangeLife(damageTakenByHits);
            timerOn = true;
            invincible = true;
            //gotHit = true;
            //animator.SetBool("GetHit", true);
            playerAnim.GotHit();
            inviciBarrier.SetActive(true);

        }
    }
}
