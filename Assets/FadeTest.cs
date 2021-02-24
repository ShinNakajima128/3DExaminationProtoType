using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeTest : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] float m_duration = 1f;
    Vector3 m_originPosition;
    Image m_image = null;

    // Start is called before the first frame update
    void Start()
    {
        m_image = GetComponent<Image>();
        m_originPosition = this.transform.position;
        Keepout();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fade(0);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Fade(1);
        }
    }

    void Fade(float targetAlpha)
    {
        Sequence s = DOTween.Sequence();
        s.Join(DOTween.ToAlpha(
            () => m_image.color,
            color => m_image.color = color,
            targetAlpha,
            1.0f));
        s.Play();
    }

    void Keepout()
    {
        Sequence s = DOTween.Sequence();
        s.Append(this.transform.DOMove(m_target.position, m_duration).SetEase(Ease.Linear))
            .SetLoops(-1);
        s.Play();
    }
}
