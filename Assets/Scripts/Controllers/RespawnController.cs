﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
   
    [SerializeField] GameObject m_deathEffect;
    [SerializeField] AudioClip m_vanishSfx = null;
    [SerializeField] AudioClip m_respawnSfx = null;
    [SerializeField] float m_respawnWaitTime = 4.0f;
    [SerializeField] GameObject m_comeBackItemPoint;
    public GameObject m_respawnPoint;
    GameObject player;
    bool isRespawn = false;
    float m_timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (isRespawn)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_respawnWaitTime)
            {
                m_timer = 0;
                isRespawn = false;
                player.SetActive(true);
                player.transform.position = m_respawnPoint.transform.position;
                AudioSource.PlayClipAtPoint(m_respawnSfx, m_respawnPoint.transform.position);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(m_deathEffect, collision.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(m_vanishSfx, collision.transform.position);
            collision.gameObject.SetActive(false);
            isRespawn = true;
        }
        else if (collision.gameObject.CompareTag("KeyItem"))
        {
            collision.transform.position = m_comeBackItemPoint.transform.position;
        }
    }
}