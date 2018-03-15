using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrudgesHealthBar : MonoBehaviour {


    public GameObject healthBarObject;
    public List<Sprite> healthBar = new List<Sprite>();

    private int damageTaken = 0;
    private SpriteRenderer healthBarSpriterenderer;
    private PointSystem pointSystem;

    [Tooltip("Sound to play when boss takes damage")]
    [SerializeField]
    private AudioClip damageSound;

    [Tooltip("Sound to play when boss changes phase (reset healthbar)")]
    [SerializeField]
    private AudioClip phaseChangeSound;

    private Animator bossAnimator;

    // Use this for initialization
    void Start ()
    {
        healthBarSpriterenderer = healthBarObject.GetComponent<SpriteRenderer>();
        healthBarSpriterenderer.sprite = healthBar[0];
        pointSystem = GameObject.FindGameObjectWithTag("PointSystem").GetComponent<PointSystem>();

        bossAnimator = gameObject.transform.parent.gameObject.GetComponentInChildren<Animator>();
    }


    public void UpdateBar()
    {
        damageTaken ++;
            
        healthBarSpriterenderer.sprite = healthBar[damageTaken];

        //Play damage sound
        //Do not play sound if damage taken == 0
    }

    public void ResetBar()
    {
        damageTaken = 0;

        healthBarSpriterenderer.sprite = healthBar[damageTaken];

        //Play PhaseChangeSound

        //Animator, play the damage animation

        bossAnimator.SetTrigger("Slam");
    }

    public bool CheckFullDamage()
    {
        bool fullDamage = false;

        if (damageTaken >= healthBar.Count - 1)
        {
            fullDamage = true;
        }

        return fullDamage;
    }
}
