using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_pressAnyButtonText = null;
    [SerializeField] GameObject m_menuText = null;
    [SerializeField] AudioClip m_decisionSfx = null;
    [SerializeField] AudioClip m_backSfx = null;
    AudioSource audioSource;
    private float m_timer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.anyKeyDown && m_pressAnyButtonText.activeSelf == true)
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_pressAnyButtonText.SetActive(false);
            m_menuText.SetActive(true);
        }
        else if (m_pressAnyButtonText.activeSelf == false && Input.GetButtonDown("Jump"))
        {
            audioSource.PlayOneShot(m_backSfx);
            m_pressAnyButtonText.SetActive(true);
            m_menuText.SetActive(false);
        }
        else if (m_pressAnyButtonText.activeSelf == false && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            audioSource.PlayOneShot(m_decisionSfx);
            SceneManager.LoadScene("Tutorial");
        }
    }
}
