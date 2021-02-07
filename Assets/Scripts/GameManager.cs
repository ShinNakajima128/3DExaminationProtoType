using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] GameObject m_UI;
    [SerializeField] GameObject m_menuUI;
    [SerializeField] GameObject m_fadeController;
    [SerializeField] AudioClip m_menuSfx;
    [SerializeField] AudioClip m_selectSfx;
    FadeController FC;
    AudioSource audioSource;
    float m_timer;
    int m_SceneLoadTime = 2;
    int loadType;
    bool isLoadStarted = false;

    void Start()
    {
        FC = m_fadeController.GetComponent<FadeController>();
        audioSource = GetComponent<AudioSource>();
        FC.isFadeIn = true;
    }

    void Update()
    {
        if (m_UI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Xが押されました");
            audioSource.PlayOneShot(m_menuSfx);
            m_UI.SetActive(false);
            m_menuUI.GetComponent<Canvas>().enabled = true;  
        }
        else if (!m_UI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioSource.PlayOneShot(m_menuSfx);
            m_UI.SetActive(true);
            m_menuUI.GetComponent<Canvas>().enabled = false;
        }
    }

    public void Restart()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 1;
        StartCoroutine(loadTimer());
    }

    public void StageSelect()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 2;
        StartCoroutine(loadTimer());
    }

    public void GameExit()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 3;
        StartCoroutine(loadTimer());
    }
    IEnumerator loadTimer()
    {
        yield return new WaitForSeconds(2.0f);

        if (loadType == 1)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (loadType == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (loadType == 3)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
