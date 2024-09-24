using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.healthText.text = ("Health: " + gm.health);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.health -= 1;
            gm.healthText.text = ("Health: " + gm.health);
            
            

        }
    }




    void Update()
    {
        
    }
}