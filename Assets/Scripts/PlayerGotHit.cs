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


    private CameraShake camShake;

    // Use this for initialization
    void Start()
    {
        sound = sound.GetComponent<AudioSource>();
        timer = new Timer(invincibleTime, 0);
        deathTimer = new Timer(0.25f, 0);
        playerAnim = gameObject.GetComponent<PlayerAnimationController>();

        camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CameraShake>();
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

    private void PlayerHit()
    {
        sound.Play();
        boopCount++;
        pointSystem.ChangeLife(damageTakenByHits);
        timerOn = true;
        invincible = true;
        playerAnim.GotHit();
        inviciBarrier.SetActive(true);

        //GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CameraShake>().StartCameraShake;
        camShake.StartCameraShake();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet" && invincible == false)
        {
            PlayerHit();

            Destroy(other.gameObject, 0.1f);
        }
        else if (other.gameObject.tag == "laser" && invincible == false)
        {
            PlayerHit();
        }
    }
}
