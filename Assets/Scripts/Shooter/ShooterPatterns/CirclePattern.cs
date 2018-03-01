using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePattern : MonoBehaviour {

    [SerializeField] private GameObject bulletPrefab;

    [Tooltip("List of the points the bullet will shoot from")]
    [SerializeField] private List<Transform> spawnList = new List<Transform>();

    [Tooltip("Will the object start shooting to the right or not")]
    [SerializeField] private bool startDirectionRight = false;

    [Tooltip("Will the object change direction every 360 degrees")]
    [SerializeField] private bool changeEveryWave = false;

    [Tooltip("How fast the object will turn every second")]
    [SerializeField] private float timePerWave = 1;

    [Tooltip("The maxiumu amount of bullets the object will shoot every 360 degrees")]
    [SerializeField] private int bulletsPerWave = 25;

    [Tooltip("How many seconds after the bullet have been created that it will be destroyed")]
    [SerializeField] private int bulletLifeTime = 10;

    [Tooltip("The distance from spawn it will travel when it spawns")]
    [SerializeField]
    private float bulletOffset = 0;


    //Variables not available in the inspector
    //Start
    private float shootTimer = 0;
    private float tempTime = 0;
    private int isRight = 1;
    private int shotsFiredInWave = 0;

    private float firerate;
    //End


	// Use this for initialization
	void Start () {
        if (!startDirectionRight)
        {
            isRight = 1;
        }
        else
        {
            isRight = -1;
        }

        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i] == null)
            {
                spawnList.RemoveAt(i);
                i--;
            }
        }

        if (spawnList.Count == 0)
        {
            spawnList.Add(transform);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //bulletsPerWave = Mathf.Clamp(bulletsPerWave, 0, (int)((float)timePerWave / Time.deltaTime));
        firerate = timePerWave / (float)bulletsPerWave;
        //firerate = Mathf.Clamp(firerate, Time.deltaTime, float.MaxValue);

        tempTime += Time.deltaTime;
        shootTimer += Time.deltaTime;

        //if (shootTimer >= firerate)
        while (shootTimer >= firerate)
        {
            if (changeEveryWave == true
                && shotsFiredInWave >= bulletsPerWave)
            {
                isRight = -isRight;
            }

            if (shotsFiredInWave >= bulletsPerWave)
            {
                shotsFiredInWave = 0;
            }

            Shoot();

            //shootTimer = 0;
            shootTimer -= firerate;
        }
	}

    private void Shoot()
    {
        float rotationPerBullet = 360f / (float)bulletsPerWave;
        Quaternion rotation = Quaternion.Euler(0, 0, (rotationPerBullet * (float)shotsFiredInWave) * isRight);


        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i] != null)
            {
                Vector3 bulletSpawnPosition = spawnList[i].position;
                bulletSpawnPosition += spawnList[i].up * bulletOffset;

                Quaternion bulletRotation = spawnList[i].rotation * rotation;

                var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnPosition, bulletRotation);

                Destroy(bullet, bulletLifeTime);
            }

            else
            {
                spawnList.RemoveAt(i);
                i--;
            }
        }

        shotsFiredInWave++;
    }
}
