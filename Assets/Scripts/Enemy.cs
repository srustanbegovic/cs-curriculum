using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    private float speed;
    private Vector3 targetdest;
    private Vector3 direction;
    private Vector3 directionchase;
    private GameObject target;
    private float cooldown;
    public float health;
    public TopDown_EnemyAnimator animator;
    public TopDown_AnimatorController panimator;
    public GameObject coin;
    public GameObject axe;
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
        health = 1;
        panimator = GetComponentInChildren<TopDown_AnimatorController>();
        animator = GetComponentInChildren<TopDown_EnemyAnimator>();
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
        if (health != 1)
        {
            state = states.die;
        }

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 1.5f)
            {
                print(panimator.IsAttacking);
                print("can be hit");
                if (panimator.IsAttacking)
                {
                    print("killed");
                    health = 0;
                }
            }
        }

    }
    void Patrol()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetdest) < 0.1f)
        {
            //print("hit target");
            ChangeDirection();

        }
    }

    void Chase()
    {
        directionchase = (target.transform.position - transform.position).normalized;
        transform.position += directionchase * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.transform.position) < 2f)
        {
            state = states.attack;
            print("attack state");
            cooldown = 0;
        }
    }

    void Attack()
    {
        cooldown -= Time.deltaTime;
        directionchase = (target.transform.position - transform.position).normalized;
        transform.position += directionchase * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.transform.position) < 1f)
        {
            //print("trying to hit");
            if (cooldown < 0)
            {
                animator.IsAttacking = true;
                animator.Attack(); 
                //print("hit player");
                gm.health -= 1;
                gm.healthText.text = ("Health: " + gm.health);
                print(gm.health);
                cooldown = 1;
            }
        }
    }

    void Die()
    {
        //DropCoin();
        DropAxe();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (state == states.patrol)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                print("lock on to player");
                target = other.gameObject;
                panimator = target.GetComponentInChildren<TopDown_AnimatorController>();
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
        //print(targetdest);
    }

    void DropCoin()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
    }

    void DropAxe()
    {
        Instantiate(axe, transform.position, Quaternion.identity);
    }
}
