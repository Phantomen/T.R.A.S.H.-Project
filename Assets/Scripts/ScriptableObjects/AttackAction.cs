using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/AttackAction")]
public class AttackAction : StateAction {

    public ShooterPattern shotPattern;

    //public List<AttackActionBulletSpawnList> bulletSpawnList = new List<AttackActionBulletSpawnList>();
    //private List<Transform> spawnList = new List<Transform>();

    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        shotPattern.Shoot(controller.gameObject);
    }

    public override void Reset(StateController controller)
    {
        ResetShooting(controller);
    }

    private void ResetShooting(StateController controller)
    {
        //spawnList.Clear();

        //GameObjectsTransformList tl = controller.gameObject.GetComponent<GameObjectsTransformList>();

        //if (bulletSpawnList.Count > 0
        //    && tl.transformList.Count > 0
        //    && tl != null)
        //{
        //    for (int pi = 0; pi < bulletSpawnList.Count; pi++)
        //    {
        //        for (int si = 0; si < bulletSpawnList[pi].spawnPointIndex.Length; si++)
        //        {
        //            if (tl.transformList[bulletSpawnList[pi].phaseIndex].bulletSpawnList[bulletSpawnList[pi].spawnPointIndex[si]] != null)
        //            {
        //                bool alreadyInList = false;
        //                for (int t = 0; t < spawnList.Count; t++)
        //                {
        //                    if (spawnList[t] == tl.transformList[bulletSpawnList[pi].phaseIndex].bulletSpawnList[bulletSpawnList[pi].spawnPointIndex[si]])
        //                    {
        //                        alreadyInList = true;
        //                        break;
        //                    }
        //                }

        //                if (alreadyInList == false)
        //                {
        //                    spawnList.Add(tl.transformList[bulletSpawnList[pi].phaseIndex].bulletSpawnList[bulletSpawnList[pi].spawnPointIndex[si]]);
        //                }
        //            }
        //        }
        //    }
        //}

        shotPattern.Reset(controller.gameObject);
        //shotPattern.Reset(controller.gameObject, spawnList);
    }
}

[System.Serializable]
public class AttackActionBulletSpawnList
{
    public int phaseIndex = 0;
    public int[] spawnPointIndex;
}