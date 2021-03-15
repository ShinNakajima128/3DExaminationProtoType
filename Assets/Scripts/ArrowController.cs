using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ArrowController : MonoBehaviour
{
    /// <summary> フェードにかける時間 </summary>
    [SerializeField] float m_fadeDuration = 1f;
    /// <summary> 表示する矢印のImage </summary>
    [SerializeField] Image m_arrowImage = null;

    void Start()
    {
        Fade(0);
    }

    void OnTriggerEnter(Collider other)
    {
        /// Player が接触したら徐々に表示する
        if (other.gameObject.CompareTag("Player"))
        {
            Fade(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        /// Player が接触したら徐々に消える
        if (other.gameObject.CompareTag("Player"))
        {
            Fade(0);
        }
    }

    void Fade(float targetAlpha)
    {
        Sequence s = DOTween.Sequence();
        s.Join(DOTween.ToAlpha(
            () => m_arrowImage.color,
            color => m_arrowImage.color = color,
            targetAlpha,
            m_fadeDuration));
        s.Play();
    }
}
