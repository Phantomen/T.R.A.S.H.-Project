using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPatternCross : ShooterPattern
{

    [Tooltip("What type of bullet the gameobject will shoot")]
    [SerializeField]
    private GameObject bulletPrefab;

    private List<Transform> spawnList = new List<Transform>();

    [Tooltip("Amount of bullets to be shot every time the object can shoot (split equally around the object so 4 is 1 bullet at 0 degrees, 1 at 90, 1 at 180 and 1 at 270)")]
    [SerializeField]
    private int bulletsPerWave = 4;

    [Tooltip("Amount of times the gameobject will shoot every second")]
    [SerializeField]
    private float fireRate = 1;

    [Tooltip("Amount of seconds before the bullet will get destroyed")]
    [SerializeField]
    private float destroyTime = 5f;

    [Tooltip("Degrees per second in which the bullets will rotate out of the gameobject (0 for no rotation)")]
    [SerializeField]
    private float rotateSpeed = 0f;

    [Tooltip("Distance from center the bullet will spawn")]
    [SerializeField]
    private float distanceFromCenter = 0f;

    private float shootTimer = 0f;
    private float rotateTimer = 0f;
    private float actualRotation = 0f;



    public override void Shoot(GameObject shooterGameObject)
    {
        fireRate = Mathf.Clamp(fireRate, float.Epsilon, float.MaxValue);
        bulletsPerWave = Mathf.Clamp(bulletsPerWave, 1, int.MaxValue);
        shootTimer += Time.deltaTime * fireRate;

        if (shootTimer >= 1)
        {
            rotateTimer += rotateSpeed / fireRate;
            ShootPattern();
        }
    }


    private void ShootPattern()
    {
        for (int si = 0; si < spawnList.Count; si++)
        {
            for (int i = 0; i < bulletsPerWave; i++)
            {
                actualRotation += (360f / (float)bulletsPerWave);
                Quaternion rotation = Quaternion.Euler(0, 0, actualRotation + rotateTimer);
                Vector3 bulletPosition = spawnList[si].position;

                if (actualRotation > 360)
                {
                    actualRotation -= 360;
                }

                var bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, rotation * spawnList[si].rotation);
                bullet.transform.position += bullet.transform.up * distanceFromCenter;

                Destroy(bullet, destroyTime);
            }
        }
        shootTimer -= 1;
    }


    public override void Reset(GameObject shooterGameObject)
    {
        spawnList.Clear();

        GameObjectsTransformList tl = shooterGameObject.GetComponent<GameObjectsTransformList>();


        if (bulletSpawnList.Count > 0
            && tl.transformList.Count > 0
            && tl != null)
        {
            for (int pi = 0; pi < bulletSpawnList.Count; pi++)
            {
                for (int si = 0; si < bulletSpawnList[pi].spawnPointIndex.Length; si++)
                {
                    if (tl.transformList[bulletSpawnList[pi].phaseIndex].bulletSpawnList[bulletSpawnList[pi].spawnPointIndex[si]] != null)
                    {
                        bool alreadyInList = false;
                        for (int t = 0; t < spawnList.Count; t++)
                        {
                            if (spawnList[t] == tl.transformList[bulletSpawnList[pi].phaseIndex].bulletSpawnList[bulletSpawnList[pi].spawnPointIndex[si]])
                            {
                                alreadyInList = true;
                                break;
                            }
                        }

                        if (alreadyInList == false)
                        {
                            spawnList.Add(tl.transformList[bulletSpawnList[pi].phaseIndex].bulletSpawnList[bulletSpawnList[pi].spawnPointIndex[si]]);
                        }
                    }
                }
            }
        }

        if (spawnList.Count == 0)
        {
            spawnList.Add(shooterGameObject.transform);
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
            spawnList.Add(shooterGameObject.transform);
        }

        bulletsPerWave = Mathf.Clamp(bulletsPerWave, 1, int.MaxValue);
        actualRotation = -(360f / (float)bulletsPerWave);

        fireRate = Mathf.Clamp(fireRate, float.Epsilon, float.MaxValue);
        rotateTimer = -rotateSpeed / fireRate;

        shootTimer = 1;
    }

    //public override void Reset(GameObject shooterGameObject, List<Transform> bulletSpawnList)
    //{
    //    spawnList = bulletSpawnList;

    //    if (spawnList.Count == 0)
    //    {
    //        spawnList.Add(shooterGameObject.transform);
    //    }
    //}
}
