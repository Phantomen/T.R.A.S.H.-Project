using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/BossPickupSpawn")]
public class BossPickupSpawnerAction : StateAction {

    [Tooltip("")]
    [SerializeField]
    private GameObject[] pickupList = new GameObject[5];
    private int currentSpawnIndex = 0;

    [Tooltip("The delay before the first spawn")]
    [SerializeField]
    private float startDelay = 0;
    private float currentTime = 0;

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
        if (currentTime < startDelay)
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= startDelay)
        {
            var pickup = (GameObject)Instantiate(pickupList[currentSpawnIndex]);
            currentPickupInScene = pickup;

            currentSpawnIndex++;
        }
    }


    public override void Reset(StateController controller)
    {
        currentTime = 0;

        currentSpawnIndex = 0;

        if (currentPickupInScene != null)
            Destroy(currentPickupInScene);

        currentPickupInScene = null;
    }
}
