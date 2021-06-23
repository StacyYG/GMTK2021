using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    private static Camera _myCamera;

    public static Camera MainCamera
    {
        get
        {
            Debug.Assert(_myCamera != null);
            return _myCamera;
        }
        set { _myCamera = value; }
    }

    private static GameObject _playerObj;

    public static GameObject PlayerObj
    {
        get
        {
            Debug.Assert(_playerObj != null);
            return _playerObj;
        }
        set { _playerObj = value; }
    }

    private static CameraControl _cameraControl;

    public static CameraControl CameraControl
    {
        get
        {
            Debug.Assert(_cameraControl != null);
            return _cameraControl;
        }
        set { _cameraControl = value; }
    }
}
