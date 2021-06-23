using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private float _usedTime;
    public float UsedTime
    {
        get { return _usedTime; }
    }
    private void Awake()
    {
        Services.MainCamera = Camera.main;
        Services.PlayerObj = GameObject.FindGameObjectWithTag("Player");
        Services.CameraControl = Camera.main.GetComponent<CameraControl>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _usedTime += Time.deltaTime;
    }
}
