﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public bool isFadeOut = false;
    public bool isFadeIn = false;

    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;
    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();

        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;
        SetAlfa();

        if (alfa <= 0)
        {
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
