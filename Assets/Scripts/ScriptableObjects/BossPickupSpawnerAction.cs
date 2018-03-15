using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/BossPickupSpawn")]
public class BossPickupSpawnerAction : StateAction {

    [Tooltip("")]
    [SerializeField]
    private GameObject[] pickupList = new GameObject[5];
    private int currentSpawnIndex = 0;

    private GameObject currentPickupInScene = null; 


    public override void Act(StateController controller)
    {
        if (currentPickupInScene == null
            && currentSpawnIndex < 5)
        {
            SpawnPickups();
        }
    }

    private void SpawnPickups()
    {
        var pickup = (GameObject)Instantiate(pickupList[currentSpawnIndex]);
        currentPickupInScene = pickup;

        currentSpawnIndex++;
    }


    public override void Reset(StateController controller)
    {
        currentSpawnIndex = 0;

        if (currentPickupInScene != null)
            Destroy(currentPickupInScene);

        currentPickupInScene = null;
    }
}
