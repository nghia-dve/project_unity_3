using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public GameObject block;
    public float khoang_cach = 4f;
    float khoang_cach1 = 2f;
    float khoang_cach2 = 1f;
    float khoang_cach3 = 4f;
    public LayerMask groundMask;
    public LayerMask leftMask;
    //public LayerMask spamMask;
    public GameObject ben_trai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ben_trai.tag = "cube";
        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, khoang_cach,leftMask))
            {
                GameObject a = Instantiate(block,  hit.point, Quaternion.identity);
                //Destroy(ben_trai);
                a.transform.position = block.transform.position + new Vector3(0,0,0); 
                //ben_trai.transform.Translate(Vector3.right * -1);
            }    
        }
    }
}
