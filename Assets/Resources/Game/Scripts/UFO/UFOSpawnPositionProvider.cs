
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawningPositionProvider : MonoBehaviour
{


    [System.Serializable]
    private class SpawningZone
    {
        public GameObject[] points;
        public Vector3 direction;
    }

    [SerializeField] private SpawningZone[] spawningZones;

    private SpawningZone currentZone;

    public Vector3 Direction => currentZone.direction;

    public Vector3 GetRandomPosition()
    {
        currentZone = spawningZones[Random.Range(0, spawningZones.Length)];

        Vector3 point1 = currentZone.points[0].transform.position;
        Vector3 point2 = currentZone.points[1].transform.position;

        return new Vector3(
            Random.Range(point1.x, point2.x),
            Random.Range(point1.y, point2.y),
            Random.Range(point1.z, point2.z)
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (var zone in spawningZones)
            DrawZone(zone.points);
    }

    private void DrawZone(GameObject[] zone)
    {
        Vector3 point1 = zone[0].transform.position;
        Vector3 point2 = zone[1].transform.position;

        Vector3 center = (point1 + point2) / 2;
        Vector3 size = point2 - point1;

        Gizmos.DrawWireCube(center, size);
    }
}
