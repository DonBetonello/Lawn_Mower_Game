using UnityEngine;

public class CloudCreate : MonoBehaviour
{
    private int Spawn_Coordinate_X;
    private int Spawn_Coordinate_Y;
    private int Spawn_Coordinate_Z;
    [SerializeField] private GameObject Cloud_Preset1;
    [SerializeField] private GameObject Cloud_Preset2;
    [SerializeField] private GameObject Cloud_Preset3;
   
    public float Cloud_Respawn_Timer = 0;
    void Update()
    {
       

        Cloud_Respawn_Timer += Time.deltaTime;
        if (Cloud_Respawn_Timer >= 14)
        {
            Vector3 Random_Position1 = new Vector3(Random.Range(10, 25), Random.Range(-9, -15), Random.Range(9, -5));
         
            Instantiate(Cloud_Preset1, Random_Position1, Quaternion.identity);
           
            Vector3 Random_Position2 = new Vector3(Random.Range(10, 25), Random.Range(-9, -15), Random.Range(9, -5));

            Instantiate(Cloud_Preset2, Random_Position2, Quaternion.identity);
           
            Vector3 Random_Position3 = new Vector3(Random.Range(10, 25), Random.Range(-9, -15), Random.Range(9, -5));

            Instantiate(Cloud_Preset3, Random_Position3, Quaternion.identity);
            Cloud_Respawn_Timer = 0;
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
     
    }
}
