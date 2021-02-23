using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    /// <summary> 落下した時のエフェクト </summary>
    [SerializeField] GameObject m_deathEffect;
    /// <summary> 落下した時のSE </summary>
    [SerializeField] AudioClip m_vanishSfx = null;
    /// <summary> リスポーンした時のSE </summary>
    [SerializeField] AudioClip m_respawnSfx = null;
    /// <summary> リスポーンするまでの時間 </summary>
    [SerializeField] float m_respawnWaitTime = 4.0f;
    /// <summary> アイテムを落とした時に帰ってくる場所 </summary>
    [SerializeField] GameObject m_comeBackItemPoint;
    /// <summary> リスポーンする場所 </summary>
    public GameObject m_respawnPoint;
    /// <summary> プレイヤー </summary>
    GameObject player;
    /// <summary> リスポーンが始まったか否か </summary>
    bool isRespawn = false;
    /// <summary> タイマー </summary>
    float m_timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        ///リスポーンが始まったら
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
                //Invoke("Respawn", 4);
            }
        }
    }

    //void Respawn()
    //{

    //}

    /// <summary>
    /// プレイヤーが当たったら設定した時間後にリスポーン地点に復活し、アイテムが当たったら設定した地点にアイテムを移動させる
    /// </summary>
    /// <param name="collision"></param>
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
