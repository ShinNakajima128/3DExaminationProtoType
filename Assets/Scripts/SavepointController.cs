using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavepointController : MonoBehaviour
{
    [SerializeField] GameObject m_respawnSystem;
    [SerializeField] GameObject m_newRespawnPoint;
    [SerializeField] GameObject m_touchEffect;
    [SerializeField] AudioClip m_touchSfx;
    [SerializeField] GameObject m_saveObjectUI = null;
    RespawnController RC;
    AudioSource audioSource;
    bool isCheckPoint = false;
    float m_timer;


    void Start()
    {
        RC = m_respawnSystem.GetComponent<RespawnController>();
        audioSource = GetComponent<AudioSource>();
        m_saveObjectUI.SetActive(false);
    }

    void Update()
    {
        if (isCheckPoint)
        {
            m_timer += Time.deltaTime;
            Debug.Log(m_timer);
            m_saveObjectUI.SetActive(true);
            
            if (m_timer >= 3)
            {
                m_saveObjectUI.SetActive(false);
                isCheckPoint = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCheckPoint = true;
            RC.m_respawnPoint = m_newRespawnPoint;
            Debug.Log("プレイヤーが範囲に入った");
        }
    }
}
