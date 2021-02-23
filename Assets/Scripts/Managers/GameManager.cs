using System.Collections;
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
    FadeController FC;
    AudioSource audioSource;
    /// <summary> Sceneをロードする際にこの値によって読み込むSceneを切り替える変数 </summary>
    int loadType;
    /// <summary> 現在の残り時間 </summary>
    public float m_currentTime;
    /// <summary> 再生できるかどうか </summary>
    bool isAudioPlay = true;
    /// <summary> ゲーム開始時に一度だけSEやアニメーションを再生させる用の変数 </summary>
    bool isStartPlay = true;
    /// <summary> Sceneが始まってからの時間 </summary>
    [SerializeField] float m_startTimer = 8f;

    void Start()
    {
        FC = m_fadeController.GetComponent<FadeController>();
        audioSource = GetComponent<AudioSource>();
        FC.isFadeIn = true;
        m_currentTime = m_gameTime;
    }

    void Update()
    {
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
        ///ゲーム開始時にInvoke関数に指定した時間を経過後に実行する
        if (m_UI.activeSelf && isStartPlay)
        {
            Invoke("StartPlay", m_startTimer);
        }

        if (m_currentTime < 30.0f)
        {
            if (isAudioPlay)
            {
                AudioSource.PlayClipAtPoint(m_warningSfx, Camera.main.transform.position);
                isAudioPlay = false;
            }
            m_timeUI.color = new Color(1, 0, 0, 1);
        }
        else if (m_currentTime >= 30.0f)
        {
            m_timeUI.color = new Color(1, 1, 1, 1);
            isAudioPlay = true;
        }
        if (m_currentTime <= 0.0f)
        {
            m_UI.SetActive(false);
            loadType = 6;
            FC.isFadeOut = true;
            StartCoroutine(LoadTimer());
        }

        m_timeUI.text = $"残り時間：{m_currentTime:F1}";

        //Xボタンが押されたらメニューを開き、ゲームを一時停止する
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
        //メニューを開いた状態でもう一度Xボタンを押すと、メニューを閉じる
        else if (m_menuUI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Time.timeScale = 1f;
            audioSource.PlayOneShot(m_closeMenuSfx);
            m_UI.SetActive(true);
            m_menuUI.SetActive(false);
        }
        else if (m_stageSelectMenuUI.activeSelf && Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            audioSource.PlayOneShot(m_openMenuSfx);
            m_stageSelectMenuUI.SetActive(false);
            m_menuUI.SetActive(true);
            m_menuFirstButton.Select();
        }
        //ゴールが消えたらClearSceneを読み込む
        if (!m_GoalObject.activeSelf)
        {
            m_UI.SetActive(false);
            FC.isFadeOut = true;
            loadType = 5;
            StartCoroutine(LoadTimer());
        }
        //残り時間+30を使って足した時間を表示した後、2秒後に非表示にする
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
        isStartPlay = false;
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
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            loadType = 1;
            StartCoroutine(LoadTimer());
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            loadType = 2;
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

    /// <summary>
    /// Sceneの遷移を2秒遅らせる
    /// </summary>
    /// <returns> ロードするScene </returns>
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
        else if (loadType == 5)
        {
            SceneManager.LoadScene("ClearScene");
        }
        else if (loadType == 6)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
