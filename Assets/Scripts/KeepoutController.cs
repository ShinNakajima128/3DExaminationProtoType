using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KeepoutController : MonoBehaviour
{
    [SerializeField] GameObject m_keepout;
    [SerializeField] Animator m_anim;
    [SerializeField] Image m_keepImage;
    AudioSource audioSource;
    //[SerializeField] float m_timer = 0;
    //bool isinvisible = false;

    void Start()
    {
        m_keepout.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        //m_anim.Play("Keepout");
        //m_keepImage.color = new Color(0, 0, 0, 0);
        //Color color = m_keepImage.gameObject.GetComponent<Renderer>().material.color;        
        //m_anim.Play("OFF");
        //m_anim.Play("Keepout");
    }

    void OnTriggerEnter(Collider other)
    {
        // Player が接触したら徐々に表示する
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            //m_keepout.SetActive(true);
            //m_anim.Play("ON");
            
            //isinvisible = true;

            //Sequence seq = DOTween.Sequence();

            //seq.Append(m_keepImage.DOFade(1, 1));
            //seq.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Player が接触したら徐々に消える
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
            //m_anim.Play("OFF");
            //isinvisible = false;

            //Sequence seq = DOTween.Sequence();
            //seq.Append(m_keepImage.DOFade(0, 1));
            //seq.Play();
        }
    }
}
