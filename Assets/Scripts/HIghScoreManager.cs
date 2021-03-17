using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIghScoreManager : MonoBehaviour
{
    /// <summary> SSのImage </summary>
    [SerializeField] Image[] m_grade1Images = null;
    /// <summary> SのImage </summary>
    [SerializeField] Image[] m_grade2Images = null;
    /// <summary> AのImage </summary>
    [SerializeField] Image[] m_grade3Images = null;
    /// <summary> BのImage </summary>
    [SerializeField] Image[] m_grade4Images = null;
    /// <summary> CのImage </summary>
    [SerializeField] Image[] m_grade5Images = null;
    /// <summary> Stage1のScoreを表示するText </summary>
    [SerializeField] Text[] m_Stage1Scoretexts = null;
    /// <summary> Stage2のScoreを表示するText </summary>
    [SerializeField] Text[] m_Stage2Scoretexts = null;
    /// <summary> Stage3のScoreを表示するText </summary>
    [SerializeField] Text[] m_Stage3Scoretexts = null;

    public static float[] m_Stage1Score = { 999.999f, 999.999f, 999.999f, 999.999f, 999.999f};
    public static float[] m_Stage2Score = { 999.999f, 999.999f, 999.999f, 999.999f, 999.999f};
    public static float[] m_Stage3Score = { 999.999f, 999.999f, 999.999f, 999.999f, 999.999f};

    public void Stage1SetGrade()
    {
        for (int i = 0; i < m_Stage1Scoretexts.Length; i++)
        {
            m_Stage1Scoretexts[i].text = m_Stage1Score[i].ToString("F3");
        }
        Debug.Log("Stage1のGradeを更新しました");
        ///Stage1の1位のグレードを表示する
        if (m_Stage1Score[0] < 20f)
        {
            m_grade1Images[0].enabled = true;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage1Score[0] >= 20f && m_Stage1Score[0] < 30f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = true;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage1Score[0] >= 30f && m_Stage1Score[0] < 40f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = true;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage1Score[0] >= 40f && m_Stage1Score[0] < 60f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = true;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage1Score[0] > 60f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = true;
        }

        ///Stage1の2位のグレードを表示する
        if (m_Stage1Score[1] < 20f)
        {
            m_grade2Images[0].enabled = true;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage1Score[1] >= 20f && m_Stage1Score[1] < 30f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = true;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage1Score[1] >= 30f && m_Stage1Score[1] < 40f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = true;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage1Score[1] >= 40f && m_Stage1Score[1] < 60f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = true;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage1Score[1] > 60f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = true;
        }
        ///Stage1の3位のグレードを表示する
        if (m_Stage1Score[2] < 20f)
        {
            m_grade3Images[0].enabled = true;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage1Score[2] >= 20f && m_Stage1Score[2] < 30f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = true;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage1Score[2] >= 30f && m_Stage1Score[2] < 40f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = true;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage1Score[2] >= 40f && m_Stage1Score[2] < 60f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = true;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage1Score[2] > 60f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = true;
        }
        ///Stage1の4位のグレードを表示する
        if (m_Stage1Score[3] < 20f)
        {
            m_grade4Images[0].enabled = true;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage1Score[3] >= 20f && m_Stage1Score[3] < 30f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = true;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage1Score[3] >= 30f && m_Stage1Score[3] < 40f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = true;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage1Score[3] >= 40f && m_Stage1Score[3] < 60f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = true;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage1Score[3] > 60f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = true;
        }
        ///Stage1の5位のグレードを表示する
        if (m_Stage1Score[4] < 20f)
        {
            m_grade5Images[0].enabled = true;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage1Score[4] >= 20f && m_Stage1Score[4] < 30f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = true;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage1Score[4] >= 30f && m_Stage1Score[4] < 40f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = true;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage1Score[4] >= 40f && m_Stage1Score[4] < 60f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = true;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage1Score[4] > 60f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = true;
        }
    }

    public void Stage2SetGrade()
    {
        for (int i = 0; i < m_Stage2Scoretexts.Length; i++)
        {
            m_Stage2Scoretexts[i].text = m_Stage2Score[i].ToString("F3");
        }

        Debug.Log("Stage2のGradeを更新しました");

        ///Stage2の1位のグレードを表示する
        if (m_Stage2Score[0] < 20f)
        {
            m_grade1Images[0].enabled = true;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage2Score[0] >= 20f && m_Stage2Score[0] < 30f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = true;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage2Score[0] >= 30f && m_Stage2Score[0] < 40f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = true;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage2Score[0] >= 40f && m_Stage2Score[0] < 60f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = true;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage2Score[0] > 60f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = true;
        }

        ///Stage2の2位のグレードを表示する
        if (m_Stage2Score[1] < 20f)
        {
            m_grade2Images[0].enabled = true;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage2Score[1] >= 20f && m_Stage2Score[1] < 30f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = true;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage2Score[1] >= 30f && m_Stage2Score[1] < 40f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = true;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage2Score[1] >= 40f && m_Stage2Score[1] < 60f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = true;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage2Score[1] > 60f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = true;
        }
        ///Stage2の3位のグレードを表示する
        if (m_Stage2Score[2] < 20f)
        {
            m_grade3Images[0].enabled = true;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage2Score[2] >= 20f && m_Stage2Score[2] < 30f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = true;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage2Score[2] >= 30f && m_Stage2Score[2] < 40f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = true;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage2Score[2] >= 40f && m_Stage2Score[2] < 60f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = true;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage2Score[2] > 60f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = true;
        }
        ///Stage2の4位のグレードを表示する
        if (m_Stage2Score[3] < 20f)
        {
            m_grade4Images[0].enabled = true;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage2Score[3] >= 20f && m_Stage2Score[3] < 30f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = true;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage2Score[3] >= 30f && m_Stage2Score[3] < 40f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = true;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage2Score[3] >= 40f && m_Stage2Score[3] < 60f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = true;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage2Score[3] > 60f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = true;
        }
        ///Stage2の5位のグレードを表示する
        if (m_Stage2Score[4] < 20f)
        {
            m_grade5Images[0].enabled = true;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage2Score[4] >= 20f && m_Stage2Score[4] < 30f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = true;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage2Score[4] >= 30f && m_Stage2Score[4] < 40f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = true;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage2Score[4] >= 40f && m_Stage2Score[4] < 60f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = true;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage2Score[4] > 60f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = true;
        }
    }

    public void Stage3SetGrade()
    {
        for (int i = 0; i < m_Stage3Scoretexts.Length; i++)
        {
            m_Stage3Scoretexts[i].text = m_Stage3Score[i].ToString("F3");
        }

        Debug.Log("Stage3のGradeを更新しました");

        ///Stage3の1位のグレードを表示する
        if (m_Stage3Score[0] < 25f)
        {
            m_grade1Images[0].enabled = true;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage3Score[0] >= 25f && m_Stage3Score[0] < 35f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = true;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage3Score[0] >= 35f && m_Stage3Score[0] < 50f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = true;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage3Score[0] >= 50f && m_Stage3Score[0] < 70f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = true;
            m_grade1Images[4].enabled = false;
        }
        else if (m_Stage3Score[0] > 70f)
        {
            m_grade1Images[0].enabled = false;
            m_grade1Images[1].enabled = false;
            m_grade1Images[2].enabled = false;
            m_grade1Images[3].enabled = false;
            m_grade1Images[4].enabled = true;
        }

        ///Stage3の2位のグレードを表示する
        if (m_Stage3Score[1] < 25f)
        {
            m_grade2Images[0].enabled = true;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage3Score[1] >= 25f && m_Stage3Score[1] < 35f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = true;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage3Score[1] >= 35f && m_Stage3Score[1] < 50f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = true;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage3Score[1] >= 50f && m_Stage3Score[1] < 70f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = true;
            m_grade2Images[4].enabled = false;
        }
        else if (m_Stage3Score[1] > 70f)
        {
            m_grade2Images[0].enabled = false;
            m_grade2Images[1].enabled = false;
            m_grade2Images[2].enabled = false;
            m_grade2Images[3].enabled = false;
            m_grade2Images[4].enabled = true;
        }

        ///Stage3の3位のグレードを表示する
        if (m_Stage3Score[2] < 25f)
        {
            m_grade3Images[0].enabled = true;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage3Score[2] >= 25f && m_Stage3Score[2] < 35f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = true;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage3Score[2] >= 35f && m_Stage3Score[2] < 50f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = true;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage3Score[2] >= 50f && m_Stage3Score[2] < 70f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = true;
            m_grade3Images[4].enabled = false;
        }
        else if (m_Stage3Score[2] > 70f)
        {
            m_grade3Images[0].enabled = false;
            m_grade3Images[1].enabled = false;
            m_grade3Images[2].enabled = false;
            m_grade3Images[3].enabled = false;
            m_grade3Images[4].enabled = true;
        }

        ///Stage3の4位のグレードを表示する
        if (m_Stage3Score[3] < 25f)
        {
            m_grade4Images[0].enabled = true;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage3Score[3] >= 25f && m_Stage3Score[3] < 35f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = true;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage3Score[3] >= 35f && m_Stage3Score[3] < 50f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = true;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage3Score[3] >= 50f && m_Stage3Score[3] < 70f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = true;
            m_grade4Images[4].enabled = false;
        }
        else if (m_Stage3Score[3] > 70f)
        {
            m_grade4Images[0].enabled = false;
            m_grade4Images[1].enabled = false;
            m_grade4Images[2].enabled = false;
            m_grade4Images[3].enabled = false;
            m_grade4Images[4].enabled = true;
        }

        ///Stage3の5位のグレードを表示する
        if (m_Stage3Score[4] < 25f)
        {
            m_grade5Images[0].enabled = true;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage3Score[4] >= 25f && m_Stage3Score[4] < 35f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = true;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage3Score[4] >= 35f && m_Stage3Score[4] < 50f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = true;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage3Score[4] >= 50f && m_Stage3Score[4] < 70f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = true;
            m_grade5Images[4].enabled = false;
        }
        else if (m_Stage3Score[4] > 70f)
        {
            m_grade5Images[0].enabled = false;
            m_grade5Images[1].enabled = false;
            m_grade5Images[2].enabled = false;
            m_grade5Images[3].enabled = false;
            m_grade5Images[4].enabled = true;
        }
    }
}
