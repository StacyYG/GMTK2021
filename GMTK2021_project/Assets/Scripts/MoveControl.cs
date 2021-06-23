using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float forceMultiplier, torqueMultiplier, maxRotateSpeed, rotationMultiplier;

    private bool _canJump = true, _isGrounded;

    // player stats, for fun
    private float _rotatingTime = 0f;
    public float RotatingTime
    {
        get { return _rotatingTime; }
    }

    private int _jumpTimes = 0;
    public int JumpTimes
    {
        get { return _jumpTimes; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // jump once, but only after touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _rb.AddForce(forceMultiplier * Vector2.up);
            _canJump = false;
            
            // record jump times
            _jumpTimes++;
        }
        
        // rotate to left
        if (Input.GetKey(KeyCode.A))
        {   
            // record the time rotating
            _rotatingTime += Time.deltaTime;
            
            if (Mathf.Abs(_rb.angularVelocity) > maxRotateSpeed) return;
            _rb.AddTorque(torqueMultiplier * Time.deltaTime);
        }
        
        // rotate to right
        if (Input.GetKey(KeyCode.D))
        {            
            // record the time rotating
            _rotatingTime += Time.deltaTime;
                     
            if (Mathf.Abs(_rb.angularVelocity) > maxRotateSpeed) return;
            _rb.AddTorque(-torqueMultiplier * Time.deltaTime);
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // player can only jump after touching the ground
        // the ground has to be the same color
        if (other.gameObject.CompareTag("ground_1") && other.otherCollider.gameObject.CompareTag("PlayerParts_1"))
            _canJump = true;
        else if (other.gameObject.CompareTag("ground_2") && other.otherCollider.gameObject.CompareTag("PlayerParts_2"))
            _canJump = true;
        else _canJump = false;

    }
    
}
