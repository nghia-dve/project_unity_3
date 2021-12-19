////////////////////////////////////////////////////////////////note
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Voxe là gì:
 * (trong mô hình hóa dựa trên máy tính hoặc mô phỏng đồ họa) 
 * từng mảng trong số các phần tử có khối lượng tạo thành một không gian ba chiều danh nghĩa, 
 * đặc biệt là từng mảng trong số các phần tử rời rạc trong đó phân chia biểu diễn của một đối tượng ba chiều
 */
// chúng ta sẽ tạo ra một lớp tĩnh để lưu trữ dữ liệu và truy cập dữ liệu ở mọi nơi
public static class VoxelData
{
    // tạo ra một mảng tĩnh và set cho mảng đó chỉ đọc dữ liệu chữ không thay đổi được dữ liệu bên tron
    // độ dìa là 8 vì nó lưu trữ toạ độ các đỉnh của hình lập phương
    public static readonly Vector3[] voxelverts = new Vector3[8]
        {
            new Vector3(0.0f,0.0f,0.0f),// 0 đỉnh năm trên gốc toạ độ
            new Vector3(1.0f,0.0f,0.0f),// 1 đỉnh nằm trên ox
            new Vector3(0.0f,1.0f,0.0f),//2 đỉnh nằm trên oy
            new Vector3(0.0f,0.0f,1.0f),//3 đỉnh nằm trên oz
            new Vector3(1.0f,1.0f,0.0f),//4 đỉnh nằm trên mp oxy
            new Vector3(1.0f,0.0f,1.0f),//5 đỉnh nằm trên mp oxz
            new Vector3(0.0f,1.0f,1.0f),//6 đỉnh nằm trên mp oyz
            new Vector3(1.0f,1.0f,1.0f)//7 đỉnh nằm trên mp oxyz
            /*new Vector3(0.0f,0.0f,0.0f),
            new Vector3(1.0f,0.0f,0.0f),
            new Vector3(1.0f,1.0f,0.0f),
            new Vector3(0.0f,1.0f,0.0f),
            new Vector3(0.0f,0.0f,1.0f),
            new Vector3(1.0f,0.0f,1.0f),
            new Vector3(1.0f,1.0f,1.0f),*/
        };
    // tương tự tạo ra mảng vexelTris để lưu trữ toạ độ (tạo chỉ mục) vẽ các mặt của hình lập phương
    // chúng ta dùng mảng 2 chiều
    public static readonly int[,] vexelTris = new int[6, 6]
    {
        { 0, 2, 1, 1, 2, 4 }, // top Face right after
        { 3, 6, 0, 0, 6, 2 }, // right after left after
        { 2, 6, 4, 4, 6, 7 }, // left after top Face
        { 1, 5, 0, 0, 5, 3 }, //bottom
        { 1, 4, 5, 5, 4, 7 }, //right first 
        { 5, 7, 3, 3, 7, 6 } //left first 
        
    };

    public static readonly Vector2[] voxelUvs = new Vector2[6] {

        new Vector2 (0.0f, 0.0f),
        new Vector2 (0.0f, 1.0f),
        new Vector2 (1.0f, 0.0f),
        new Vector2 (1.0f, 0.0f),
        new Vector2 (0.0f, 1.0f),
        new Vector2 (1.0f, 1.0f)

    };

}
    /*
     * tạo ra một scripts khác để liên kết đến dữ liệu này sử dụng chuck 
     */