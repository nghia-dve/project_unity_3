using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Vector3 target;//Mục tiêu
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCrursor();// look at cursor:nhìn vào con trỏ
    }
    void LookAtCrursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            target = hit.point;
        }

        transform.LookAt(target);//transform : biến đổi
    }
}
