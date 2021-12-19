using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //khai báo biến lấy giá trị các phím điều hướng trên bàn phím
    // Horizontal:a,d
    // Vertical : w,s

    
    // tham chiếu đến bộ điều khiển nhân vật
    public CharacterController controller;

    //tốc độ di chuyển cửa nhân vật
    public float speed = 10f;

    //biến trọng lực
    public float gravity = -9.8f;

    // độ bật nhảy
    public float jumpHeight = 3f;

    // biến lấy trục toạ độ
    Vector3 velocity;

    //tạo biến lấy đối tượng kiểm tra mặt đất
    public Transform groundCheck;

    //tạo ra biến xác định bán kính hình tròn để check(khoảng cách đến mặt đất)
    public float groundDistance = 0.4f;

    //tạo biến xác định layer là mặt đất
    public LayerMask groundMask;

    //tạo biến kiểm tra
    bool isGroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //kiểm tra vật lý theo hình tròn
        isGroundCheck = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //lấy dữ liệu nhập từ bán phím 
        float x = Input.GetAxis("Horizontal");// horizontal:a,d,<,>
        float z = Input.GetAxis("Vertical");// vertical :w,s,^,v
                                            //float y = Input.GetAxis("Jump");

        // tạo biến xác định hướng mà chúng ta muốn di chuyển (x,z)
        Vector3 move = transform.right * x + transform.forward * z;//right (trái phải) forward(trước sau)
                                                                   // chúng ta không tạo theo cách ở dưới vì ở dướt xác địch toạ độ cố định 
        /*Vector3 move = new Vector3(-x, 0, -z);*/

        // tham chiếu đến bộ điều khiển nhân vật
        controller.Move(move * speed * Time.deltaTime);


        /*velocity.x += x*Time.deltaTime;
        velocity.z += z*Time.deltaTime;
        controller.Move(velocity * speed * Time.deltaTime);*/

        // tạo trọng lực thông qua biến xác định toạ độ y
       
        velocity.y += gravity * Time.deltaTime;
        // công thức deta y=(1/2)*gravity*time^2
        // tiếp tục tham chiếu đến bộ điều khiển nhân vật
        controller.Move(velocity * Time.deltaTime);

        //kiểm tra xem nhân vật có đứng trên mặt đất k
        if (isGroundCheck && velocity.y < 0)
        {
            velocity.y = -2f;
               
        }
        //công thức tính độ cao nhảy v=sqrt(h*2*g)
        if (Input.GetKey(KeyCode.Space) && isGroundCheck)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //thay đổi chiều cao của nhân vật áp dụng cho trường hợp nhân vật ngồi xuống
        if (Input.GetKey(KeyCode.C))
        {
            controller.height = 1.5f;
            speed =1f;
        } 
        else
        {
            controller.height = 2f;
            speed = 10f;
        }
        //thay đổi tốc đọ cảu nhân vậy
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }

    }
}
