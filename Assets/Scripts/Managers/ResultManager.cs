using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    /// <summary> クリアタイムのText </summary>
    [SerializeField] Text m_resultTimeText = null;
    /// <summary> SSランク時のSE </summary>
    [SerializeField] AudioClip m_rankSfx = null;
    /// <summary> SSランクのImage </summary>
    [SerializeField] Image m_ssRankImage = null;
    /// <summary> SランクのImage </summary>
    [SerializeField] Image m_sRankImage = null;
    /// <summary> AランクのImage </summary>
    [SerializeField] Image m_aRankImage = null;
    /// <summary> BランクのImage </summary>
    [SerializeField] Image m_bRankImage = null;
    /// <summary> CランクのImage </summary>
    [SerializeField] Image m_cRankImage = null;
    /// <summary> Stageが始まってからの時間 </summary>
    public static float m_playTimer = 0;
    public static string m_stageName = "";
    float resultTime;
    bool isDisPlay = true;
    bool isSaved = true;
    AudioSource audioSource;

    void Start()
    {
        resultTime = m_playTimer - 2;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDisPlay)
        {
            ResultScore();
            isDisPlay = false;
        }   
    }
    void LateUpdate()
    {
        if (isSaved)
        {
            SaveClearTime();
            isSaved = false;
        }
    }

    void ResultScore()
    {
        ///現在のSceneがClearSceneだったら、ランクとクリアタイムを表示する
        if (SceneManager.GetActiveScene().name == "ClearScene")
        {
            m_resultTimeText.text = $"<color=#>クリアタイム : {resultTime:F1}</color>";

            ///Stage1、Stage2のクリアタイムに応じてランクを表示する

            if (m_stageName != "Stage3")
            {
                audioSource.PlayOneShot(m_rankSfx, 0.5f);

                if (resultTime < 20f)
                {
                    m_ssRankImage.enabled = true;
                }
                else if (resultTime >= 20f && resultTime < 30f)
                {
                    m_sRankImage.enabled = true;
                }
                else if (resultTime >= 30f && resultTime < 40f)
                {
                    m_aRankImage.enabled = true;
                }
                else if (resultTime >= 40f && resultTime < 60f)
                {
                    m_bRankImage.enabled = true;
                }
                else
                {
                    m_cRankImage.enabled = true;
                }
            }
            else
            {
                audioSource.PlayOneShot(m_rankSfx, 0.5f);

                ///Stage3のクリアタイムに応じてランクを表示する
                if (resultTime < 25f)
                {
                    m_ssRankImage.enabled = true;
                }
                else if (resultTime >= 25f && resultTime < 35f)
                {
                    m_sRankImage.enabled = true;
                }
                else if (resultTime >= 35f && resultTime < 50f)
                {
                    m_aRankImage.enabled = true;
                }
                else if (resultTime >= 50f && resultTime < 70f)
                {
                    m_bRankImage.enabled = true;
                }
                else
                {
                    m_cRankImage.enabled = true;
                }
            }
        }
    }

    void SaveClearTime()
    {
        if (SceneManager.GetActiveScene().name == "ClearScene" && m_stageName == "Stage1")
        {
            if (resultTime < HIghScoreManager.m_Stage1Score[0])
            {
                //PlayerPrefs.SetFloat("Stage1Score1", resultTime);
                Debug.Log($"Stage1の1位が更新されました:{resultTime}");
                HIghScoreManager.m_Stage1Score[0] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage1Score[0] && resultTime < HIghScoreManager.m_Stage1Score[1])
            {
                //PlayerPrefs.SetFloat("Stage1Score2", resultTime);
                HIghScoreManager.m_Stage1Score[1] = resultTime;
                Debug.Log("Stage1の2位が更新されました");
            }
            else if (resultTime >= HIghScoreManager.m_Stage1Score[1] && resultTime < HIghScoreManager.m_Stage1Score[2])
            {
                //PlayerPrefs.SetFloat("Stage1Score3", resultTime);
                HIghScoreManager.m_Stage1Score[2] = resultTime;
                Debug.Log("Stage1の3位が更新されました");
            }
            else if (resultTime >= HIghScoreManager.m_Stage1Score[2] && resultTime < HIghScoreManager.m_Stage1Score[3])
            {
                //PlayerPrefs.SetFloat("Stage1Score4", resultTime);
                HIghScoreManager.m_Stage1Score[3] = resultTime;
                Debug.Log("Stage1の4位が更新されました");
            }
            else if (resultTime >= HIghScoreManager.m_Stage1Score[3] && resultTime < HIghScoreManager.m_Stage1Score[4])
            {
                //PlayerPrefs.SetFloat("Stage1Score5", resultTime);
                HIghScoreManager.m_Stage1Score[4] = resultTime;
                Debug.Log("Stage1の5位が更新されました");
            }
            else
            {
                return;
            }
            //PlayerPrefs.Save();
        }
        else if (SceneManager.GetActiveScene().name == "ClearScene" && m_stageName == "Stage2")
        {
            if (resultTime < HIghScoreManager.m_Stage2Score[0])
            {
                //PlayerPrefs.SetFloat("Stage2Score1", resultTime);
                HIghScoreManager.m_Stage2Score[0] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage2Score[0] && resultTime < HIghScoreManager.m_Stage2Score[1])
            {
                //PlayerPrefs.SetFloat("Stage2Score2", resultTime);
                HIghScoreManager.m_Stage2Score[1] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage2Score[1] && resultTime < HIghScoreManager.m_Stage2Score[2])
            {
                //PlayerPrefs.SetFloat("Stage2Score3", resultTime);
                HIghScoreManager.m_Stage2Score[2] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage2Score[2] && resultTime < HIghScoreManager.m_Stage2Score[3])
            {
                //PlayerPrefs.SetFloat("Stage2Score4", resultTime);
                HIghScoreManager.m_Stage2Score[3] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage2Score[3] && resultTime < HIghScoreManager.m_Stage2Score[4])
            {
                //PlayerPrefs.SetFloat("Stage2Score5", resultTime);
                HIghScoreManager.m_Stage2Score[4] = resultTime;
            }
            else
            {
                return;
            }
            //PlayerPrefs.Save();
        }
        else if (SceneManager.GetActiveScene().name == "ClearScene" && m_stageName == "Stage3")
        {
            if (resultTime < HIghScoreManager.m_Stage3Score[0])
            {
                //PlayerPrefs.SetFloat("Stage3Score1", resultTime);
                HIghScoreManager.m_Stage3Score[0] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage3Score[0] && resultTime < HIghScoreManager.m_Stage3Score[1])
            {
                //PlayerPrefs.SetFloat("Stage3Score2", resultTime);
                HIghScoreManager.m_Stage3Score[1] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage3Score[1] && resultTime < HIghScoreManager.m_Stage3Score[2])
            {
                //PlayerPrefs.SetFloat("Stage3Score3", resultTime);
                HIghScoreManager.m_Stage3Score[2] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage3Score[2] && resultTime < HIghScoreManager.m_Stage3Score[3])
            {
                //PlayerPrefs.SetFloat("Stage3Score4", resultTime);
                HIghScoreManager.m_Stage3Score[3] = resultTime;
            }
            else if (resultTime >= HIghScoreManager.m_Stage3Score[3] && resultTime < HIghScoreManager.m_Stage3Score[4])
            {
                //PlayerPrefs.SetFloat("Stage3Score5", resultTime);
                HIghScoreManager.m_Stage3Score[4] = resultTime;
            }
            else
            {
                return;
            }
            //PlayerPrefs.Save();
        }
        else
        {
            return;
        }
    }
}
