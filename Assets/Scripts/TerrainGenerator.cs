using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private int terrainSize = 8;

    [SerializeField]
    private int cellSize = 1;


    [SerializeField]
    private float seaLevel = -1;

    [SerializeField]
    private GameObject cell;


    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void GenerateTerrain()
    {
        for (int i = 0; i < terrainSize; i++)
        {
            for (int j = 0; j < terrainSize; j++)
            {
                Transform cellTransform = transform;
                cellTransform.position = new Vector3(i * cellSize, seaLevel, j * cellSize);
                Instantiate(cell, cellTransform.position, cellTransform.rotation);
            }
        }
    }
}
