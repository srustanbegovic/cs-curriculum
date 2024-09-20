using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int coins;
    public int health;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;

    void Awake()
    {

        if (gm != null && gm != this)
          {
            Destroy(gameObject);

          }
        else
        {
          gm = this;
          DontDestroyOnLoad(this.gameObject);
        }

        
    }

    private void Start()
    {
        coins = 0;
        health = 5;
    }


    void Update()
    {
        
    }
}
