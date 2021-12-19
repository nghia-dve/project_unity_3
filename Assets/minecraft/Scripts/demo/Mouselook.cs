using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    //độ nhạy của chuột
    public float mouseSensitivity = 100f;

    //lấy đội tượng là player
    public Transform playerBody;


    float xRotation = 0f;
    float yRotation = 0f;
    float zRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //tạo biến lấy giá trị trục x và y cảu chuột sau đó
        //kiểm soát tốc đọ của chột bằng cách nhân với biến độ nhạy của chột và
        //nhân với time.deltaTime (là một biến có giá trị rất nhỏ) để mượt mà hơn
        //time.deltatime là khoảng thời gian cuối cùng mà hàm cập nhật đc gọi
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        // để quay xung quanh trục y
        playerBody.Rotate(Vector3.up * mousex);
    }
}
