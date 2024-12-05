using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 0f;
    public Switch toggle; 
    private Vector3 target;
    private Vector3 targetdest;
    private Vector3 direction; 
    public Vector3[] points = new Vector3[]
    {
        new Vector3(6, 0.5f, 0),
        new Vector3(12, 0.5f, 0),
        new Vector3(6, 0.5f, 0),
        new Vector3(12, 0.5f, 0),
    };
    private int currentTarget = 0;
    void Start()
    {
       // toggle = FindFirstObjectByType<Switch>();
        targetdest = points[currentTarget];
        direction = (targetdest - transform.position).normalized;
    }

    
    void Update()
    {
        if (toggle.isOn)
        {
            speed = 2f;
        }

        if (toggle.isOn == false)
        {
            speed = 0f; 
        }
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetdest) < 0.1f)
        {
            ChangeDirection();
            //print("hit target");
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
        //print(targetdest);
    }
}
