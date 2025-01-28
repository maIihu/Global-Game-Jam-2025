using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private float _travelDistance = 0;
    public float GetTravelDis()
    {
        return _travelDistance;
    }
    private void Update()
    {
        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        _travelDistance += transform.position.y * Time.fixedDeltaTime;
    }
}
