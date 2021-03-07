using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyCartController : MonoBehaviour
{
    CinemachineDollyCart dollyCart;
    PlayerControllerRbEx player;
    Rigidbody m_rb;
    

    void Start()
    {
        dollyCart = this.gameObject.GetComponent<CinemachineDollyCart>();
        dollyCart.m_Speed = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerControllerRbEx>();
            m_rb = other.gameObject.GetComponent<Rigidbody>();
            player.PlayerOperation = false;
            m_rb.useGravity = false;
            other.gameObject.transform.SetParent(this.transform);
            dollyCart.m_Speed = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.PlayerOperation = true;
            m_rb.useGravity = true;
            other.gameObject.transform.SetParent(null);
            dollyCart.m_Speed = 0f;
        }
    }
}
