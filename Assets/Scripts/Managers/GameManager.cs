﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    /// <summary> UI </summary>
    [SerializeField] GameObject m_UI;
    /// <summary> メニュー </summary>
    [SerializeField] GameObject m_menuUI;
    /// <summary> メニューの最初に選ばれるボタン </summary>
    [SerializeField] Button m_menuFirstButton;
    /// <summary> ステージセレクトメニューのUI </summary>
    [SerializeField] GameObject m_stageSelectMenuUI;
    /// <summary> ステージセレクトメニューの最初に選ばれるボタン </summary>
    [SerializeField] Button m_stageSelectFirstButton;
    /// <summary> フェードインアウトをコントロールするオブジェクト </summary>
    [SerializeField] GameObject m_fadeController;
    /// <summary> メニューを開いた時のSE </summary>
    [SerializeField] AudioClip m_openMenuSfx;
    /// <summary> メニューを閉じた時のSE </summary>
    [SerializeField] AudioClip m_closeMenuSfx;
    /// <summary> ボタンを選択した時のSE </summary>
    [SerializeField] AudioClip m_selectSfx;
    /// <summary> ゴールオブジェクト </summary>
    [SerializeField] GameObject m_GoalObject = null;
    /// <summary> ゲームの制限時間 </summary>
    [SerializeField] float m_gameTime = 60.0f;
    /// <summary> 制限時間のテキストUI </summary>
    [SerializeField] Text m_timeUI = null;
    /// <summary> 制限時間が増えるアイテムのイメージ </summary>
    [SerializeField] GameObject m_addTimeImage = null;
    /// <summary> 制限時間が増加した時に表示するテキスト </summary>
    [SerializeField] Text m_addText = null;
    /// <summary> 制限時間が残り僅かになった時のSE </summary>
    [SerializeField] AudioClip m_warningSfx;
    /// <summary> ゲーム開始時のSE </summary>
    [SerializeField] AudioClip m_startSfx;
    /// <summary> スタート開始時に流れるアニメーションのオブジェクト </summary>
    [SerializeField] GameObject m_startText;
    /// <summary> 画面をフェードさせるContoroller </summary>
    FadeController FC;
    /// <summary> GameManagerのAudioSource </summary>
    AudioSource audioSource;
    /// <summary> Sceneをロードする際にこの値によって読み込むSceneを切り替える変数 </summary>
    int loadType;
    /// <summary> 現在の残り時間 </summary>
    public float m_currentTime;
    /// <summary> 再生できるかどうか </summary>
    bool isAudioPlay = true;
    string beforeScene = "";

    void Start()
    {
        FC = m_fadeController.GetComponent<FadeController>();
        audioSource = GetComponent<AudioSource>();
        FC.isFadeIn = true;
        m_currentTime = m_gameTime;
        beforeScene = ResultManager.m_stageName;

        if (SceneManager.GetActiveScene().name != "ClearScene")
        {
            ResultManager.m_playTimer = 0;
            ResultManager.m_stageName = SceneManager.GetActiveScene().name;
            Debug.Log(ResultManager.m_stageName);

            if (SceneManager.GetActiveScene().name == "GameOverScene")
            {
                ResultManager.m_stageName = beforeScene;
                Debug.Log(ResultManager.m_stageName);
            }
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "ClearScene" && SceneManager.GetActiveScene().name != "GameOverScene")
        {
            ResultManager.m_playTimer += Time.deltaTime;
        }
        ///制限時間を表示し、残り30秒を切ったら文字を赤くする。赤い状態で30秒を超えたら文字を白くする。
        if (m_UI.activeSelf)
        {
            m_timeUI.enabled = true;
            m_currentTime -= Time.deltaTime;
        }
        else
        {
            m_timeUI.enabled = false;
        }

        ///残り時間が30秒未満になったら残り時間のテキストを赤くする
        if (m_currentTime < 30.0f)
        {
            ///警告音を鳴らす
            if (isAudioPlay)
            {
                AudioSource.PlayClipAtPoint(m_warningSfx, Camera.main.transform.position);
                isAudioPlay = false;
            }
            m_timeUI.color = new Color(1, 0, 0, 1);
        }
        ///残り時間が30秒以上の時は残り時間のテキストを白くする
        else if (m_currentTime >= 30.0f)
        {
            m_timeUI.color = new Color(1, 1, 1, 1);
            isAudioPlay = true;
        }
        ///残り時間が0になったらGameOverSceneへ遷移する
        if (m_currentTime <= 0.0f)
        {
            m_UI.SetActive(false);
            loadType = 6;
            FC.isFadeOut = true;
            StartCoroutine(LoadTimer());
        }

        ///残り時間のTextに現在の残り時間を表示する
        m_timeUI.text = $"残り時間：{m_currentTime:F1}";

        ///Xボタンが押されたらメニューを開き、ゲームを一時停止する
        if (m_UI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Xが押されました");
            Time.timeScale = 0f;
            audioSource.PlayOneShot(m_openMenuSfx);
            m_startText.SetActive(false);
            m_UI.SetActive(false);
            m_menuUI.SetActive(true);
            m_menuFirstButton.Select();
        }
        ///メニューを開いた状態でもう一度Xボタンを押すと、メニューを閉じる
        else if (m_menuUI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Time.timeScale = 1f;
            audioSource.PlayOneShot(m_closeMenuSfx);
            m_UI.SetActive(true);
            m_menuUI.SetActive(false);
        }
        ///ステージセレクトメニューが開いた状態でXボタンを押すと、メニューに戻る
        else if (m_stageSelectMenuUI.activeSelf && Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("メニューに戻る");
            audioSource.PlayOneShot(m_openMenuSfx);
            m_stageSelectMenuUI.SetActive(false);
            m_menuUI.SetActive(true);
            m_menuFirstButton.Select();
        }
        ///ゴールが消えたらClearSceneを読み込む
        if (!m_GoalObject.activeSelf)
        {
            m_UI.SetActive(false);
            FC.isFadeOut = true;
            loadType = 5;
            StartCoroutine(LoadTimer());
        }
        ///残り時間+30を使って足した時間を表示した後、2秒後に非表示にする
        if (m_addTimeImage.activeSelf && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Invoke("DerayEnable", 2f);
        }
    }

    /// <summary>
    /// ゲーム開始時の処理
    /// </summary>
    void StartPlay()
    {
        Debug.Log("ゲーム開始");
        m_startText.SetActive(true);
        AudioSource.PlayClipAtPoint(m_startSfx, Camera.main.transform.position);
    }

    /// <summary>
    /// 残り時間を足したお知らせを非表示にする
    /// </summary>
    void DerayEnable()
    {
        m_addText.enabled = false;
    }

    /// <summary>
    /// ステージをやり直す
    /// </summary>
    public void Restart()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;

        ///現在のSceneがStage1だったら
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            loadType = 1;
            StartCoroutine(LoadTimer());
        }
        ///現在のSceneがStage2だったら
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            loadType = 2;
            StartCoroutine(LoadTimer());
        }
        ///現在のSceneがStage3だったら
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            loadType = 7;
            StartCoroutine(LoadTimer());
        }
    }

    /// <summary>
    /// ステージを選択する
    /// </summary>
    public void StageSelect()
    {
        audioSource.PlayOneShot(m_openMenuSfx);
        m_menuUI.SetActive(false);
        m_stageSelectMenuUI.SetActive(true);
        m_stageSelectFirstButton.Select();
    }

    /// <summary>
    /// ステージ1に遷移する
    /// </summary>
    public void Stage1()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 1;
        StartCoroutine(LoadTimer());
    }

    /// <summary>
    /// ステージ2に遷移する
    /// </summary>
    public void Stage2()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 2;
        StartCoroutine(LoadTimer());
    }

    public void Stage3()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 7;
        StartCoroutine(LoadTimer());
    }
    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void GameExit()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 3;
        StartCoroutine(LoadTimer());
    }

    public void GameOverRestart()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;

        ///現在のSceneの名前がStage1だったら
        if (ResultManager.m_stageName == "Stage1")
        {
            loadType = 1;
            StartCoroutine(LoadTimer());
        }
        ///現在のSceneの名前がStage2だったら
        else if (ResultManager.m_stageName == "Stage2")
        {
            loadType = 2;
            StartCoroutine(LoadTimer());
        }
        else if (ResultManager.m_stageName == "Stage3")
        {
            loadType = 7;
            StartCoroutine(LoadTimer());
        }
    }

    /// <summary>
    /// チュートリアルに遷移する
    /// </summary>
    public void Tutorial()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 4;
        StartCoroutine(LoadTimer());
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(m_selectSfx);
        FC.isFadeOut = true;
        loadType = 6;
        StartCoroutine(LoadTimer());
    }

    /// <summary>
    /// Sceneの遷移を2秒遅らせる
    /// </summary>
    /// <returns> ロードするScene </returns>
    IEnumerator LoadTimer()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2.0f);

        ///Stage1に遷移する
        if (loadType == 1)
        {
            SceneManager.LoadScene("Stage1");
        }
        ///Stage2に遷移する
        else if (loadType == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        ///Titleに遷移する
        else if (loadType == 3)
        {
            SceneManager.LoadScene("Title");
        }
        ///Tutorialに遷移する
        else if (loadType == 4)
        {
            SceneManager.LoadScene("Tutorial");
        }
        ///ClearSceneに遷移する
        else if (loadType == 5)
        {
            SceneManager.LoadScene("ClearScene");
        }
        ///GameOverSceneに遷移する
        else if (loadType == 6)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else if (loadType == 7)
        {
            SceneManager.LoadScene("Stage3");
        }
    }
}
