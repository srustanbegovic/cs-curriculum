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
    private Rigidbody2D rb; 
    public TopDown_AnimatorController panimator;
    public GameObject door;
    private bool closeEnough = false;
    private bool isGrounded;
    private float jumpForce = 0.1f;
    //private float raycastDistance = 1.0f;
    public float groundCheckDistance = 1f;
    private float jumpCooldown = 0.4f;
    public LayerMask floor; 
    GameManager gm; 
    

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld;
        //GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
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
            GetComponent<Rigidbody2D>().gravityScale = 2;
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
        CheckIfGrounded();
        jumpCooldown -= Time.deltaTime;
        //print(isGrounded);
        Debug.DrawRay(transform.position, Vector3.down);
        if (isGrounded)
        {
            print("grounded");
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumpCooldown < 0)
                {
                    print("Pressed Jump");
                    Jump();   
                }
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

    void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, floor);
        
        if (hit.collider != null)
        {
            isGrounded = true;
            Debug.Log("Character is on the ground");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Character is in the air");
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
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        jumpCooldown = 0.4f;
    }

    //for organization, put other built-in Unity functions here
    

    //after all Unity functions, your own functions can go here
}