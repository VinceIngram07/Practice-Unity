using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public float waveHeight = 0.1f;
    public float waveSpeed = 1.0f;

    private Vector3[] originalVertices;
    private Mesh mesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
    }

    void Update()
    {
        Vector3[] vertices = originalVertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = Mathf.Sin(Time.time * waveSpeed + vertices[i].x + vertices[i].z) * waveHeight;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}

