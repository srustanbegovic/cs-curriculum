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

   
    void Start()
    {
        Vector3[] points = new Vector3[3];
        points[0] = new Vector3(-2, 1, 0);
        points[1] = new Vector3(2, 1, 0);
        points[2] = new Vector3(0, -2, 0);
        speed = 5;
        target = points[0];
        gm = FindFirstObjectByType<GameManager>();
        direction = (target - transform.position).normalized; 

    }

  
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
