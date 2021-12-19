using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer1 : MonoBehaviour
{
    private float moveSpeed;
    public float minMoveSpeed = 0.05f;
    public float maxMoveSpeed = 0.2f;
    GameObject player;
    GameObject lookattarget;
    // Start is called before the first frame update
    private Animator amin;
    void Start()
    {
        amin = gameObject.GetComponent<Animator>();
        runScreamAmin(false);
        runAmin(false);
        player = GameObject.FindGameObjectWithTag("PlayerTarget");
        lookattarget = GameObject.FindGameObjectWithTag("LookTarget");
        UpdateMoveSpeed();
    }
    void runScreamAmin(bool scream)
    {
        amin.SetBool("Scream 0", scream);
        
    }
    void runAmin(bool run)
    {
        amin.SetBool("Run 0", run);
        
    }
    void UpdateMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }
    void Moves()
    {
        if (player == null )
        {
            
            return;
        }
        runAmin(true);
        
        //transform.LookAt(lookattarget.transform.position);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        
    }
    // Update is called once per frame
    void attack()
    {
        runScreamAmin(false);
        runAmin(false);
        attackAmin(true);
    }
    void basicAttackAmin(bool BasicAttack )
    {
        amin.SetBool("Basic Attack 0", BasicAttack);
    }    
    void attackAmin(bool hornAttack)
    {
        amin.SetBool("HornAttack 0", hornAttack);
            basicAttackAmin(true);
    }
    void Update()
    {
        
        
        if (Vector3.Distance(transform.position,player.transform.position)<5)
        {
            runScreamAmin(false);
            runAmin(false);
            attack();
        }    
        else
        {

            attackAmin(false);
            Moves();
            
        }    
    }

}
