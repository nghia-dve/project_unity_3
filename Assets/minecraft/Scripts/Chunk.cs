using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *
 */

public class Chunk : MonoBehaviour
{
    // tạo ra biến liên kết của lưới và bộ lọc lưới
    public MeshRenderer meshRenderer;// liên kết bộ lọc
    public MeshFilter meshFilter;// để lưu trữ dữ liệu về các đỉnh

    // Start is called before the first frame update
    void Start()
    {
        // tạo biến lưu trữ chỉ mục để theo dõi các đỉnh
        int vertexIndex = 0;
        // tạo ra 2 danh sách một để lưu trữ đỉnh bằng kiểu vecto, 2 để lưu trữ hình tam giác dùng kiểu int(số nguyên)
        List<Vector3> Verticers = new List<Vector3>();
        List<int> triangles = new List<int>();
        // danh sách ảnh
        List<Vector2> texture = new List<Vector2>();

        for (int j = 0; j < Math.Sqrt(VoxelData.vexelTris.Length); j++)
        {
            for (int i = 0; i < Math.Sqrt(VoxelData.vexelTris.Length); i++)
            {
                Debug.Log("");
                // tạo ra chỉ mục hình tam giác để lưu và liên kết dữ liệu ta tạo ở bến VoxelData
                int triangleIndex = VoxelData.vexelTris[j, i];
                // 
                Verticers.Add(VoxelData.voxelverts[triangleIndex]);
                triangles.Add(vertexIndex);

                texture.Add(VoxelData.voxelUvs[i]);
                vertexIndex++;
            }
        }

        // gắn các toạ độ và các đỉnh vào lưới để vẽ lên
        Mesh mesh = new Mesh();
        mesh.vertices = Verticers.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = texture.ToArray();
        // để làm tránh làm mịn các góc bằng nhau
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

    }

    /*public MeshRenderer meshRenderer;
public MeshFilter meshFilter;

void Start()
{

   int vertexIndex = 0;
   List<Vector3> vertices = new List<Vector3>();
   List<int> triangles = new List<int>();
   List<Vector2> uvs = new List<Vector2>();

   for (int p = 0; p < 6; p++)
   {
       for (int i = 0; i < 6; i++)
       {

           int triangleIndex = VoxelData.voxelTris[p, i];
           vertices.Add(VoxelData.voxelVerts[triangleIndex]);
           triangles.Add(vertexIndex);

           //uvs.Add(VoxelData.voxelUvs[i]);

           vertexIndex++;

       }
   }

   Mesh mesh = new Mesh();
   mesh.vertices = vertices.ToArray();
   mesh.triangles = triangles.ToArray();
   mesh.uv = uvs.ToArray();

   mesh.RecalculateNormals();

   meshFilter.mesh = mesh;

}
*/


}
