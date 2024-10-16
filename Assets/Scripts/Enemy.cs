using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private Vector3 targetdest;
    private Vector3 direction;
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
        speed = 5;
        targetdest = points[currentTarget];
        gm = FindFirstObjectByType<GameManager>();
        direction = (targetdest - transform.position).normalized; 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
            state = states.chase;
        }

    }

    
    void Update()
    {
        
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetdest) < 0.1f)
        {
            print("hit target");
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
