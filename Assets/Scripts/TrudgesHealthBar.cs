using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrudgesHealthBar : MonoBehaviour {


    public GameObject healthBarObject;
    public List<Sprite> healthBar = new List<Sprite>();

    private int damageTaken = 0;
    private SpriteRenderer healthBarSpriterenderer;
    private PointSystem pointSystem;

    // Use this for initialization
    void Start ()
    {
        healthBarSpriterenderer = healthBarObject.GetComponent<SpriteRenderer>();
        healthBarSpriterenderer.sprite = healthBar[0];
        pointSystem = GameObject.FindGameObjectWithTag("PointSystem").GetComponent<PointSystem>();
    }


    public void UpdateBar()
    {
        damageTaken ++;
        healthBarSpriterenderer.sprite = healthBar[damageTaken];

        if (damageTaken == 5)
        {
            pointSystem.YouWin();
        }
    }
}
