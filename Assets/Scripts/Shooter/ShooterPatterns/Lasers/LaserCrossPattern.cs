using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrossPattern : MonoBehaviour {
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject warningLaser;
    [SerializeField] private AudioClip activeLaserSound;
    [SerializeField] private Vector3 distanceFromCenter;
    [SerializeField] private int laserAmount = 4;
    [SerializeField] private int angleOffset = 360;
    [SerializeField] private float startingRotation = 0;
    [SerializeField] private float maxSize;
    [SerializeField] private float growthSpeed;
    [SerializeField] private bool EnableRotation = false;
    [SerializeField] private bool startRotatingRight = true;
    [SerializeField] private float timeBeforeStart = 5f;
    [SerializeField] private float timePerPause = 3f;
    [SerializeField] private float laserStopTimer = 2f;
    [SerializeField] private float turnSpeed = 3f;
    Vector3 currentPos;
    List<GameObject> laserList = new List<GameObject>();
    List<GameObject> warningLaserList = new List<GameObject>();
    float extractTimer;
    float tempCurrentTime = 0f;
    float laserPauseTimer = 0f;
    float timerBeforeStart;
    bool laserSpawned = false;
    bool warningLaserSpawned = true;
    bool timerGo;
    bool firstTimeSpawned = true;
    int angle = 0;

    float tempStopTimer;

    // Use this for initialization
    void Start()
    {
        spawnWarningLaser();
        //Laser();
        tempStopTimer = laserStopTimer;
        timerBeforeStart = timeBeforeStart;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerBeforeStart <= 0)
        {
            extractTimer += Time.deltaTime * growthSpeed;
            if (!laserSpawned)
            {
                Laser();
            }

            if (timerGo)
            {
                laserPauseTimer += Time.deltaTime;
                tempCurrentTime += Time.deltaTime;
            }

            if (laserPauseTimer >= timePerPause && EnableRotation)
            {
                if (laserStopTimer <= 0)
                {
                    laserPauseTimer = 0;
                    laserStopTimer = tempStopTimer;
                    //timerBeforeStart = timeBeforeStart;
                }
                else
                {
                    for (int i = 0; i < laserAmount; i++)
                    {
                        rotateLaser(laserList[i], false);
                        retractLaser(laserList[i]);
                    }
                    if(!warningLaserSpawned)
                    {
                        laserPrefab.GetComponent<AudioSource>().Stop();
                        spawnWarningLaser();
                        warningLaserSpawned = true;
                    }
                    laserStopTimer -= Time.deltaTime;
                }
            }
            else
            {
                laserPrefab.GetComponent<AudioSource>().Play();
                for (int i = 0; i < laserAmount; i++)
                {
                    extractLaser(laserList[i]);
                    warningLaserSpawned = false;
                    //Destroy(warningLaserList[i]);
                    //warningLaserList.Remove(warningLaserList[i]);
                }
                destroyWarningLaser();

                if (EnableRotation)
                {
                    for (int i = 0; i < laserAmount; i++)
                    {
                        rotateLaser(laserList[i], true);
                    }
                }
            }
        }
        else
        {
            timerBeforeStart -= Time.deltaTime;
        }
    }

    void Laser()
    {
        for (int i = 0; i < laserAmount; i++)
        {
            angle += angleOffset / laserAmount;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector3 laserPosition = new Vector3(this.transform.position.x + distanceFromCenter.x, this.transform.position.y + distanceFromCenter.y, this.transform.position.z + distanceFromCenter.z);
            var laser = (GameObject)Instantiate(laserPrefab, laserPosition, rotation);
            laserList.Add(laser);
        }
        angle = 0;
        firstTimeSpawned = false;
        laserSpawned = true;
    }

    void spawnWarningLaser()
    {
        for (int i = 0; i < laserAmount; i++)
        {
            angle += angleOffset / laserAmount;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector3 laserPosition = new Vector3(this.transform.position.x + distanceFromCenter.x, this.transform.position.y + distanceFromCenter.y, this.transform.position.z + distanceFromCenter.z);
            if (!firstTimeSpawned)
            {
                var laser = (GameObject)Instantiate(warningLaser, laserPosition, laserList[i].transform.rotation);
                warningLaserList.Add(laser);
            }
            else
            {
                var laser = (GameObject)Instantiate(warningLaser, laserPosition, rotation);
                warningLaserList.Add(laser);
            }
        }
    }

    void destroyWarningLaser()
    {
        if (warningLaserList.Count != 0)
        {
            for (int i = 0; i < laserAmount; i++)
            {
                Destroy(warningLaserList[i]);
            }
            warningLaserList.Clear();
        }
    }

    void extractLaser(GameObject laser)
    {
        laserPrefab.gameObject.GetComponent<AudioSource>().clip = activeLaserSound;
        laserPrefab.gameObject.GetComponent<AudioSource>().Play();
        if (laser.transform.localScale.x <= maxSize)
        {
            laser.transform.localScale = new Vector3(laser.transform.localScale.x + (Time.deltaTime * growthSpeed), 1, 1);
        }
    }

    void retractLaser(GameObject laser)
    {
        laserPrefab.gameObject.GetComponent<AudioSource>().Stop();
        if (laser.transform.localScale.x >= 0.01)
        {
            laser.transform.localScale = new Vector3(laser.transform.localScale.x - (Time.deltaTime * growthSpeed), 1, 1);
        }
    }

    void rotateLaser(GameObject laser, bool willRotate)
    {
        if (willRotate)
        {
            if (startRotatingRight)
            {
                timerGo = true;              
                float degrees = Time.deltaTime * turnSpeed;
                Quaternion rotZ = new Quaternion();
                rotZ.eulerAngles = new Vector3(0, 0, laser.transform.rotation.eulerAngles.z + degrees);
                laser.transform.rotation = rotZ;
            }
            else
            {
                timerGo = true;
                float degrees = Time.deltaTime * turnSpeed;
                Quaternion rotZ = new Quaternion();
                rotZ.eulerAngles = new Vector3(0, 0, laser.transform.rotation.eulerAngles.z - degrees);
                laser.transform.rotation = rotZ;
            }
        }
        else
        {
            timerGo = false;
        }
    }
}
