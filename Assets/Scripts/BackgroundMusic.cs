using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {


    public AudioClip engineStartClip, engineLoopClip;

    private bool keepPlaying = true;
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playEngineSound());

	}
	
	// Update is called once per frame
	//void Update ()
   // {
        //if (Input.GetKeyDown("space"))
        //{
        //audioSource.Stop();
        //}
            

    //}

    IEnumerator playEngineSound()
    {
        audioSource.clip = engineStartClip;
        audioSource.Play();
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        if (keepPlaying)
        {
        audioSource.clip = engineLoopClip;
        audioSource.Play();
        }
    }

    public void StopMusic()
    {
        keepPlaying = false;
        audioSource.Stop();
    }

}
