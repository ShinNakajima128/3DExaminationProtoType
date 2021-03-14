using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoTransitionManager : MonoBehaviour
{
    [SerializeField] Text m_autoTransitionTime = null;
    [SerializeField] float m_taransitionTimer = 20f;
    [SerializeField] FadeController FC;
    [SerializeField] AudioClip m_loadSfx = null;
    bool isSubtraction = true;
    bool isLoaded = true;
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
