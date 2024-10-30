using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    GameManager gm;
    public TopDown_AnimatorController panimator; 

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        panimator = GetComponentInChildren<TopDown_AnimatorController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Axe"))
        {
            panimator.SwitchToAxe();
            Destroy(other.gameObject);
        }
    }
}