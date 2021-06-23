using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public List<Vector3> camPositions;
    public List<float> camSizes;
    public Vector2 moveSmoothing = Vector2.one;
    private Vector3 _currentPos, _targetPos;
    private float _currentSize, _targetSize;
    public float zoomSmoothing = 1f;
    private bool _isMoving, _isZooming;
    private Camera _camera;

    private int _i, _j; // i for moving, j for zooming
    // Start is called before the first frame update
    void Start()
    {
        transform.position = camPositions[0];
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = camSizes[0];
        
        _currentPos = transform.position;
        _currentSize = _camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving) Move();
        if (_isZooming) Zoom();

    }

    public void MoveToNext() // start the moving action
    {
        _i++;
        if(_i >= camPositions.Count) return;
        _targetPos = camPositions[_i];
        _isMoving = true;
    }

    public void ZoomToNext() // start the zooming action
    {
        _j++;
        if (_j >= camSizes.Count) return;
        _targetSize = camSizes[_j];
        _isZooming = true;
    }
    
    private void Move()
    {
        _currentPos.x = Mathf.Lerp(_currentPos.x, _targetPos.x, moveSmoothing.x * Time.deltaTime);
        _currentPos.y = Mathf.Lerp(_currentPos.y, _targetPos.y, moveSmoothing.y * Time.deltaTime);
        transform.position = _currentPos;
        if (Vector3.Distance(_currentPos, _targetPos) < Mathf.Epsilon)
            _isMoving = false;
    }

    private void Zoom()
    {
        _currentSize = Mathf.Lerp(_currentSize, _targetSize, zoomSmoothing * Time.deltaTime);
        _camera.orthographicSize = _currentSize;
        if (Mathf.Abs(_currentSize - _targetSize) < Mathf.Epsilon)
            _isZooming = false;

    }
}
