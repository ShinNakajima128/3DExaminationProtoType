using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchorController : MonoBehaviour
{
    [SerializeField] Transform m_goal;
    GameObject m_player;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 position = m_player.transform.position;
        position.x = m_goal.position.x;
        position.z = m_goal.position.z;
        position.y = m_goal.position.y;
        this.transform.position = position;
    }
}
