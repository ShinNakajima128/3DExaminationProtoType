using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text m_resultTimeText = null;
    [SerializeField] Text m_clearRank = null;
    [SerializeField] AudioClip m_rankSfx = null;
    [SerializeField] Image m_ssRankImage = null;
    [SerializeField] Image m_sRankImage = null;
    [SerializeField] Image m_aRankImage = null;
    [SerializeField] Image m_bRankImage = null;
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
        if (SceneManager.GetActiveScene().name == "ClearScene" && isDisPlay)
        {
            m_resultTimeText.text = $"<color=#>クリアタイム : {resultTime:F1}</color>";

            ///Stage1、Stage2のクリアタイムに応じてランクを表示する
            
            if (m_stageName != "Stage3")
            {
                audioSource.PlayOneShot(m_rankSfx, 0.5f);

                if (resultTime < 20f)
                {
                    m_ssRankImage.enabled = true;
                    //m_clearRank.text = "<color=#ffd700>SS</color>";   
                }
                else if (resultTime >= 20f && resultTime < 30f)
                {
                    Debug.Log("クリアランクS");
                    m_sRankImage.enabled = true;
                    //m_clearRank.text = "<color=#87ceeb>S</color>";
                }
                else if (resultTime >= 30f && resultTime < 40f)
                {
                    m_aRankImage.enabled = true;
                    //m_clearRank.text = "<color=#dc143c>A</color>";
                }
                else if (resultTime >= 40f && resultTime < 60f)
                {
                    m_bRankImage.enabled = true;
                    //m_clearRank.text = "<color=#4169e1>B</color>";
                }
                else
                {
                    m_cRankImage.enabled = true;
                    //m_clearRank.text = "<color=#00fa9a>C</color>";
                }
            }
            else
            {
                audioSource.PlayOneShot(m_rankSfx, 0.5f);

                ///Stage3のクリアタイムに応じてランクを表示する
                if (resultTime < 25f)
                {
                    m_ssRankImage.enabled = true;
                    //m_clearRank.text = "<color=#ffd700>SS</color>";
                }
                else if (resultTime >= 25f && resultTime < 35f)
                {
                    m_sRankImage.enabled = true;
                    //m_clearRank.text = "<color=#87ceeb>S</color>";
                }
                else if (resultTime >= 35f && resultTime < 50f)
                {
                    m_aRankImage.enabled = true;
                    //m_clearRank.text = "<color=#dc143c>A</color>";
                }
                else if (resultTime >= 50f && resultTime < 70f)
                {
                    m_bRankImage.enabled = true;
                    //.text = "<color=#4169e1>B</color>";
                }
                else
                {
                    m_cRankImage.enabled = true;
                    //m_clearRank.text = "<color=#00fa9a>C</color>";
                }
            }  
            isDisPlay = false;
        }
    }
}
