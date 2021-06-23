using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTest : MonoBehaviour
{
    public GameObject box;

    private bool _playerIsHere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_playerIsHere)
            {
                var b = Instantiate(box);
                b.transform.position = new Vector3(Camera.main.transform.position.x, 0, 0);
            }
            else
            {
                Services.PlayerObj.transform.position = new Vector3(Camera.main.transform.position.x, 0, 0);
                _playerIsHere = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Services.CameraControl.MoveToNext();
            Services.CameraControl.ZoomToNext();
        }
        
    }
}
