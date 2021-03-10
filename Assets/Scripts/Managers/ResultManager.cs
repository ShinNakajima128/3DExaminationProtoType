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
    AudioSource audioSource;

    void Start()
    {
        resultTime = m_playTimer - 2;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        m_ssRankImage.enabled = false;
        m_sRankImage.enabled = false;
        m_aRankImage.enabled = false;
        m_bRankImage.enabled = false;
        m_cRankImage.enabled = false;
    }

    void Update()
    {
        if (isDisPlay)
        {
            ResultScore();
            isDisPlay = false;
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
                    Debug.Log("クリアランクS");
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
        if (m_stageName == "Stage1")
        {
            if (resultTime > PlayerPrefs.GetFloat("Stage1Score1", 0f))
            {
                PlayerPrefs.SetFloat("Stage1Score1", resultTime);
            }
            else if (resultTime <= PlayerPrefs.GetFloat("Stage1Score1") && resultTime > PlayerPrefs.GetFloat("Stage1Score2", 0f))
            {
                PlayerPrefs.SetFloat("Stage1Score2", resultTime);
            }
            else if (resultTime <= PlayerPrefs.GetFloat("Stage1Score2") && resultTime > PlayerPrefs.GetFloat("Stage1Score3", 0f))
            {
                PlayerPrefs.SetFloat("Stage1Score3", resultTime);
            }
            else if (resultTime <= PlayerPrefs.GetFloat("Stage1Score3") && resultTime > PlayerPrefs.GetFloat("Stage1Score4", 0f))
            {
                PlayerPrefs.SetFloat("Stage1Score4", resultTime);
            }
            else if (resultTime <= PlayerPrefs.GetFloat("Stage1Score4") && resultTime > PlayerPrefs.GetFloat("Stage1Score5", 0f))
            {
                PlayerPrefs.SetFloat("Stage1Score5", resultTime);
            }
            else
            {
                return;
            }
        }
        else if (m_stageName == "Stage2")
        {

        }
        else if (m_stageName == "Stage3")
        {

        }
        else
        {
            return;
        }
    }
}
