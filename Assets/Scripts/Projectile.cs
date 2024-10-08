using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 direction;
    GameManager gm;
    private float speed;
    private float dis;
    private float timer; 

    void Start()
    {
        direction = (targetPosition - transform.position).normalized;
        speed = 10;
        gm = FindFirstObjectByType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        dis = (Vector3.Distance(transform.position, targetPosition));
        timer -= 1 * Time.deltaTime;
        /*
        if (dis == 0)
        {
            Destroy(gameObject);
        }
        */
        if (timer < 0)
        {
            Destroy(gameObject);
            print("destroyed projectile");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("hit player");
            gm.health -= 1;
            gm.healthText.text = ("Health: " + gm.health);
            Destroy(gameObject);
        }


    }
}

