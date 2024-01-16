using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Terrain terrain;
    private MeshRenderer meshRenderer;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        meshRenderer = GetComponent<MeshRenderer>();
        
        if (terrain != null && meshRenderer != null)
        {
            Material material = meshRenderer.sharedMaterial;
            if (material != null)
            {
                material.SetFloat("_EdgeWidth", 0.02f); // Задайте бажану ширину ребер
            }
        }
    }
}
