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
        if (Vector3.Distance(transform.position, door.transform.position) < 10)
        {
            print(transform.position);
            print(door.transform.position);
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
   
    //for organization, put other built-in Unity functions here
    

    //after all Unity functions, your own functions can go here
}