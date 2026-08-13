using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnCreator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Grass[] grassPrefabs;
    [SerializeField] private Transform parent;
    [SerializeField] private Stat statsManager;

    [Header("Settings")]
    [SerializeField] private float cellSize;

    private Dictionary<Vector2Int, Grass> grassDictionary = new();

   
    public IEnumerator GenerateLawn(int lawnHeight, int lawnWidth)
    {
        for (int x = 0; x < lawnHeight; x++)
        {
            for (int z = 0; z < lawnWidth; z++)
            {
                Vector2Int gridPosition = new Vector2Int(x, z);

                Vector3 worldPosition = new Vector3(
                    x * cellSize,
                    0,
                    z * cellSize
                );

          
                if (grassDictionary.TryGetValue(gridPosition, out Grass grass))
                {
                 
                    grass.transform.localPosition = worldPosition;

             
                    grass.SetGridPosition(x, z);

                    continue;
                }

              
                CreateGrass(gridPosition, worldPosition);
                yield return new WaitForEndOfFrame();
            }
        }
    }


    private void CreateGrass(Vector2Int gridPosition, Vector3 position)
    {
        int randomGrass = Random.Range(0, grassPrefabs.Length);

        Grass grass = Instantiate(
            grassPrefabs[randomGrass],
            parent
        );

        grass.transform.localPosition = position;

        grass.SetGridPosition(
            gridPosition.x,
            gridPosition.y
        );

        grass.Init(statsManager);

        grassDictionary.Add(gridPosition, grass);
    }


    public List<Grass> GetGrassList()
    {
        return new List<Grass>(grassDictionary.Values);
    }
}


