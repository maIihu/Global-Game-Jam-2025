using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMeshController : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private CameraMovement playerCon;
    private void Awake()
    {
        playerCon = FindObjectOfType<CameraMovement>();
        _text = GetComponent<TextMeshProUGUI>();
    }


    private int score;
    private float accumulatedDistance;
    private const float DistancePerPoint = 10f;  

    private void Update()
    {
        accumulatedDistance += playerCon.GetTravelDis() * Time.deltaTime;
        
        if (accumulatedDistance >= DistancePerPoint)
        {
            score++;
            accumulatedDistance -= DistancePerPoint;
            _text.text = score.ToString();
            _text.text += "m";
        }
    }


}
