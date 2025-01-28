using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic _backgroundMusic;

    private void Awake()
    {
        if (_backgroundMusic == null)
        {
            _backgroundMusic = this;
            DontDestroyOnLoad(_backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
