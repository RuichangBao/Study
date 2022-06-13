using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
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
        vertices[0] = new Vector3(0,0,0);
        vertices[1] = new Vector3(1,0,0);
        vertices[2] = new Vector3(2,0,0);
        vertices[3] = new Vector3(3,0,0);
        vertices[4] = new Vector3(0, 1, 0);
        vertices[5] = new Vector3(1, 1, 0);
        vertices[6] = new Vector3(2, 1, 0);
        vertices[7] = new Vector3(3,1, 0);
        //vertices[4] = new Vector3(0, 1, 0);
        //vertices[5] = new Vector3(1, 1, 0);
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 
            1,5,6,1,6,2,
            2,6,7,2,7,3,
            0,4,5,0,5,1};

        //mesh.RecalculateNormals();
        //mesh.RecalculateBounds();
    }
    // Update is called once per frame
    void Update()
    {

    }
}