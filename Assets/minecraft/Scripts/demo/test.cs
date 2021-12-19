using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float x = 10f;
    // Start is called before the first frame update
    void Start()//3
    {
        Debug.Log("start");
        //transform.Translate(Vector3.right * 10 );
    }
    private void OnGUI()//6
    {
        Debug.Log("OnGUI");
    }
    private void Awake()//1
    {
        Debug.Log("Awake");
    }
    private void OnDisable()//8 khi thoát
    {
        Debug.Log("OnDisable");
    }
    private void LateUpdate()//5
    {
        Debug.Log("LateUpdate");
    }
    private void OnEnable()//2
    {

        Debug.Log("OnEnable");
    }
    private void OnApplicationQuit()//7 khi thoát
    {
        Debug.Log("OnApplicationQuit");
    }
    private void OnDestroy()//9 khi thoát
    {
        Debug.Log("OnDestroy");
    }
    

    // Update is called once per frame
    void Update()//4
    {
        Debug.Log("update");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
    }
    private void FixedUpdate()
    {
        Debug.Log("FixUpdate");
    }

}
