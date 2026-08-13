using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class DroneMovingComponent : MonoBehaviour
{

    private Vector3 direction = new Vector3(0.3f, 0, 0.3f);
    [SerializeField] private Rigidbody rigidBody;

    private Drone drone;

    private void Awake()
    {
        drone = GetComponentInParent<Drone>();

    }
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(rigidBody.position, direction, out hit, 1f))
        {
            if (hit.collider.gameObject.CompareTag("Fence"))
            {
                direction = Vector3.Reflect(direction, hit.normal).normalized;
            }
        }
        Move();
    }

    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + direction * drone.GetDroneRuntimeData().CurrentMovingSpeed * Time.fixedDeltaTime);

    }


}
