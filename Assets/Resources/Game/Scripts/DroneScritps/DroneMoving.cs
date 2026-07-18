using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class DroneMovingComponent : MonoBehaviour
{
  
    private Vector3 direction;
    private Vector3 reflectDirection;

    private Drone drone;

    private void Awake()
    {
        drone = GetComponentInParent<Drone>();
    }

    private void Start()
    {
        direction = new Vector3(0.3f, 0, 0.3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsFense>())
        {
            ReflectDirection();
           
        }
    }

    void ReflectDirection()
    {
        direction = reflectDirection;
    }

    private void FixedUpdate()
    {
        //remake drone later
        transform.Translate(direction * drone.GetDroneRuntimeData().CurrentMovingSpeed * Time.deltaTime);

        Ray VectorRay = new Ray(transform.position, direction * 10f);
        RaycastHit VectorHit;
        Debug.DrawRay(transform.position, direction * 10f, Color.red);
        Debug.DrawRay(transform.position, reflectDirection * 100f, Color.blue);
        if (Physics.Raycast(VectorRay, out VectorHit))
        {
            reflectDirection = Vector3.Reflect(direction, VectorHit.normal);
        }
    }


}
