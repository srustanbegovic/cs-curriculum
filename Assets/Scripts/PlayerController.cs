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
    private float jumpForce = 5f;
    //private float raycastDistance = 1.0f;
    public float groundCheckDistance = 1f;
    private float jumpCooldown = 0.4f;
    public LayerMask floor; 
    GameManager gm;
    public Platform platform;
    public Vector3 platformvector;
    
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
        yvector = 0f;
        jumpCooldown = 0.4f;
        panimator = GetComponentInChildren<TopDown_AnimatorController>();
        platform = GetComponentInChildren<Platform>();
        
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            yspeed = 4;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;
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
        jumpCooldown =- Time.deltaTime;
        Debug.DrawRay(transform.position, Vector3.down);
        if (isGrounded && jumpCooldown <= 0)
        {
            //print("grounded");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //print("pressed jump");
                Jump();
                jumpCooldown = 0.4f;
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
        RaycastHit2D hitCenter = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, floor);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + Vector3.left * 0.3f, Vector2.down,
            groundCheckDistance, floor);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + Vector3.right * 0.3f, Vector2.down,
            groundCheckDistance, floor);
        if (hitCenter.collider != null || hitLeft.collider != null || hitRight.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlatformTop"))
        {
            print("on platform");
            transform.SetParent(other.transform);
        }
        if (other.CompareTag("CaveDoor"))
        {
            closeEnough = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlatformTop"))
        {
            transform.SetParent(null);
        }
    }

    void Jump()
    {
        //print("Jump Function");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    

    //for organization, put other built-in Unity functions here
    

    //after all Unity functions, your own functions can go here
}