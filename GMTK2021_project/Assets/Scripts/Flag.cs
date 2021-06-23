using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private CameraControl _cameraControl;

    public float threshold = 1f; // how far away the player is from the flag, to turn off the trigger

    private bool _cameraMoved;
    // Start is called before the first frame update
    void Start()
    {
        _cameraControl = Services.MainCamera.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // when player moves pass the trigger area, hide the flag and block the pathway
        if (Services.PlayerObj.transform.position.x > transform.position.x + threshold)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // moves the camera to next position when player enters the flag trigger zone
        if (_cameraMoved) return;
        if (!other.transform.parent) return;
        if(other.transform.parent.CompareTag("Player")) 
        {
            _cameraControl.MoveToNext();
            _cameraControl.ZoomToNext();
            _cameraMoved = true;
        }
    }
    
}
