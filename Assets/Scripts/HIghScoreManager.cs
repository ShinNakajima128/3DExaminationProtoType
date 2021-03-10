using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIghScoreManager : MonoBehaviour
{
    [SerializeField] Image[] m_grade1Images = null;
    [SerializeField] Image[] m_grade2Images = null;
    [SerializeField] Image[] m_grade3Images = null;
    [SerializeField] Image[] m_grade4Images = null;
    [SerializeField] Image[] m_grade5Images = null;
    [SerializeField] Text[] m_Stage1Scoretexts = null;
    [SerializeField] Text[] m_Stage2Scoretexts = null;
    [SerializeField] Text[] m_Stage3Scoretexts = null;

    void Start()
    {
        for (int i = 0; i < m_Stage1Scoretexts.Length; i++)
        {
            m_Stage1Scoretexts[i].text =PlayerPrefs.GetFloat("Stage1Score" + i, 999.9f).ToString("F1");
        }

        Stage1SetGrade();

        for (int i = 0; i < m_Stage2Scoretexts.Length; i++)
        {
            m_Stage2Scoretexts[i].text = PlayerPrefs.GetFloat("Stage2Score" + i, 999.9f).ToString("F1");
        }

        Stage2SetGrade();

        for (int i = 0; i < m_Stage3Scoretexts.Length; i++)
        {
            m_Stage3Scoretexts[i].text = PlayerPrefs.GetFloat("Stage3Score" + i, 999.9f).ToString("F1");
        }

        Stage3SetGrade();
    }

    void Stage1SetGrade()
    {
        ///Stage1の1位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 20f)
        {
            m_grade1Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 30f)
        {
            m_grade1Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 40f)
        {
            m_grade1Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 60f)
        {
            m_grade1Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) > 60f)
        {
            m_grade1Images[4].enabled = true;
        }
        ///Stage1の2位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage1Score2", 999.9f) < 20f)
        {
            m_grade2Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score2", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage1Score2", 999.9f) < 30f)
        {
            m_grade2Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score2", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage1Score2", 999.9f) < 40f)
        {
            m_grade2Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score2", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage1Score2", 999.9f) < 60f)
        {
            m_grade2Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score2", 999.9f) > 60f)
        {
            m_grade2Images[4].enabled = true;
        }
        ///Stage1の3位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage1Score3", 999.9f) < 20f)
        {
            m_grade3Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score3", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage1Score3", 999.9f) < 30f)
        {
            m_grade3Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score3", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage1Score3", 999.9f) < 40f)
        {
            m_grade3Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score3", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage1Score3", 999.9f) < 60f)
        {
            m_grade3Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score3", 999.9f) > 60f)
        {
            m_grade3Images[4].enabled = true;
        }
        ///Stage1の4位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage1Score4", 999.9f) < 20f)
        {
            m_grade4Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score4", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage1Score4", 999.9f) < 30f)
        {
            m_grade4Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score4", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage1Score4", 999.9f) < 40f)
        {
            m_grade4Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score4", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage1Score4", 999.9f) < 60f)
        {
            m_grade4Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score4", 999.9f) > 60f)
        {
            m_grade4Images[4].enabled = true;
        }
        ///Stage1の5位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage1Score5", 999.9f) < 20f)
        {
            m_grade5Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score5", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage1Score5", 999.9f) < 30f)
        {
            m_grade5Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score5", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage1Score5", 999.9f) < 40f)
        {
            m_grade5Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score5", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage1Score5", 999.9f) < 60f)
        {
            m_grade5Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score5", 999.9f) > 60f)
        {
            m_grade5Images[4].enabled = true;
        }
    }

    void Stage2SetGrade()
    {
        ///Stage2の1位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage2Score1", 999.9f) < 20f)
        {
            m_grade1Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score1", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage2Score1", 999.9f) < 30f)
        {
            m_grade1Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score1", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage2Score1", 999.9f) < 40f)
        {
            m_grade1Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score1", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage2Score1", 999.9f) < 60f)
        {
            m_grade1Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score1", 999.9f) > 60f)
        {
            m_grade1Images[4].enabled = true;
        }
        ///Stage2の2位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage2Score2", 999.9f) < 20f)
        {
            m_grade2Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score2", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage2Score2", 999.9f) < 30f)
        {
            m_grade2Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score2", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage2Score2", 999.9f) < 40f)
        {
            m_grade2Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score2", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage2Score2", 999.9f) < 60f)
        {
            m_grade2Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score2", 999.9f) > 60f)
        {
            m_grade2Images[4].enabled = true;
        }
        ///Stage2の3位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage2Score3", 999.9f) < 20f)
        {
            m_grade3Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score3", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage2Score3", 999.9f) < 30f)
        {
            m_grade3Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score3", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage2Score3", 999.9f) < 40f)
        {
            m_grade3Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score3", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage2Score3", 999.9f) < 60f)
        {
            m_grade3Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score3", 999.9f) > 60f)
        {
            m_grade3Images[4].enabled = true;
        }
        ///Stage2の4位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage2Score4", 999.9f) < 20f)
        {
            m_grade4Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score4", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage2Score4", 999.9f) < 30f)
        {
            m_grade4Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score4", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage2Score4", 999.9f) < 40f)
        {
            m_grade4Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score4", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage2Score4", 999.9f) < 60f)
        {
            m_grade4Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score4", 999.9f) > 60f)
        {
            m_grade4Images[4].enabled = true;
        }
        ///Stage2の5位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage2Score5", 999.9f) < 20f)
        {
            m_grade5Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score5", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage2Score5", 999.9f) < 30f)
        {
            m_grade5Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score5", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage2Score5", 999.9f) < 40f)
        {
            m_grade5Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score5", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage2Score5", 999.9f) < 60f)
        {
            m_grade5Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage2Score5", 999.9f) > 60f)
        {
            m_grade5Images[4].enabled = true;
        }
    }

    void Stage3SetGrade()
    {
        ///Stage3の1位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage3Score1", 999.9f) < 25f)
        {
            m_grade1Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score1", 999.9f) >= 25f && PlayerPrefs.GetFloat("Stage3Score1", 999.9f) < 35f)
        {
            m_grade1Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score1", 999.9f) >= 35f && PlayerPrefs.GetFloat("Stage3Score1", 999.9f) < 50f)
        {
            m_grade1Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score1", 999.9f) >= 50f && PlayerPrefs.GetFloat("Stage3Score1", 999.9f) < 70f)
        {
            m_grade1Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score1", 999.9f) > 70f)
        {
            m_grade1Images[4].enabled = true;
        }
        ///Stage3の2位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage3Score2", 999.9f) < 25f)
        {
            m_grade2Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score2", 999.9f) >= 25f && PlayerPrefs.GetFloat("Stage3Score2", 999.9f) < 35f)
        {
            m_grade2Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score2", 999.9f) >= 35f && PlayerPrefs.GetFloat("Stage3Score2", 999.9f) < 50f)
        {
            m_grade2Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score2", 999.9f) >= 50f && PlayerPrefs.GetFloat("Stage3Score2", 999.9f) < 70f)
        {
            m_grade2Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score2", 999.9f) > 70f)
        {
            m_grade2Images[4].enabled = true;
        }
        ///Stage3の3位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage3Score3", 999.9f) < 25f)
        {
            m_grade3Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score3", 999.9f) >= 25f && PlayerPrefs.GetFloat("Stage3Score3", 999.9f) < 35f)
        {
            m_grade3Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score3", 999.9f) >= 35f && PlayerPrefs.GetFloat("Stage3Score3", 999.9f) < 50f)
        {
            m_grade3Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score3", 999.9f) >= 50f && PlayerPrefs.GetFloat("Stage3Score3", 999.9f) < 70f)
        {
            m_grade3Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score3", 999.9f) > 70f)
        {
            m_grade3Images[4].enabled = true;
        }
        ///Stage3の4位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage3Score4", 999.9f) < 25f)
        {
            m_grade4Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score4", 999.9f) >= 25f && PlayerPrefs.GetFloat("Stage3Score4", 999.9f) < 35f)
        {
            m_grade4Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score4", 999.9f) >= 35f && PlayerPrefs.GetFloat("Stage3Score4", 999.9f) < 50f)
        {
            m_grade4Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score4", 999.9f) >= 50f && PlayerPrefs.GetFloat("Stage3Score4", 999.9f) < 70f)
        {
            m_grade4Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score4", 999.9f) > 70f)
        {
            m_grade4Images[4].enabled = true;
        }
        ///Stage3の5位のグレードを表示する
        if (PlayerPrefs.GetFloat("Stage3Score5", 999.9f) < 25f)
        {
            m_grade5Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score5", 999.9f) >= 25f && PlayerPrefs.GetFloat("Stage3Score5", 999.9f) < 35f)
        {
            m_grade5Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score5", 999.9f) >= 35f && PlayerPrefs.GetFloat("Stage3Score5", 999.9f) < 50f)
        {
            m_grade5Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score5", 999.9f) >= 50f && PlayerPrefs.GetFloat("Stage3Score5", 999.9f) < 70f)
        {
            m_grade5Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage3Score5", 999.9f) > 70f)
        {
            m_grade5Images[4].enabled = true;
        }
    }
}
