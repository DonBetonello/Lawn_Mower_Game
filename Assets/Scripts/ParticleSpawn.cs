using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    
    [SerializeField] private GameObject GrassParticle1;
    [SerializeField] private GameObject GrassParticle2;
    [SerializeField] private GameObject GrassParticle3;
    private int RandomParticle;

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {   
        
        
        RandomParticle = Random.Range(1, 4);
        if (RandomParticle == 1)
        {
            Instantiate(GrassParticle1, transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0), new Vector3(0, 90, 0)));
        }
        if (RandomParticle == 2)
        {
            Instantiate(GrassParticle2, transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0), new Vector3(0, 90, 0)));
        }
        if (RandomParticle == 3)
        {
            Instantiate(GrassParticle3, transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0), new Vector3(0, 90, 0)));
        }        
    }
  
}
