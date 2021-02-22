using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepoutController : MonoBehaviour
{
    [SerializeField] GameObject m_keepout;
    [SerializeField] Animator m_anim;
    AudioSource audioSource;

    void Start()
    {
        m_keepout.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        //m_anim.Play("OFF");
        //m_anim.Play("Keepout");
    }
    void OnTriggerEnter(Collider other)
    {
        // Player が接触したら徐々に表示する
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            m_keepout.SetActive(true);
            m_anim.Play("ON");
            //m_anim.Play("Keepout");
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Player が接触したら徐々に消える
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
            m_anim.Play("OFF");
        }
    }
}
