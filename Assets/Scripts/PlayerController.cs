using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float length;
    float xspeed;
    float xdirection;
    float xvector;
    float yspeed;
    float ydirection;
    float yvector;
    public bool overworld;
    //private Collider2D pcollider; 
    private Rigidbody rb; 
    public TopDown_AnimatorController panimator;
    public GameObject door;
    private bool closeEnough = false;
    private bool isGrounded;
    private float jumpForce = 5f;
    private float raycastDistance = 1.0f;
    private float groundCheckDistance = 4.1f;
    public LayerMask floor; 
    GameManager gm; 
    

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld;
        //GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
        xspeed = 4;
        xdirection = 0;
        xvector = 0;
        ydirection = 0;
        yvector = 0;
        panimator = GetComponentInChildren<TopDown_AnimatorController>();
        
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            yspeed = 4;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            yspeed = 0;
        }
    }
    private void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        xvector = xspeed * xdirection * Time.deltaTime;
        ydirection = Input.GetAxis("Vertical");
        yvector = yspeed * ydirection * Time.deltaTime;
        transform.Translate(xvector, yvector, 0);
        isGrounded = CheckIfGrounded();
        //print(isGrounded);
        
        //TODO set this to a raycasthit
        if (Physics.Raycast(transform.position, Vector3.down))
        {
            print("ground");
        }
        Debug.DrawRay(transform.position, Vector3.down);
        if (isGrounded)
        {
            print("grounded");
            if (Input.GetKeyDown(KeyCode.Space))
            {
             Jump();   
            }
        }
        
        if (closeEnough)
        {
            print("close enough");
            if (gm.Axe)
            { 
                if (panimator.IsAttacking)
                {
                    Destroy(door);
                }
            }
            
        }
        
        
    }

    bool CheckIfGrounded()
    {   if (Physics.Raycast(transform.position, Vector3.down))
        {
            return true; 
        }
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CaveDoor"))
        {
            closeEnough = true;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    //for organization, put other built-in Unity functions here
    

    //after all Unity functions, your own functions can go here
}