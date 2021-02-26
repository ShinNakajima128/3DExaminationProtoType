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
        resultTime = m_playTimer;
        //m_clearRank.text = "S";
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ClearScene" && isDisPlay)
        {
            m_resultTimeText.text = $"クリアタイム : {resultTime:F1}";

            if (resultTime < 15f)
            {
                Debug.Log("クリアランクS");
                m_clearRank.text = "S";
            }
            else if (resultTime >= 15f && resultTime < 30f)
            {
                m_clearRank.text = "A";
            }
            else if (resultTime >= 30f && resultTime < 60f)
            {
                m_clearRank.text = "B";
            }
            else
            {
                m_clearRank.text = "C";
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
