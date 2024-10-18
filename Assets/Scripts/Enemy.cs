using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private Vector3 targetdest;
    private Vector3 direction;
    private Vector3 directionchase;
    private GameObject target;
    GameManager gm;

    private Vector3[] points = new Vector3[]
    {
        new Vector3(0, -11, 0),
        new Vector3(0, -1, 0),
        new Vector3(-10, -1, 0),
        new Vector3(-10,-11,0)
    };
    enum states
    {
        patrol,
        chase,
        attack,
        die
    }

    private states state;
    
    private int currentTarget = 0;
    void Start()
    {
        target = null;
        print("point zero" +points[0]);
        speed = 3;
        targetdest = points[currentTarget];
        gm = FindFirstObjectByType<GameManager>();
        direction = (targetdest - transform.position).normalized; 
    }
    void Update()
    {
        if (state == states.patrol)
        {
            Patrol();
        }
        if (state == states.chase)
        {
            Chase();
        }
        if (state == states.attack)
        {
            Attack();
        }
        if (state == states.die)
        {
            Die();
        }
    }
    void Patrol()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetdest) < 0.1f)
        {
            print("hit target");
            ChangeDirection();

        }
    }

    void Chase()
    {
        directionchase = (target.transform.position - transform.position).normalized;
        transform.position += directionchase * speed * Time.deltaTime;
    }

    void Attack()
    {
        
    }

    void Die()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                print("lock on to player");
                target = other.gameObject;
                state = states.chase;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("unlocked from player");
            target = null;
            state = states.patrol;
            ChangeDirection(); 
        }
    }
    void ChangeDirection()
    {
        currentTarget = (currentTarget + 1) % points.Length;
        if (currentTarget == 4)
        {
            currentTarget = 0;
        }
        targetdest = points[currentTarget];
        direction = (targetdest - transform.position).normalized;
        print(targetdest);
    }
}
