using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{

    public float size = 1;
    public int gridSize = 16;

    private MeshFilter meshFilter;


    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();


        for (int x = 0; x < gridSize + 1; x++)
        {
            for (int y = 0; y < gridSize + 1; y++)
            {
                vertices.Add(new Vector3(-size * 0.5f + size * (x / ((float)gridSize)), 0, -size * 0.5f + size * (y / ((float)gridSize))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }


        List<int> triangles = new List<int>();
        int verticeCount = gridSize + 1;

        for (int i = 0; i < verticeCount * verticeCount - verticeCount; i++)
        {
            if ((i + 1) % verticeCount != 0)
            {
                triangles.AddRange(new List<int>()
                {
                    i + 1 + verticeCount, i + verticeCount, i,
                    i, i + 1, i + verticeCount + 1
                });
            }
        }

        mesh.SetVertices(vertices);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);

        return mesh;
    }
}
