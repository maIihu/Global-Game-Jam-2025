using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private PlayerController playerCon;
    private int _bubbleLifeTime;
    
    private void Awake()
    {
        playerCon = FindObjectOfType<PlayerController>();
        if (playerCon != null)
        {
            playerCon.OnBubbleLifeTimeChanged += UpdateSlider;
        }
    }

    private void Start()
    {
        _bubbleLifeTime = Random.Range(6, 10);
        slider.maxValue = _bubbleLifeTime;
    }

    private void UpdateSlider(int newBubbleLifeTime)
    {
        SetProgress(newBubbleLifeTime);
    }

    private void SetProgress(int value)
    {
        StartCoroutine(SmoothSliderChange(value));
    }

    private IEnumerator SmoothSliderChange(int targetValue)
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        float startingValue = slider.value;

        while (elapsedTime < duration)
        {
            slider.value = Mathf.Lerp(startingValue, targetValue, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        slider.value = targetValue;
    }

    private void OnDestroy()
    {
        if (playerCon != null)
        {
            playerCon.OnBubbleLifeTimeChanged -= UpdateSlider;
        }
    }
}
