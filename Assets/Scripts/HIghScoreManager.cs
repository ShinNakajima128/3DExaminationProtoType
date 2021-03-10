using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIghScoreManager : MonoBehaviour
{
    [SerializeField] Image[] m_rank1Images = null;
    [SerializeField] Image[] m_rank2Images = null;
    [SerializeField] Image[] m_rank3Images = null;
    [SerializeField] Image[] m_rank4Images = null;
    [SerializeField] Image[] m_rank5Images = null;
    [SerializeField] Text[] m_Stage1Scoretexts = null;
    [SerializeField] Text[] m_Stage2Scoretexts = null;
    [SerializeField] Text[] m_Stage3Scoretexts = null;

    void Start()
    {
        for (int i = 0; i < m_Stage1Scoretexts.Length; i++)
        {
            m_Stage1Scoretexts[i].text =PlayerPrefs.GetFloat("Stage1Score" + i, 999.9f).ToString("F1");
        }
        if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 20f)
        {
            m_rank1Images[0].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) >= 20f && PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 30f)
        {
            m_rank1Images[1].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) >= 30f && PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 40f)
        {
            m_rank1Images[2].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) >= 40f && PlayerPrefs.GetFloat("Stage1Score1", 999.9f) < 60f)
        {
            m_rank1Images[3].enabled = true;
        }
        else if (PlayerPrefs.GetFloat("Stage1Score1", 999.9f) > 60f)
        {
            m_rank1Images[4].enabled = true;
        }

        for (int i = 0; i < m_Stage2Scoretexts.Length; i++)
        {
            m_Stage1Scoretexts[i].text = PlayerPrefs.GetFloat("Stage2Score" + i, 0f).ToString();
        }

        for (int i = 0; i < m_Stage3Scoretexts.Length; i++)
        {
            m_Stage1Scoretexts[i].text = PlayerPrefs.GetFloat("Stage3Score" + i, 0f).ToString();
        }
    }

    void Update()
    {
        
    }
}
