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
        if (switchSprites.Length > 0 && spriter != null)
        {
            spriter.sprite = switchSprites[0];
        }
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (cooldown <= 0f && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Switch activated!");
                ToggleSwitch();
                cooldown = 0.5f;
            }
        }
    }

    void ToggleSwitch()
    {
        isOn = !isOn;
        if (switchSprites.Length > 0 && spriter != null)
        {
            spriter.sprite = switchSprites[isOn ? 1 : 0];
        }

        Debug.Log("Lever is " + (isOn ? "On" : "Off"));
    }
}
