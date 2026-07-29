using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridPositionProvider : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;

    int GetIndex(int x, int z)
    {
        int d = x + z;
        return (d * (d + 1)) / 2 + x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = new Vector3(x * cellSize, 0, z * cellSize);

            
                Gizmos.DrawWireCube(pos, Vector3.one * cellSize);

              
                int index = GetIndex(x, z);

#if UNITY_EDITOR
                
                Handles.Label(pos + Vector3.up * 0.2f, index.ToString());
#endif
            }
        }
    }
}
