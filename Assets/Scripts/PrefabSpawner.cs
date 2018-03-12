using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {

    [Tooltip("If empty, destroy")]
    [SerializeField]
    private bool destroyWhenEmpty = true;


    [Tooltip("List of prefabs")]
    [SerializeField]
    private List<PrefabSpawn> prefabList = new List<PrefabSpawn>();

    private List<GameObject> spawnedList = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        CheckSpawns();
        SpawnPrefabs();
	}

    void Update()
    {
        if (destroyWhenEmpty == true)
        {
            bool empty = CheckEmpty();

            if (empty == true)
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckSpawns()
    {
        for (int listIndex = 0; listIndex < prefabList.Count; listIndex++)
        {
            bool transformPositionAdded = false;
            for (int spawnIndex = 0; spawnIndex < prefabList[listIndex].spawnList.Count; spawnIndex++)
            {
                if (prefabList[listIndex].spawnList[spawnIndex] != null)
                {
                    if (transformPositionAdded == false)
                    {
                        transformPositionAdded = true;
                        prefabList[listIndex].spawnList[spawnIndex] = transform;
                    }

                    else
                    {
                        prefabList[listIndex].spawnList.RemoveAt(spawnIndex);
                        spawnIndex--;
                    }
                }
            }
        }
    }

    private void SpawnPrefabs()
    {
        for (int listIndex = 0; listIndex < prefabList.Count; listIndex++)
        {
            for (int spawnIndex = 0; spawnIndex < prefabList[listIndex].spawnList.Count; spawnIndex++)
            {
                if (prefabList[listIndex].prefab != null)
                {
                    var spawnedPrefab = (GameObject)Instantiate(prefabList[listIndex].prefab,
                        prefabList[listIndex].spawnList[spawnIndex].position,
                        prefabList[listIndex].spawnList[spawnIndex].rotation);

                    spawnedPrefab.transform.parent = gameObject.transform;

                    spawnedList.Add(spawnedPrefab);
                }
            }
        }
    }


    private bool CheckEmpty()
    {
        bool isEmpty = true;

        for (int i = 0; i < spawnedList.Count; i++)
        {
            if (spawnedList[i] != null)
            {
                isEmpty = false;
                break;
            }

            else
            {
                spawnedList.RemoveAt(i);
                i--;
            }
        }

        return isEmpty;
    }
}


public class PrefabSpawn
{
    public GameObject prefab;

    public List<Transform> spawnList = new List<Transform>();
}
