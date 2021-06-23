using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintF : MonoBehaviour
{
    public GameObject textF;
    // Start is called before the first frame update
    void Start()
    {
        textF.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // wait for the player to show the text
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerParts"))
        {
            textF.SetActive(true);
            Destroy(this);
        }
    }
}
