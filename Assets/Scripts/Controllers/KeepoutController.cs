using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KeepoutController : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] Image m_keepImage;
    [SerializeField] float m_duration = 3f;
    [SerializeField] float m_fadeDuration = 1f;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        Fade(0);
        Keepout();
    }

    void OnTriggerEnter(Collider other)
    {
        // Player が接触したら徐々に表示する
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Fade(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Player が接触したら徐々に消える
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
            Fade(0);
        }
    }

    void Fade(float targetAlpha)
    {
        Sequence s = DOTween.Sequence();
        s.Join(DOTween.ToAlpha(
            () => m_keepImage.color,
            color => m_keepImage.color = color,
            targetAlpha,
            m_fadeDuration));
        s.Play();
    }

    void Keepout()
    {
        Sequence s = DOTween.Sequence();
        s.Append(m_keepImage.transform.DOMove(m_target.position, m_duration).SetEase(Ease.Linear))
            .SetLoops(-1);
        s.Play();
    }
}
