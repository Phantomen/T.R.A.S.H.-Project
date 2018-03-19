using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private bool shaking = false;

    [Tooltip("Time it will shake")]
    [SerializeField]
    private float shakeTime = 1;

    private Timer shakeTimer;

    [Tooltip("")]
    [SerializeField]
    private float shakeAmount = 0.2f;

    private Vector3 camLocalPos = new Vector3();

    // Use this for initialization
    void Start ()
    {
        shakeTimer = new Timer(shakeTime, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if (shaking == true && shakeTimer.Expired == false)
        {
            shakeTimer.Time += Time.deltaTime;
            Shake();
        }

        else if (shakeTimer.Expired == true)
        {
            StopShaking();
        }
	}

    private void Shake()
    {
        if (shakeAmount > 0)
        {
            float shakeOffsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeOffsetY = Random.value * shakeAmount * 2 - shakeAmount;

            camLocalPos.x += shakeOffsetX;
            camLocalPos.y += shakeOffsetY;

            transform.localPosition = camLocalPos;
        }
    }

    public void StartCameraShake()
    {
        ResetShake();
    }

    private void ResetShake()
    {
        shakeTimer.Time = 0;
        shaking = true;
    }

    public void StopShaking()
    {
        shakeTimer.Time = 0;
        shaking = false;

        camLocalPos = new Vector3();
        transform.localPosition = new Vector3();
    }
}
