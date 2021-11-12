using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWaves : MonoBehaviour
{
    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;


    private float xOffset;
    private float yOffset;
    private MeshFilter meshFilter;



    // Start is called before the first frame update
    void Start()
    {
        meshFilter.GetComponent<MeshFilter>();
        CreateWaves();

    }

    // Update is called once per frame
    void Update()
    {
        CreateWaves();
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;
    }

    void CreateWaves()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
        }

        meshFilter.mesh.vertices = vertices;

    }

    float CalculateHeight(float x, float y)
    {
        float xCoordinate = x * scale + xOffset;
        float yCoordinate = y * scale + yOffset;

        return Mathf.PerlinNoise(xCoordinate, yCoordinate);
    }
}
