using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagTriggerRandomShooter : MonoBehaviour {

    [Tooltip("The objects to spawn")]
    [SerializeField]
    private List<GameObject> spawnObjectPrefab = new List<GameObject>();

    //[Tooltip("The objects to spawn")]
    //[SerializeField]
    //private List<Transform> spawnPositionsTransforms = new List<Transform>();


    [Tooltip("The delay between each spawn")]
    [SerializeField]
    private float spawnDelay = 0.5f;


    [Tooltip("Delay before it starts spawning")]
    [SerializeField]
    private float startSpawnDelay = 0f;

    private Timer currentDelay;


    [Tooltip("The tags that triggers the shooter")]
    [SerializeField]
    private string[] triggerTags;


    [Tooltip("The random X-position from spawnObject")]
    [SerializeField]
    private float xLocalPositionLimitOffset;

    [Tooltip("The random Y-position from spawnObject")]
    [SerializeField]
    private float yLocalPositionLimitOffset;


    [Tooltip("Max degrees")]
    [SerializeField]
    private float maxDegreesFromCenter = 45;

    [Tooltip("Min degrees at end point")]
    [SerializeField]
    private float minDegreesFromCenter = 0;

    [Tooltip("The random degree gets lower at the closer to the end points in the ")]
    [SerializeField]
    private bool degreeChangeCloserToEndPoints = true;

    [Tooltip("Time until destroyed")]
    [SerializeField]
    private float destroyTime = 5;


    private bool triggered = false;

    private bool currentlySpawning;



    // Use this for initialization
    void Start()
    {
        currentDelay = new Timer(startSpawnDelay, 0);

        xLocalPositionLimitOffset = Mathf.Clamp(xLocalPositionLimitOffset, 0, float.MaxValue);
        maxDegreesFromCenter = Mathf.Clamp(maxDegreesFromCenter, 0, 360);
        minDegreesFromCenter = Mathf.Clamp(minDegreesFromCenter, -360, 360);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xLocalPositionLimitOffset = Mathf.Clamp(xLocalPositionLimitOffset, 0, float.MaxValue);
        maxDegreesFromCenter = Mathf.Clamp(maxDegreesFromCenter, 0, 360);
        minDegreesFromCenter = Mathf.Clamp(minDegreesFromCenter, -360, 360);

        if (true)
        //if (triggered == true)
        {
            currentDelay.Time += Time.deltaTime;

            while (currentDelay.Expired == true)
            {
                currentDelay.Time -= currentDelay.Duration;

                if (currentDelay.Duration != spawnDelay)
                {
                    currentDelay.Duration = spawnDelay;
                }

                Spawn();
            }
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnObjectPrefab.Count; i++)
        {
            if (spawnObjectPrefab[i] != null)
            {
                float xPositionOffset = -0.001f;//Random.Range(-xLocalPositionLimitOffset, xLocalPositionLimitOffset);
                float yPositionOffset = Random.Range(-yLocalPositionLimitOffset, yLocalPositionLimitOffset);

                float newRot = Random.Range(-maxDegreesFromCenter, maxDegreesFromCenter);

                if (degreeChangeCloserToEndPoints == true && xLocalPositionLimitOffset > 0)
                {
                    if (xPositionOffset > 0)
                    {
                        float multX = xPositionOffset / xLocalPositionLimitOffset;
                        float degreeChange = maxDegreesFromCenter + Mathf.Sqrt(Mathf.Pow(minDegreesFromCenter, 2));

                        degreeChange = degreeChange - degreeChange * multX;

                        degreeChange = minDegreesFromCenter + degreeChange;

                        newRot = Random.Range(degreeChange, maxDegreesFromCenter);
                    }

                    else if (xPositionOffset < 0)
                    {
                        float multX = xPositionOffset / -xLocalPositionLimitOffset;
                        float degreeChange = maxDegreesFromCenter + Mathf.Sqrt(Mathf.Pow(minDegreesFromCenter, 2));

                        degreeChange = degreeChange - degreeChange * multX;

                        degreeChange = minDegreesFromCenter + degreeChange;
                        Debug.Log(degreeChange);

                        newRot = -1 * Random.Range(degreeChange, maxDegreesFromCenter);
                    }
                }

                ShootBullet(new Vector2(xPositionOffset, yPositionOffset),
                    Quaternion.Euler(0, 0, newRot),
                    spawnObjectPrefab[i]);
            }
        }
    }

    private void ShootBullet(Vector2 offset, Quaternion newRotation, GameObject bulletPrefab)
    {
        Vector3 newPos = transform.position + new Vector3(offset.x, offset.y, 0);
        var bullet = (GameObject)Instantiate(bulletPrefab, newPos, newRotation * transform.rotation);

        Destroy(bullet, destroyTime);
    }
}
