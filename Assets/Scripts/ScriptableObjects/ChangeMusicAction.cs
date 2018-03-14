using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/ChangeMusic")]
public class ChangeMusicAction : StateAction {

    [Tooltip("The clip that starts playing")]
    [SerializeField]
    private AudioClip startClip;

    [Tooltip("The clip that will loop after teh startclip is done")]
    [SerializeField]
    private AudioClip loopClip;

    private bool triggered = false;

    public override void Act(StateController controller)
    {
        ChangeMusic();
    }

    private void ChangeMusic()
    {
        if (triggered == false)
        {
            triggered = true;

            GameObject audioS = GameObject.FindGameObjectWithTag("AudioSource");

            BackgroundMusic bm = audioS.GetComponentInChildren<BackgroundMusic>();

            bm.ChangeMusic(startClip, loopClip);
        }
    }

    public override void Reset(StateController controller)
    {
        triggered = false;
    }
}
