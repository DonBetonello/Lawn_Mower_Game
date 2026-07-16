using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGradient : MonoBehaviour

{
    private Vector4 GrassColor;
    private MaterialPropertyBlock propertyBlock;
    private Renderer GrassRenderer;


    private void Awake()
    {
        GrassRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        Grass_Changes_color();
    }

    private void Grass_Changes_color()
    {
        GrassColor = new Vector4(0, Random.Range(0.5f, 1), 0, Random.Range(0.5f, 1));
          GrassRenderer.GetPropertyBlock(propertyBlock);
          propertyBlock.SetColor("_Color", GrassColor);
          GrassRenderer.SetPropertyBlock(propertyBlock); 
    }
}
