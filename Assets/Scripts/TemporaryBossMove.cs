using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryBossMove : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;
    public float movementSpeed;
 
    void FixedUpdate()
    {
        //Moves object script is on back and forth between the two values at the given speed
        transform.position = new Vector3(Mathf.PingPong(Time.time * movementSpeed, max - min) + min,transform.position.y , transform.position.z);

    }

}
