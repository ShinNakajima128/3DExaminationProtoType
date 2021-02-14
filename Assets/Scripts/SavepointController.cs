using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavepointController : MonoBehaviour
{
    [SerializeField] GameObject m_respawnSystem;
    [SerializeField] GameObject m_newRespawnPoint;
    [SerializeField] GameObject m_onCheckPointEffect;
    [SerializeField] AudioClip m_checkSfx;
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
        m_onCheckPointEffect.SetActive(false);
    }

    void Update()
    {
        if (isCheckPoint)
        {
            m_timer += Time.deltaTime;
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
            AudioSource.PlayClipAtPoint(m_checkSfx, other.transform.position);
            m_onCheckPointEffect.SetActive(true);
            isCheckPoint = true;
            RC.m_respawnPoint = m_newRespawnPoint;
            Debug.Log("プレイヤーが範囲に入った");
        }
    }
}
