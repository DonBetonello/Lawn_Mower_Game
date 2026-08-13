using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class LawnMoverMovement: MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [Header("Movement Settings")]
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float rotationSpeed = 10f;
 
    private Stat statsManager;

    private Vector3 currentVelocity;

    private void Awake()
    {
        statsManager = FindFirstObjectByType<Stat>();
    }

    private void FixedUpdate()
    {
        maxSpeed = statsManager.GetStat(StatType.LawnMoverSpeed);

        Vector3 input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

     
        if (input.magnitude > 0.1f)
        {
            
            Vector3 targetDirection = input.normalized;

             
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );

   
            Vector3 targetVelocity = transform.forward * maxSpeed;

        
            currentVelocity = Vector3.Lerp(
                currentVelocity,
                targetVelocity,
                acceleration * Time.fixedDeltaTime
            );
            GameplayEventBus.RaiseLawnMoverStartedMoving();
        }
        else
        {
            
            currentVelocity = Vector3.Lerp(
                currentVelocity,
                Vector3.zero,
                acceleration * Time.fixedDeltaTime
            );
            GameplayEventBus.RaiseLawnMoverStoppedMoving();
        }

        _rigidbody.linearVelocity = new Vector3(
            currentVelocity.x,
            _rigidbody.linearVelocity.y,
            currentVelocity.z
            
        );
    }
}
