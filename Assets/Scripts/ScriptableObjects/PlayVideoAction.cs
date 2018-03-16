using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Actions/PlayVideo")]
public class PlayVideoAction : StateAction {

    [Tooltip("The prefab of the video")]
    [SerializeField]
    private GameObject videoCanvasPrefab;

    private bool triggered = false;

    public override void Act(StateController controller)
    {
        PlayVideo();
    }

    private void PlayVideo()
    {
        if (triggered == false)
        {
            triggered = true;

            Instantiate(videoCanvasPrefab);


            AudioSource[] audioSourceObject = GameObject.FindGameObjectWithTag("AudioSource").GetComponentsInChildren<AudioSource>();

            foreach (AudioSource au in audioSourceObject)
            {
                au.Stop();
            }

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    public override void Reset(StateController controller)
    {
        triggered = false;
    }
}
