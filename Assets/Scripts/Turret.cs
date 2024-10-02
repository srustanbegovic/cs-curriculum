using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameObject clone = Instantiate(projectilePrefab);
            clone.GetComponent<Projectile>().targetPosition = other.gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
