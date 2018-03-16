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
        StartCoroutine(PlayEngineSound(engineStartClip, engineLoopClip));
	}
	
	// Update is called once per frame
	//void Update ()
   // {
        //if (Input.GetKeyDown("space"))
        //{
        //audioSource.Stop();
        //}
            

    //}

    public IEnumerator PlayEngineSound(AudioClip startClip, AudioClip loopClip)
    {
        audioSource.clip = startClip;
        audioSource.Play();
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        if (keepPlaying)
        {
        audioSource.clip = loopClip;
        audioSource.Play();
        }
    }

    public void ChangeMusic(AudioClip startClip, AudioClip loopClip)
    {
        StartCoroutine(PlayEngineSound(startClip, loopClip));
    }

    public void StopMusic()
    {
        keepPlaying = false;
        audioSource.Stop();
    }

}
