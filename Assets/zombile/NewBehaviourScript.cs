using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 10;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    void Moves()
    {
        if (player == null)
            return;
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        Moves();
    }
}
