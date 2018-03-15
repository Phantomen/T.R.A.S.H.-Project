using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/SpawnRingOfAnnihilation")]
public class SpawnRingOfAnnihilationAction : StateAction {

    [Tooltip("The blank")]
    [SerializeField]
    private GameObject blank;

    private bool triggered = false;

    public override void Act(StateController controller)
    {
        if (triggered == false)
        {
            triggered = true;
            TriggedBlank(controller);
        }
    }

    private void TriggedBlank(StateController controller)
    {
        Instantiate(blank, controller.playerGameObject.transform.position, new Quaternion());
    }


    public override void Reset(StateController controller)
    {
        triggered = false;
    }
}
