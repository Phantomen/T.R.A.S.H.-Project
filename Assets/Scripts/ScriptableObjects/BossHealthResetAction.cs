using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/BossHealthReset")]
public class BossHealthResetAction : StateAction {

    private bool triggered = false;

    public override void Act(StateController controller)
    {
        ResetHealth(controller);
    }

    private void ResetHealth(StateController controller)
    {
        if (triggered == false)
        {
            triggered = true;
            TrudgesHealthBar hpBar = controller.GetComponentInChildren<TrudgesHealthBar>();

            hpBar.ResetBar();
        }
    }

    public override void Reset(StateController controller)
    {
        triggered = false;
    }
}
