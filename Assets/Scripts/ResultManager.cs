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

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "ClearScene")
        {
            m_playTimer = 0;
        }
        resultTime = m_playTimer;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ClearScene")
        {
            m_resultTimeText.text = $"クリアタイム : {resultTime:F1}";

            if (SceneManager.GetActiveScene().name == "stage1")
            {
                if (resultTime < 15f)
                {
                    m_clearRank.text = "Test";
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
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {

            }
        }
    }
}
