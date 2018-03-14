using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicAction : StateAction {

    [Tooltip("The clip that starts playing")]
    [SerializeField]
    private AudioClip startclip;

    [Tooltip("The clip that will loop after teh startclip is done")]
    [SerializeField]
    private AudioClip loopClip;

    public override void Act(StateController controller)
    {
        ChangeMusic();
    }

    private void ChangeMusic()
    {
        GameObject audioS = GameObject.FindGameObjectWithTag("AudioSource");

        BackgroundMusic bm = audioS.GetComponentInChildren<BackgroundMusic>();

        MonoBehaviour monoBehavior = new MonoBehaviour();
        monoBehavior.StartCoroutine(bm.PlayEngineSound(startclip, loopClip));
    }

    public override void Reset(StateController controller)
    {
        throw new System.NotImplementedException();
    }
}
