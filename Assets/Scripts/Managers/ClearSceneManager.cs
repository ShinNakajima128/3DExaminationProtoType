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
    [SerializeField] GameObject m_resultUI;
    int m_state = 0;
    bool isStartPlay = true;

    void Update()
    {
        if (Input.anyKey && isStartPlay)
        {
            m_director.playableGraph.GetRootPlayable(0).SetSpeed(300);
            isStartPlay = false;
        }

        if (m_director.state != PlayState.Playing && m_state == 0)
        {
            m_clearMenuUI.SetActive(true);
            m_resultUI.SetActive(true);
            m_menuButton.Select();
            m_state = 1;
        }
    }

    public void pause()
    {
        m_director.Pause();
    }
}
