using System;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private float cooldown = 0.5f;
    public bool isOn = false;
    private SpriteRenderer spriter;
    public GameObject player; 
    public Sprite[] switchSprites; 

    private Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) <2.5f)
        {
            print("touching");
            if (Input.GetKeyDown(KeyCode.F))
            { 
                print("Switch activated!"); 
                ToggleSwitch();
                cooldown = 0.5f;  // Reset cooldown after activation
            }
        }
    }
    
    void ToggleSwitch()
    {
        isOn = !isOn; // Toggle the switch state
        print(isOn);

        // Update the sprite based on the switch state
        if (isOn)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = switchSprites[1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = switchSprites[0];
        }
    }
}