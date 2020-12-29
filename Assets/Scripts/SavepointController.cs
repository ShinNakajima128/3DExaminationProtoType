using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavepointController : MonoBehaviour
{
    [SerializeField] GameObject m_respawnSystem;
    [SerializeField] GameObject m_newRespawnPoint;
    [SerializeField] GameObject m_touchEffect;
    [SerializeField] Image m_bButton;
    [SerializeField] AudioClip m_touchSfx;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(m_touchSfx);

            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Instantiate(m_touchEffect, this.transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(m_touchSfx, this.transform.position);
                RC.m_respawnPoint = m_newRespawnPoint;
            }
        }
    }
}
