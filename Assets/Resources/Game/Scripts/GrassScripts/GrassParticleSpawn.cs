using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] GrassParticles;

    void OnTriggerEnter(Collider collision)
    {
       int RandomParticle = Random.Range(1, 4);

        switch (RandomParticle)
        {
            case 1:
                Instantiate(GrassParticles[0], transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0), new Vector3(0, 90, 0)));
                break;
            case 2:
                Instantiate(GrassParticles[1], transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0), new Vector3(0, 90, 0)));
                break;
            case 3:
                Instantiate(GrassParticles[2], transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0), new Vector3(0, 90, 0)));
                break;

        }

    }
}
