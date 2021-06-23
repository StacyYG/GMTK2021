using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowThanks : MonoBehaviour
{
    public GameObject thanksText;

    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        thanksText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.transform.parent) return;
        if(other.transform.parent.CompareTag("Player")) 
        {
            thanksText.SetActive(true);
            playerStats.GetStats();
            playerStats.Print();
            Destroy(gameObject);
        }
    }
}
