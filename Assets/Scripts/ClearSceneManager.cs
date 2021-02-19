using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ClearSceneManager : MonoBehaviour
{
    [SerializeField] GameObject m_clearMenuUI;
    [SerializeField] Button m_menuButton;
    [SerializeField] GameObject m_stageSelectMenuUI;
    [SerializeField] Button m_stageSelectButton;
    [SerializeField] PlayableDirector m_director;
    bool isEnd = false;
    int m_state = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (m_director.state != PlayState.Playing && m_state == 0)
        {
            m_clearMenuUI.SetActive(true);
            m_menuButton.Select();
            isEnd = true;
            m_state = 1;
        }
    }

    public void pause()
    {
        m_director.Pause();
    }
}
