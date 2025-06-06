using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class JoystickControl : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] public float _moveSpeed;
    [SerializeField] private ParticleSystem Moving_Lawnmover_Smoke_Particle;
    [SerializeField] public Animator Moving_Lawnmover_Animatior;

    private float IsMoving;
    //  [SerializeField] public Animator Moving_Lawnmover_Animatior;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _rigidbody.linearVelocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.linearVelocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.linearVelocity);
            Moving_Lawnmover_Smoke_Particle.Play(true);
            Moving_Lawnmover_Animatior.SetBool("IsMoving", true);



        }
        else
        {
            Moving_Lawnmover_Animatior.SetBool("IsMoving", false);

        }
    }


}
