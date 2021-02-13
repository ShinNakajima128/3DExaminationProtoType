using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_pressAnyButtonText = null;
    [SerializeField] GameObject m_menu = null;
    [SerializeField] Button m_menufirstSelect = null;
    [SerializeField] GameObject m_stageSelectMenu = null;
    [SerializeField] Button m_startMenufirstSelect = null;
    [SerializeField] AudioClip m_decisionSfx = null;
    [SerializeField] AudioClip m_loadSfx = null;
    [SerializeField] float m_SceneLoadTime = 2f;
    [SerializeField] GameObject m_fadeController;
    bool isLoadStarted = false;
    FadeController FC;
    AudioSource audioSource;
    private float m_timer;
    int loadType = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FC = m_fadeController.GetComponent<FadeController>();
        FC.isFadeIn = true;
    }

    void Update()
    {
        if (Input.anyKeyDown && m_pressAnyButtonText.activeSelf)
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_pressAnyButtonText.SetActive(false);
            m_menu.SetActive(true);
            m_menufirstSelect.Select();
        }
        if (m_stageSelectMenu.activeSelf && Input.GetButtonDown("A"))
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_stageSelectMenu.SetActive(false);
            m_menu.SetActive(true);
            m_menufirstSelect.Select();
        }
        //else if (m_pressAnyButtonText.activeSelf == false)
        //{
        //    if (Input.GetButtonDown("A")) 
        //    {
        //        audioSource.PlayOneShot(m_decisionSfx);
        //        m_pressAnyButtonText.SetActive(true);
        //        m_menuText.SetActive(false);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.JoystickButton1))
        //    {
        //        FC.isFadeOut = true;
        //        audioSource.PlayOneShot(m_loadSfx);
        //        isLoadStarted = true;
        //    }
        //}
        //if (isLoadStarted)
        //{
        //    m_timer += Time.deltaTime;

        //    if (m_timer >= m_SceneLoadTime)
        //    {
        //        m_timer = 0;
        //        SceneManager.LoadScene("Stage1");
        //    }
        //}
    }
    public void GameStart()
    {
        audioSource.PlayOneShot(m_loadSfx);
        FC.isFadeOut = true;
        loadType = 1;
        StartCoroutine(loadTimer());
    }
    public void StageSelect()
    {
        audioSource.PlayOneShot(m_decisionSfx);
        m_menu.SetActive(false);
        m_stageSelectMenu.SetActive(true);
        m_startMenufirstSelect.Select();
    }
    public void GameExit()
    {
        audioSource.PlayOneShot(m_loadSfx);
        FC.isFadeOut = true;
        loadType = 2;
        StartCoroutine(loadTimer());
    }
    public void Tutorial()
    {
        audioSource.PlayOneShot(m_loadSfx);
        FC.isFadeOut = true;
        loadType = 3;
        StartCoroutine(loadTimer());
    }
    public void Stage1()
    {
        audioSource.PlayOneShot(m_loadSfx);
        FC.isFadeOut = true;
        loadType = 4;
        StartCoroutine(loadTimer());
    }
    public void Stage2()
    {
        audioSource.PlayOneShot(m_loadSfx);
        FC.isFadeOut = true;
        loadType = 5;
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
            Application.Quit();
        }
        else if (loadType == 3)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (loadType == 4)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (loadType == 5)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
