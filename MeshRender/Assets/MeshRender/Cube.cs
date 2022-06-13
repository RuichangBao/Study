using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Mesh mesh;
    void Start()
    {
        mesh = this.gameObject.AddComponent<MeshFilter>().mesh;
        this.DrawFan();
    }
    private void DrawFan()
    {
        Vector3[] vertices = new Vector3[8];
        vertices[0] = new Vector3(0.5f, -0.5f, -0.5f);
        vertices[1] = new Vector3(0.5f, 0.5f, -0.5f);
        vertices[2] = new Vector3(-0.5f, 0.5f, -0.5f);
        vertices[3] = new Vector3(-0.5f, -0.5f, -0.5f);
        vertices[0] = new Vector3(0.5f, -0.5f, 0.5f);
        vertices[1] = new Vector3(0.5f, 0.5f, 0.5f);
        vertices[2] = new Vector3(-0.5f, 0.5f, 0.5f);
        vertices[3] = new Vector3(-0.5f, -0.5f, 0.5f);
        //vertices[4] = new Vector3(0, 1, 0);
        //vertices[5] = new Vector3(1, 1, 0);
        mesh.vertices = vertices;

        int[] triangles = new int[] { 0, 5,1, 1, 5, 6, 1, 6, 2, 2, 6, 3, 2, 3, 3, 7, 4, 3, 4, 0, 4, 5, 6, 4, 6, 7, 0, 1, 2, 1, 2, 3 };

        mesh.triangles = triangles;
        //mesh.RecalculateNormals();
        //mesh.RecalculateBounds();
    }
    // Update is called once per frame
    void Update()
    {

    }
}