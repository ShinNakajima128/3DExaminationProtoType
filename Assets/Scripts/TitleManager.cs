using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_pressAnyButtonText = null;
    [SerializeField] GameObject m_menuText = null;
    [SerializeField] AudioClip m_decisionSfx = null;
    [SerializeField] AudioClip m_loadSfx = null;
    [SerializeField] float m_SceneLoadTime = 2f;
    [SerializeField] GameObject m_fadeController;
    bool isLoadStarted = false;
    FadeController FC;
    AudioSource audioSource;
    private float m_timer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FC = m_fadeController.GetComponent<FadeController>();
        FC.isFadeIn = true;
    }

    void Update()
    {
        if (Input.anyKeyDown && m_pressAnyButtonText.activeSelf == true)
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_pressAnyButtonText.SetActive(false);
            m_menuText.SetActive(true);
        }
        else if (m_pressAnyButtonText.activeSelf == false)
        {
            if (Input.GetButtonDown("Jump")) 
            {
                audioSource.PlayOneShot(m_decisionSfx);
                m_pressAnyButtonText.SetActive(true);
                m_menuText.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                FC.isFadeOut = true;
                audioSource.PlayOneShot(m_loadSfx);
                isLoadStarted = true;
            }
        }
        if (isLoadStarted)
        {
            m_timer += Time.deltaTime;

            if (m_timer >= m_SceneLoadTime)
            {
                m_timer = 0;
                SceneManager.LoadScene("Stage1");
            }
        }
    }
}
