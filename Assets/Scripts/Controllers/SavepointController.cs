using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavepointController : MonoBehaviour
{
    [SerializeField] GameObject m_newRespawnPoint;
    [SerializeField] GameObject m_onCheckPointEffect;
    [SerializeField] AudioClip m_checkSfx;
    [SerializeField] GameObject m_saveObjectUI = null;
    [SerializeField] GameObject m_prevGem = null;
    [SerializeField] GameObject m_afterGem = null;
    [SerializeField] RespawnController[] m_RCs = null;
    bool isCheckPoint = false;
    bool isResPawnUpdate = false;
    float m_timer;


    void Start()
    { 
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
        if (other.gameObject.tag == "Player" && !isResPawnUpdate)
        {
            AudioSource.PlayClipAtPoint(m_checkSfx, other.transform.position);
            m_prevGem.SetActive(false);
            m_afterGem.SetActive(true);
            m_onCheckPointEffect.SetActive(true);
            isCheckPoint = true;

            foreach (var rc in m_RCs)
            {
                rc.m_respawnPoint = m_newRespawnPoint;
            }

            Debug.Log("プレイヤーが範囲に入った");
            isResPawnUpdate = true;
        }
    }
}
