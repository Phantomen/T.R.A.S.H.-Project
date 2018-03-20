using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionInstantiator : MonoBehaviour {

    [Tooltip("Gives position to instantiate minions")]
    public Transform prefab;
    [Tooltip("Amount of minions spawned")]
    public int minionCount;
    [Tooltip("Delay between minion spawning")]
    public float delay;
    [Tooltip("Delay the start of the minions spawning")]
    public float startDelay;

    private int counter;
    private Timer timer;

	void Start ()
    {
        timer = new Timer(startDelay, 0);
    }
	
	void FixedUpdate ()
    {
        timer.Time += Time.deltaTime;


        if (timer.Expired == true && counter < minionCount)
        {
            if (timer.Duration != delay)
            {
                timer.Duration = delay;
            }

            Instantiate(prefab, transform.position, transform.rotation);
            timer.Time -= delay;
            ++counter;
        }
		
	}
}
