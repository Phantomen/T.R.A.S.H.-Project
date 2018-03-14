using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/BossHealthReset")]
public class BossHealthResetAction : StateAction {

    public override void Act(StateController controller)
    {
        ResetHealth(controller);
    }

    private void ResetHealth(StateController controller)
    {
        TrudgesHealthBar hpBar = controller.GetComponentInChildren<TrudgesHealthBar>();

        hpBar.ResetBar();
    }

    public override void Reset(StateController controller)
    {
        ResetHealth(controller);
    }
}
