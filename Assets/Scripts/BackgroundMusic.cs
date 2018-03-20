using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {


    public AudioClip engineStartClip, engineLoopClip;

    private bool keepPlaying = true;
    private AudioSource audioSource;
 
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        ChangeMusic(engineStartClip, engineLoopClip);
	}
	

    public IEnumerator PlayEngineSound(AudioClip startClip, AudioClip loopClip)
    {
        //Plays the startClip
        audioSource.clip = startClip;
        audioSource.Play();

        //Waits until the startClip has finished playing before starting to play the loopClip
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        if (keepPlaying)
        {
        audioSource.clip = loopClip;
        audioSource.Play();
        }
    }

    //Change the current music
    public void ChangeMusic(AudioClip startClip, AudioClip loopClip)
    {
        StartCoroutine(PlayEngineSound(startClip, loopClip));
    }

    //Stops the music
    public void StopMusic()
    {
        keepPlaying = false;
        audioSource.Stop();
    }

}
