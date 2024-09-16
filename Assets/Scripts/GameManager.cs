using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int coins;


    void Awake()
    {

        if (gm != null && gm != this)
          {
            Destroy(gameObject);

          }
        else
          {
            gm = this;

        }

        coins = 0;


    }


    void Update()
    {

    }
}
