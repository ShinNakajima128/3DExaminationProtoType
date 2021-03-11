using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_pressAnyButtonText = null;
    [SerializeField] GameObject m_menu = null;
    [SerializeField] Button m_menuFirstButton = null;
    [SerializeField] GameObject m_stageSelectMenu = null;
    [SerializeField] Button m_stagemenuFirstButton = null;
    [SerializeField] AudioClip m_decisionSfx = null;
    [SerializeField] AudioClip m_loadSfx = null;
    [SerializeField] GameObject m_fadeController;
    [SerializeField] PlayableDirector m_director = null;
    [SerializeField] GameObject m_Title = null;
    [SerializeField] GameObject m_highScoreMenu = null;
    [SerializeField] GameObject m_rankStageSelectMenu = null;
    [SerializeField] Button m_rankStageMenuFirstButton = null;
    [SerializeField] Text m_StageName;
    [SerializeField] GameObject m_stage1Scores = null;
    [SerializeField] GameObject m_stage2Scores = null;
    [SerializeField] GameObject m_stage3Scores = null;

    FadeController FC;
    AudioSource audioSource;
    int loadType = 0;
    bool isFirstPlay = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FC = m_fadeController.GetComponent<FadeController>();
        FC.isFadeIn = true;
        m_menu.SetActive(true);
        m_menuFirstButton.Select();
        m_menu.SetActive(false);   
    }

    void Update()
    {
        if (Input.anyKeyDown && isFirstPlay)
        {
            m_director.playableGraph.GetRootPlayable(0).SetSpeed(300);
            isFirstPlay = false;
        }

        if (m_director.state != PlayState.Playing)
        {
            isFirstPlay = false;
        }

        if (Input.anyKeyDown && m_pressAnyButtonText.activeSelf)
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_pressAnyButtonText.SetActive(false);
            m_menu.SetActive(true);
            m_menuFirstButton.Select();
        }

        if (m_stageSelectMenu.activeSelf && Input.GetButtonDown("A"))
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_stageSelectMenu.SetActive(false);
            m_menu.SetActive(true);
            m_menuFirstButton.Select();
        }

        if (m_rankStageSelectMenu.activeSelf && Input.GetButtonDown("A"))
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_rankStageSelectMenu.SetActive(false);
            m_menu.SetActive(true);
            m_menuFirstButton.Select();

        }

        if (m_highScoreMenu.activeSelf && Input.GetButtonDown("A"))
        {
            audioSource.PlayOneShot(m_decisionSfx);
            m_stage1Scores.SetActive(false);
            m_stage2Scores.SetActive(false);
            m_stage3Scores.SetActive(false);
            m_highScoreMenu.SetActive(false);
            m_Title.SetActive(true);
            m_rankStageSelectMenu.SetActive(true);
            m_rankStageMenuFirstButton.Select();
            
        }
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
        m_stagemenuFirstButton.Select();
    }
    public void Ranking()
    {
        audioSource.PlayOneShot(m_decisionSfx);
        m_menu.SetActive(false);
        m_rankStageSelectMenu.SetActive(true);
        m_rankStageMenuFirstButton.Select();
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

    public void Stage3()
    {
        audioSource.PlayOneShot(m_loadSfx);
        FC.isFadeOut = true;
        loadType = 6;
        StartCoroutine(loadTimer());
    }

    public void RankCheckStage1()
    {
        audioSource.PlayOneShot(m_decisionSfx);
        m_Title.SetActive(false);
        m_rankStageSelectMenu.SetActive(false);
        m_highScoreMenu.SetActive(true);
        m_stage1Scores.SetActive(true);
        m_StageName.enabled = true;
        m_StageName.text = "STAGE1";
    }

    public void RankCheckStage2()
    {
        audioSource.PlayOneShot(m_decisionSfx);
        m_Title.SetActive(false);
        m_rankStageSelectMenu.SetActive(false);
        m_highScoreMenu.SetActive(true);
        m_stage2Scores.SetActive(true);
        m_StageName.enabled = true;
        m_StageName.text = "STAGE2";
    }

    public void RankCheckStage3()
    {
        audioSource.PlayOneShot(m_decisionSfx);
        m_Title.SetActive(false);
        m_rankStageSelectMenu.SetActive(false);
        m_highScoreMenu.SetActive(true);
        m_stage3Scores.SetActive(true);
        m_StageName.enabled = true;
        m_StageName.text = "STAGE3";
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
        else if (loadType == 6)
        {
            SceneManager.LoadScene("Stage3");
        }
    }
}
