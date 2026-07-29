using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RandomSpawningPositionProvider : MonoBehaviour
{
    [Header("Spawn Area")]
    [SerializeField] private Vector3 minCorner;
    [SerializeField] private Vector3 maxCorner;

    [Header("Collision Check")]
    [SerializeField] private float checkRadius = 1f;
    [SerializeField] private LayerMask blockingLayers;

    [Header("Settings")]
    [SerializeField] private int maxAttempts = 20;

    public Vector3 GetRandomPosition()
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 pos = GetRandomPoint();

            if (IsPositionValid(pos))
                return pos;
        }

        Debug.LogWarning("No spawning valid spawn positon found");
        return GetRandomPoint();
    }

    private Vector3 GetRandomPoint()
    {
        float x = Random.Range(minCorner.x, maxCorner.x);
        float y = Random.Range(minCorner.y, maxCorner.y);
        float z = Random.Range(minCorner.z, maxCorner.z);

        return new Vector3(x, y, z);
    }

    private bool IsPositionValid(Vector3 position)
    {
        
        return !Physics.CheckSphere(position, checkRadius, blockingLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 center = (minCorner + maxCorner) / 2;
        Vector3 size = maxCorner - minCorner;

        Gizmos.DrawWireCube(center, size);
    }
}
