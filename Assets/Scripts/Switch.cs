using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private float cooldown = 0.5f;
    public bool isOn = false;
    private SpriteRenderer spriter;

    public Sprite[] switchSprites;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        spriter.sprite = switchSprites[1];
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //print("close to switch");
            if (cooldown < 0f && Input.GetKeyDown(KeyCode.F))
            {
                print("Switch activated!");
                ToggleSwitch();
                cooldown = 0.5f;
            }
        }
    }

    void ToggleSwitch()
    {
        isOn = !isOn;
        print(isOn);
        spriter.sprite = switchSprites[isOn ? 1 : 0];
    }
}
