using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoTransitionManager : MonoBehaviour
{
    /// <summary> 自動的にSceneを遷移するまでの時間を表示するText </summary>
    [SerializeField] Text m_autoTransitionTime = null;
    /// <summary> 自動的にSceneを遷移するまでの時間 </summary>
    [SerializeField] float m_taransitionTimer = 20f;
    /// <summary> 時間が切れたら画面をフェードさせるController </summary>
    [SerializeField] FadeController FC;
    /// <summary> ロードする時に鳴らすSE </summary>
    [SerializeField] AudioClip m_loadSfx = null;
    /// <summary> タイマーを減らすか否か </summary>
    bool isSubtraction = true;
    /// <summary> ロードが始まったか否か </summary>
    bool isLoaded = true;
    /// <summary> ロードする時に鳴らすためのAudioSource </summary>
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        m_autoTransitionTime.text = m_taransitionTimer.ToString("F0");

        if (isSubtraction)
        {
            m_taransitionTimer -= Time.deltaTime;
        }

        if (m_taransitionTimer <= 0 && isLoaded)
        {
            audiosource.PlayOneShot(m_loadSfx);
            isSubtraction = false;
            isLoaded = false;
            m_taransitionTimer = 0;
            FC.isFadeOut = true;
            Invoke("LoadTitle", 2);
        }
    }

    void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
