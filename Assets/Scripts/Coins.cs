using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();   
        gm.coinText.text = ("Coins: " + gm.coins);
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.coins += 1;
            gm.coinText.text = ("Coins: " + gm.coins);
            Destroy(other.gameObject);
        }
    }




    void Update()
    {
        
    }
}
