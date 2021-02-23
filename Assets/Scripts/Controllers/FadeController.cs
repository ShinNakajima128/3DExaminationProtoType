using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    /// <summary> フェードアウトするか否か </summary>
    public bool isFadeOut = false;
    /// <summary> フェードインするか否か </summary>
    public bool isFadeIn = false;
    /// <summary> フェードするスピード </summary>
    [SerializeField] float fadeSpeed = 0.01f;
    /// <summary> PanelのRGBa </summary>
    float red, green, blue, alfa;
    /// <summary> フェードするPanelのImage </summary>
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
        ///フェードインが始まったら
        if (isFadeIn)
        {
            StartFadeIn();
        }
        ///フェードアウトが始まったら
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    /// <summary>
    /// フェードアウトする
    /// </summary>
    void StartFadeOut()
    {
        //fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();

        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }
    /// <summary>
    /// フェードインする
    /// </summary>
    void StartFadeIn()
    {
        alfa -= fadeSpeed;
        SetAlfa();

        ///a値が0になったら
        if (alfa <= 0)
        {
            isFadeIn = false;
            //fadeImage.enabled = false;
        }
    }

    /// <summary>
    /// a値を変更する
    /// </summary>
    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}

