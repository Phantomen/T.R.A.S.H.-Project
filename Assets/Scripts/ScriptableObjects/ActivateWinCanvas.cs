using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/ActivateWinCanvas")]
public class ActivateWinCanvas : StateAction {

    private bool triggered = false;

    public override void Act(StateController controller)
    {
        ActivateCanvas(controller);
    }

    private void ActivateCanvas(StateController controller)
    {
        if (triggered == false)
        {
            triggered = true;

            GameObject winCanvas = GameObject.Find("Canvas").transform.Find("YouWin").gameObject;

            if (winCanvas.activeSelf == false && winCanvas != null)
            {
                AudioSource[] audioSourceObject = GameObject.FindGameObjectWithTag("AudioSource").GetComponentsInChildren<AudioSource>();

                //Stops all the audio from the AudioSource object
                foreach (AudioSource au in audioSourceObject)
                {
                    au.Stop();
                }

                //Inactivates the player to stop it from making sound
                controller.playerGameObject.SetActive(false);

                winCanvas.SetActive(true);
            }
        }
    }


    public override void Reset(StateController controller)
    {
        triggered = false;
    }
}
