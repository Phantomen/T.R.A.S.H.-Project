using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagTriggerRandomShooter : MonoBehaviour {

    private bool triggered = false;

    [Tooltip("The objects to spawn")]
    [SerializeField]
    private List<GameObject> spawnObjectPrefab = new List<GameObject>();

    //[Tooltip("The objects to spawn")]
    //[SerializeField]
    //private List<Transform> spawnPositionsTransforms = new List<Transform>();


    [Tooltip("Bullets fired per second")]
    [SerializeField]
    private float firerate = 1f;


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


    [Tooltip("The random degree gets lower at the closer to the end points in the ")]
    [SerializeField]
    private bool degreeChangeCloserToEndPoints = true;

    [Tooltip("Max degrees")]
    [SerializeField]
    private float maxDegreesFromCenter = 45;

    [Tooltip("Min degrees at end point")]
    [SerializeField]
    private float minDegreesFromCenter = 0;


    [Tooltip("Time until destroyed")]
    [SerializeField]
    private float destroyTime = 5;

    private bool currentlySpawning;



    // Use this for initialization
    void Start()
    {
        currentDelay = new Timer(startSpawnDelay, 0);

        xLocalPositionLimitOffset = Mathf.Clamp(xLocalPositionLimitOffset, 0, float.MaxValue);
        maxDegreesFromCenter = Mathf.Clamp(maxDegreesFromCenter, 0, 360);
        minDegreesFromCenter = Mathf.Clamp(minDegreesFromCenter, -360, 360);
        firerate = Mathf.Clamp(firerate, float.MinValue, float.MaxValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xLocalPositionLimitOffset = Mathf.Clamp(xLocalPositionLimitOffset, 0, float.MaxValue);
        maxDegreesFromCenter = Mathf.Clamp(maxDegreesFromCenter, 0, 360);
        minDegreesFromCenter = Mathf.Clamp(minDegreesFromCenter, -360, 360);
        firerate = Mathf.Clamp(firerate, float.MinValue, float.MaxValue);


        if (triggered == true)
        {
            currentDelay.Time += Time.deltaTime;

            while (currentDelay.Expired == true)
            {
                currentDelay.Time -= currentDelay.Duration;

                if (currentDelay.Duration != (1 / firerate))
                {
                    currentDelay.Duration = 1 / firerate;
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
                //Offset
                float xPositionOffset = Random.Range(-xLocalPositionLimitOffset, xLocalPositionLimitOffset);
                float yPositionOffset = Random.Range(-yLocalPositionLimitOffset, yLocalPositionLimitOffset);

                //Rotation of bullet
                float newRot = Random.Range(-maxDegreesFromCenter, maxDegreesFromCenter);

                if (degreeChangeCloserToEndPoints == true && xLocalPositionLimitOffset > 0)
                {
                    if (xPositionOffset > 0)
                    {
                        float multX = xPositionOffset / xLocalPositionLimitOffset;

                        float degreeChange = (minDegreesFromCenter * multX) - (maxDegreesFromCenter * (1 - multX));

                        newRot = Random.Range(degreeChange, maxDegreesFromCenter);
                    }

                    else if (xPositionOffset < 0)
                    {
                        float multX = xPositionOffset / -xLocalPositionLimitOffset;

                        float degreeChange = (minDegreesFromCenter * multX) - (maxDegreesFromCenter * (1 - multX));

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered == false)
        {
            for (int i = 0; i < triggerTags.Length; i++)
            {
                if (collision.tag == triggerTags[i])
                {
                    triggered = true;
                    break;
                }
            }
        }
    }
}
