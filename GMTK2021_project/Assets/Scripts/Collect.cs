using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float pushDistance;
    private List<GameObject> _playerParts = new List<GameObject>();

    public List<GameObject> PlayerParts
    {
        get
        {
            Debug.Assert(_playerParts != null);
            return _playerParts;
        }
    }

    private List<Rigidbody2D> _rbs = new List<Rigidbody2D>();
    
    private void Start()
    {
        _playerParts.Add(transform.GetChild(0).gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FallApart();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if tag is "box", destroy the rb and add to list
        if (other.gameObject.CompareTag("box_1"))
        {
            other.transform.parent = transform;
            Destroy(other.rigidbody);
            other.gameObject.tag = "PlayerParts_1";
            _playerParts.Add(other.gameObject);
        }
        
        else if (other.gameObject.CompareTag("box_2"))
        {
            other.transform.parent = transform;
            Destroy(other.rigidbody);
            other.gameObject.tag = "PlayerParts_2";
            _playerParts.Add(other.gameObject);
        }
    }

    public void FallApart()
    {
        for (int i = 1; i < _playerParts.Count; i++)
        {
            if (_playerParts[i].CompareTag("PlayerParts_1"))
            {
                _playerParts[i].tag = "box_1";
            }
            else if (_playerParts[i].CompareTag("PlayerParts_2"))
            {
                _playerParts[i].tag = "box_2";
            }
            
            // add a rigidbody to the fallen part
            var rb = _playerParts[i].GetComponent<Rigidbody2D>()
                ? _playerParts[i].GetComponent<Rigidbody2D>()
                : _playerParts[i].AddComponent<Rigidbody2D>();
            rb.drag = 0;
            rb.angularDrag = 0;
            rb.gravityScale = 3;
            
            // push away the fallen part
            var pushDirection = (rb.transform.position - _playerParts[0].transform.position).normalized;
            rb.transform.position += pushDistance * pushDirection;
        }

        var firstPart = _playerParts[0];
        _playerParts = new List<GameObject>();
        _playerParts.Add(firstPart);

    }
}
