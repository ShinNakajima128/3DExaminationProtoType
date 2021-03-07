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
        dollyCart.m_Position = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerControllerRbEx>();
            m_rb = other.gameObject.GetComponent<Rigidbody>();
            player.PlayerOperation = false;
            m_rb.velocity = new Vector3(0f, 0f, 0f);
            other.gameObject.transform.SetParent(this.transform);
            dollyCart.m_Speed = 15f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.PlayerOperation = true;
            other.gameObject.transform.SetParent(null);
            dollyCart.m_Speed = 0f;
            dollyCart.m_Position = 0f;
        }
    }
}
