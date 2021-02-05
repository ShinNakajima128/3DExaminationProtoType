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
    [SerializeField] Image bottonImage;
    RespawnController RC;
    AudioSource audioSource;
    

    void Start()
    {
        RC = m_respawnSystem.GetComponent<RespawnController>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bottonImage.enabled = true;

            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                audioSource.PlayOneShot(m_touchSfx);
                Instantiate(m_touchEffect, other.transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(m_touchSfx, this.transform.position);
                RC.m_respawnPoint = m_newRespawnPoint;
            }
        }
        else
        {
            bottonImage.enabled = false;
        }
    }
}
