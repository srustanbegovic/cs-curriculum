using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float xspeed;
    float xdirection;
    float xvector;
    float yspeed;
    float ydirection;
    float yvector;
    public bool overworld;
    public TopDown_AnimatorController panimator;
    public GameObject door;
    private bool closeEnough = false;
    GameManager gm; 
    

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CaveDoor"))
        {
            closeEnough = true;
        }
    }

    //for organization, put other built-in Unity functions here
    

    //after all Unity functions, your own functions can go here
}