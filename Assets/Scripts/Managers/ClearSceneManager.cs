using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ClearSceneManager : MonoBehaviour
{
    /// <summary> クリア時に表示するメニューのUI </summary>
    [SerializeField] GameObject m_clearMenuUI;
    /// <summary> メニューを表示した時にSelect()するButton </summary>
    [SerializeField] Button m_menuButton;
    /// <summary> ステージを選択するメニューのUI </summary>
    [SerializeField] GameObject m_stageSelectMenuUI;
    /// <summary> ステージセレクトメニューを表示した時にSelect()するButton </summary>
    [SerializeField] Button m_stageSelectButton;
    /// <summary> ClearSceneで最初に再生するTimeline </summary>
    [SerializeField] PlayableDirector m_director;
    /// <summary> ClearSceneを管理しているManagerで表示するUI </summary>
    [SerializeField] GameObject m_resultUI;
    /// <summary> 自動でTitleに遷移する時間を表示するUI </summary>
    [SerializeField] GameObject m_AutoTransitionUI = null;
    /// <summary> Timelineの再生が終了したかを確認する変数 </summary>
    int m_state = 0;
    /// <summary> Timelineが再生中か否か </summary>
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
            m_AutoTransitionUI.SetActive(true);
            m_state = 1;
        }
    }

    public void pause()
    {
        m_director.Pause();
    }
}
