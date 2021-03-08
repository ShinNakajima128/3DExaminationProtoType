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

            isDisPlay = false;
            //if (SceneManager.GetActiveScene().name == "stage1")
            //{
            //    if (resultTime < 15f)
            //    {
            //        Debug.Log("クリアランクS");
            //        m_clearRank.text = "S";
            //    }
            //    else if (resultTime >= 15f && resultTime < 30f)
            //    {
            //        m_clearRank.text = "A";
            //    }
            //    else if (resultTime >= 30f && resultTime < 60f)
            //    {
            //        m_clearRank.text = "B";
            //    }
            //    else
            //    {
            //        m_clearRank.text = "C";
            //    }
            //}
            //else if (SceneManager.GetActiveScene().name == "Stage2")
            //{
            //    if (resultTime < 30f)
            //    {
            //        m_clearRank.text = "S";
            //    }
            //    else if (resultTime >= 30f && resultTime < 45f)
            //    {
            //        m_clearRank.text = "A";
            //    }
            //    else if (resultTime >= 45f && resultTime < 60f)
            //    {
            //        m_clearRank.text = "B";
            //    }
            //    else
            //    {
            //        m_clearRank.text = "C";
            //    }
            //}
        }
    }
}
