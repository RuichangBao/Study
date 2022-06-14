using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Mesh mesh;
    public int num = 8;
    public float angle = 90;
    public float length = 1;
    void Start()
    {
        mesh = this.gameObject.AddComponent<MeshFilter>().mesh;
    }
    private void Update()
    {
        this.DrawFan();
    }
    private void DrawFan()
    {
        //弧度
        float radian = Mathf.Deg2Rad * angle;
        Vector3[] vertices = new Vector3[num + 2];
        vertices[0] = Vector3.zero;
        for (int i = 0; i <= num; i++)
        {
            float tempRadian = -radian / 2 + (i) * radian / num;
            float x = length * Mathf.Sin(tempRadian);
            float z = length * Mathf.Cos(tempRadian);
            vertices[i + 1] = new Vector3(x, 0, z);
        }
        mesh.vertices = vertices;

        List<int> triangles = new List<int>();

        for (int i = 0; i < num; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i + 2);
        }
        mesh.triangles = triangles.ToArray();
        //mesh.RecalculateNormals();
        //mesh.RecalculateBounds();
    }
}