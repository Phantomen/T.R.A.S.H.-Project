using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSelf : MonoBehaviour {

    public float duration;
    private float time;
    private bool runTimer = false;

	void FixedUpdate ()
    {
        if (runTimer)
       {

            time += Time.deltaTime;
            if (time >= duration)
            {
                runTimer = false;
                time = 0f;
                gameObject.SetActive(false);
            }
        }

	}

    void OnEnable()
    {
        runTimer= true;
    }
}
