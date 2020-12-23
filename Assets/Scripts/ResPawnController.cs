using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPawnController : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    [SerializeField] GameObject m_respawnPoint;
    float m_timer;

    private void Update()
    {
        m_timer += Time.deltaTime;
    }
    void Respawn()
    {
        if (m_timer >= 2)
        {
            this.gameObject.SetActive(true);
            //this.transform.position = m_startPosition.transform.position;
        }
    }
}
