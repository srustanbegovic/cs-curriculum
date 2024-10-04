using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject target = null;
    private float cooldown = 2;
    public GameObject Projectile;


    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (target != null && cooldown < 0)
        {
            Shoot();
            cooldown = 2;
        }
    }

    void Shoot()
    {
        if (target.gameObject.CompareTag("Player"))
        {

            GameObject Clone = Instantiate(Projectile, transform.position, Quaternion.identity);
            Projectile CloneScript = Clone.GetComponent<Projectile>();
            CloneScript.targetPosition = target.transform.position;

        }

    }

}
