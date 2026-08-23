using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UFOMoving : MonoBehaviour
{
    private UFOSpawningPositionProvider ufoSpawningPositionProvider;
    private Vector3 movingDirection;
    private Rigidbody rigidBody;
    
    private void Awake()
    {
        ufoSpawningPositionProvider = FindFirstObjectByType<UFOSpawningPositionProvider>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(ufoSpawningPositionProvider != null) { Move(); }
        
    }

    private void Move()
    {
        movingDirection = ufoSpawningPositionProvider.Direction;
      //  transform.position = transform.position += movingDirection * Time.deltaTime * 2.5f;
        rigidBody.AddForce(movingDirection * Time.deltaTime * 1.5f, ForceMode.Impulse);
    }

  
}
