using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfDestruction : MonoBehaviour {

    private ParticleSystem parSys;

    List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();

    // Use this for initialization
    void Start () {
        parSys = GetComponent<ParticleSystem>();
	}

    //void OnParticleTrigger()
    //{
    //    int numEnter = parSys.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
    //    Debug.Log(numEnter);

    //    for (int i = 0; i < numEnter; i++)
    //    {
    //        Debug.Log("HIT");
    //    }
    //}

    void OnParticleCollision(GameObject other)
    {
        Destroy(other);
    }
}
