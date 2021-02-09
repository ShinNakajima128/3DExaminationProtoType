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
        bottonImage.enabled = false;
    }

    void Update()
    {
        if (bottonImage.enabled && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("Bが押されました");
            audioSource.PlayOneShot(m_touchSfx);
            //Instantiate(m_touchEffect, transform.position, Quaternion.identity);
            //AudioSource.PlayClipAtPoint(m_touchSfx, this.transform.position);
            RC.m_respawnPoint = m_newRespawnPoint;
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        bottonImage.enabled = true;
    //        Debug.Log("プレイヤーが範囲に入った");

    //        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
    //        {
    //            Debug.Log("Bが押されました");
    //            audioSource.PlayOneShot(m_touchSfx);
    //            Instantiate(m_touchEffect, other.transform.position, Quaternion.identity);
    //            AudioSource.PlayClipAtPoint(m_touchSfx, this.transform.position);
    //            RC.m_respawnPoint = m_newRespawnPoint;
    //        }
    //    }
    //    else
    //    {
    //        bottonImage.enabled = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            bottonImage.enabled = true;
            Debug.Log("プレイヤーが範囲に入った");
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
           
    //        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
    //        {
    //            Debug.Log("Bが押されました");
    //            audioSource.PlayOneShot(m_touchSfx);
    //            Instantiate(m_touchEffect, other.transform.position, Quaternion.identity);
    //            AudioSource.PlayClipAtPoint(m_touchSfx, this.transform.position);
    //            RC.m_respawnPoint = m_newRespawnPoint;
    //        }
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        bottonImage.enabled = false;
    }
}
