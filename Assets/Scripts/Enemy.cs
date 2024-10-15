using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private Vector3 target;
    private Vector3 direction;
    GameManager gm;

    private Vector3[] points = new Vector3[]
    {
        new Vector3(0, -8, 0),
        new Vector3(-4, -1, 0),
        new Vector3(-3, -2, 0)
    };

    private int currentTarget = 0;
    void Start()
    {
        print("point zero" +points[0]);
        speed = 5;
        target = points[currentTarget];
        gm = FindFirstObjectByType<GameManager>();
        direction = (target - transform.position).normalized; 

    }

  
    void Update()
    {
        print(target);
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            print("hit target");
            ChangeDirection();
        }
    }





    void ChangeDirection()
    {
        currentTarget = (currentTarget + 1) % points.Length;
        if (currentTarget = 3)
        {
            currentTarget = 0;
        }
        target = points[currentTarget];
        direction = (target - transform.position).normalized;
    }
}
