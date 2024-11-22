using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.healthText.text = ("Health: " + gm.health);
        gm.health = 5;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.health -= 1;
            gm.healthText.text = ("Health: " + gm.health);
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Start");
        gm.coins = 0;
    }
    

    void Update()
    {
        if (gm.health == 0)
        {
            Die();
            gm.health = 5;
        }
    }
}