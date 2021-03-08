using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text m_resultTimeText = null;
    [SerializeField] Text m_clearRank = null;
    /// <summary> Stageが始まってからの時間 </summary>
    public static float m_playTimer = 0;
    public static string m_stageName = "";
    float resultTime;
    bool isDisPlay = true;

    void Start()
    {
        resultTime = m_playTimer - 2;   
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ClearScene" && isDisPlay)
        {
            m_resultTimeText.text = $"<color=#>クリアタイム : {resultTime:F1}</color>";

            ///Stage1、Stage2のクリアタイムに応じてランクを表示する
            
            if (m_stageName != "Stage3")
            {
                if (resultTime < 20f)
                {
                    Debug.Log("クリアランクSS");
                    m_clearRank.text = "<color=#ffd700>SS</color>";
                }
                else if (resultTime >= 20f && resultTime < 30f)
                {
                    Debug.Log("クリアランクS");
                    m_clearRank.text = "<color=#87ceeb>S</color>";
                }
                else if (resultTime >= 30f && resultTime < 40f)
                {
                    m_clearRank.text = "<color=#dc143c>A</color>";
                }
                else if (resultTime >= 40f && resultTime < 60f)
                {
                    m_clearRank.text = "<color=#4169e1>B</color>";
                }
                else
                {
                    m_clearRank.text = "<color=#00fa9a>C</color>";
                }
            }
            else
            {
                ///Stage3のクリアタイムに応じてランクを表示する
                if (resultTime < 25f)
                {
                    Debug.Log("クリアランクSS");
                    m_clearRank.text = "<color=#ffd700>SS</color>";
                }
                else if (resultTime >= 25f && resultTime < 30f)
                {
                    Debug.Log("クリアランクS");
                    m_clearRank.text = "<color=#87ceeb>S</color>";
                }
                else if (resultTime >= 30f && resultTime < 40f)
                {
                    m_clearRank.text = "<color=#dc143c>A</color>";
                }
                else if (resultTime >= 40f && resultTime < 60f)
                {
                    m_clearRank.text = "<color=#4169e1>B</color>";
                }
                else
                {
                    m_clearRank.text = "<color=#00fa9a>C</color>";
                }
            }  
            isDisPlay = false;
        }
    }
}
