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

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; 
        xspeed = 4;
        xdirection = 0;
        xvector = 0;
        
        ydirection = 0;
        yvector = 0;

        
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


    }
    
    //for organization, put other built-in Unity functions here
    
    
    
    
    
    //after all Unity functions, your own functions can go here
}