using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RandomSpawningPositionProvider : MonoBehaviour
{
    [Header("Spawn Area")]
    [SerializeField] private GameObject minCorner;
    [SerializeField] private GameObject maxCorner;

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
        float x = Random.Range(minCorner.transform.position.x, maxCorner.transform.position.x);
        float y = Random.Range(minCorner.transform.position.y, maxCorner.transform.position.y);
        float z = Random.Range(minCorner.transform.position.z, maxCorner.transform.position.z);

        return new Vector3(x, y, z);
    }

    private bool IsPositionValid(Vector3 position)
    {
        
        return !Physics.CheckSphere(position, checkRadius, blockingLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 center = (minCorner.transform.position + maxCorner.transform.position) / 2;
        Vector3 size = maxCorner.transform.position - minCorner.transform.position;

        Gizmos.DrawWireCube(center, size);
    }
}
