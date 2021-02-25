using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] PlayableDirector m_director = null;
    [SerializeField] GameObject m_StartText = null;
    [SerializeField] AudioClip m_startSfx = null;
    AudioSource audioSource;
    bool isStartPlay = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.anyKey && isStartPlay)
        {
            m_director.playableGraph.GetRootPlayable(0).SetSpeed(300);
            m_StartText.SetActive(true);
            audioSource.PlayOneShot(m_startSfx);
            isStartPlay = false;
        }
        
        if (IsDone())
        {
            Debug.Log("再生終了");
            m_StartText.SetActive(true);
            audioSource.PlayOneShot(m_startSfx);
        }
    }

    bool IsDone()
    {
        return m_director.time >= m_director.duration;
    }
}
