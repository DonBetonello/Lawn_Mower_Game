using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class DroneMovingScript : MonoBehaviour
{

    private Vector3 direction;
    private Vector3 reflectDirection;
    private bool Isfence = false;
    [SerializeField] private Upgrades upgrades;

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

        transform.Translate(direction * upgrades.DroneSpeedUpgradeData.Value * Time.deltaTime);
        Ray VectorRay = new Ray(transform.position, direction * 10f);
        RaycastHit VectorHit;
        Debug.DrawRay(transform.position, direction * 10f, Color.red);
        Debug.DrawRay(transform.position, reflectDirection * 100f, Color.blue);
        if (Physics.Raycast(VectorRay, out VectorHit))
        {
            reflectDirection = Vector3.Reflect(direction, VectorHit.normal);
        }
        if (VectorHit.collider.GetComponent<IsFense>())
        {
            Isfence = true;
        }

    }


}
