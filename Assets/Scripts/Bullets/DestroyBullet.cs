using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {

    //When the gameobject with this script on exits the screen so you can't see it
    //Destroy it
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
