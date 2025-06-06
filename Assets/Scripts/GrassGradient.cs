using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGradient : MonoBehaviour

{
    public Vector4 GrassColor;

    // Start is called before the first frame update
    void Start()
    {
        Grass_Changes_color();
    }
    public void Grass_Changes_color()
    {
        Renderer GrassRenderer = GetComponent<Renderer>();
        GrassColor = new Vector4(0, Random.Range(0.5f, 1), 0, Random.Range(0.5f, 1));
        gameObject.GetComponent<Renderer>().material.color = GrassColor;
    }
}
