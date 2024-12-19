using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEnemy : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 target;
    private Vector3 targetdest;
    private Vector3 direction;
    public TopDown_AnimatorController panimator;
    public GameObject player; 
    public Vector3[] points = new Vector3[]
    
    
    {
        new Vector3(6, 0.5f, 0),
        new Vector3(12, 0.5f, 0),
    };
    private int currentTarget = 0;
    void Start()
    {
        targetdest = points[currentTarget];
        panimator = FindObjectOfType<TopDown_AnimatorController>();
        direction = (targetdest - transform.position).normalized;
    }

    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.x < 20 || transform.position.x > 25)
        {
            ChangeDirection();
        }
        print(panimator.IsAttacking);
        //print(Vector3.Distance(transform.position, player.transform.position));
        //print(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) <3f)
        {
            print("close enough");
            
            if (Input.GetMouseButton(0))
            {
                Destroy(gameObject);
            }
        }
    }

    

    void ChangeDirection()
    {
        currentTarget = (currentTarget + 1) % points.Length;
        if (currentTarget == 2)
        {
            currentTarget = 0;
        }
        targetdest = points[currentTarget];
        direction = (targetdest - transform.position).normalized;
        //print(targetdest);
    }
}