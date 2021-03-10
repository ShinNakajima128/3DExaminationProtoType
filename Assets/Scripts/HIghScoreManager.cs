using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIghScoreManager : MonoBehaviour
{
    [SerializeField] Image[] m_rankImages = null;
    [SerializeField] Text[] m_Stage1Scoretexts = null;
    [SerializeField] Text[] m_Stage2Scoretexts = null;
    [SerializeField] Text[] m_Stage3Scoretexts = null;

    void Start()
    {
        for (int i = 0; i < m_Stage1Scoretexts.Length; i++)
        {
            m_Stage1Scoretexts[i].text = PlayerPrefs.GetFloat("Stage1Score" + i, 0f).ToString();
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
