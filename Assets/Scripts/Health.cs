using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.healthText.text = ("Health: " + gm.health);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.health = gm.health - 1;
            print(gm.health);
            

        }
    }




    void Update()
    {
        
    }
}