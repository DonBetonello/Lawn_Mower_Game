using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CloudsMoving : MonoBehaviour
{
    private int random_Speed;
    private void Update()
    {
     //   random_Speed = Random.Range(1, 4); 
        transform.Translate(Vector3.left * Random.Range(1, 2) * Time.deltaTime);
    
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cloud_Destroy_Wall")
        {
            Destroy(gameObject);
        }
        
    }
}
