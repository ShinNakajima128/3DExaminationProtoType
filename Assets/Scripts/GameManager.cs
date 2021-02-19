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
    [SerializeField] Button m_menuFirstButton;
    [SerializeField] GameObject m_stageSelectMenuUI;
    [SerializeField] Button m_stageSelectFirstButton;
    [SerializeField] GameObject m_fadeController;
    [SerializeField] AudioClip m_menuSfx;
    [SerializeField] AudioClip m_selectSfx;
    [SerializeField] GameObject m_GoalObject = null;
    [SerializeField] float m_gameTime = 120.0f;
    [SerializeField] Text m_timeUI = null;
    [SerializeField] GameObject m_clearDictor = null;
    FadeController FC;
    AudioSource audioSource;
    int loadType;
    float m_currentTime;

    void Start()
    {
        FC = m_fadeController.GetComponent<FadeController>();
        audioSource = GetComponent<AudioSource>();
        FC.isFadeIn = true;
        m_currentTime = m_gameTime;
    }

    void Update()
    {
        ///制限時間を表示し、残り30秒を切ったら文字を赤くする
        if (m_UI.activeSelf)
        {
            m_timeUI.enabled = true;
            m_currentTime -= Time.deltaTime;
        }
        else
        {
            m_timeUI.enabled = false;
        }
        if (m_currentTime <= 30.0f)
        {
            m_timeUI.color = new Color(1.0f, 0, 0, 1.0f);
        }
        if (m_currentTime <= 0.0f)
        {
            m_currentTime = 0.0f;
        }

        m_timeUI.text = $"残り時間：{m_currentTime:F1}";

        //Xボタンが押されたらメニューを開き、ゲームを一時停止する
        if (m_UI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Xが押されました");
            Time.timeScale = 0f;
            audioSource.PlayOneShot(m_menuSfx);
            m_UI.SetActive(false);
            m_menuUI.SetActive(true);
            //m_menuFirstButton.Select();
        }
        else if (m_menuUI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Time.timeScale = 1f;
            audioSource.PlayOneShot(m_menuSfx);
            m_UI.SetActive(true);
            m_menuUI.SetActive(false);
        }
        else if (m_stageSelectMenuUI.activeSelf && Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            audioSource.PlayOneShot(m_menuSfx);
            m_stageSelectMenuUI.SetActive(false);
            m_menuUI.SetActive(true);
            m_menuFirstButton.Select();
        }

        if (!m_GoalObject.activeSelf)
        {
            m_clearDictor.SetActive(true);
        }
    }

    /// <summary>
    /// ステージをやり直す
    /// </summary>
    public void Restart()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 1;
        StartCoroutine(LoadTimer());
    }

    public void StageSelect()
    {
        audioSource.PlayOneShot(m_menuSfx);
        m_menuUI.SetActive(false);
        m_stageSelectMenuUI.SetActive(true);
        m_stageSelectFirstButton.Select();
    }
    public void Stage1()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 1;
        StartCoroutine(LoadTimer());
    }
    public void Stage2()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 2;
        StartCoroutine(LoadTimer());
    }
    public void GameExit()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 3;
        StartCoroutine(LoadTimer());
    }

    public void Tutorial()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 4;
        StartCoroutine(LoadTimer());
    }

    //Sceneの遷移を2秒遅らせる
    IEnumerator LoadTimer()
    {
        Time.timeScale = 1f;
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
        else if (loadType == 4)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
