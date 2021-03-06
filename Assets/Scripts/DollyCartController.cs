using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyCartController : MonoBehaviour
{
    CinemachineDollyCart dollyCart;
    PlayerControllerRbEx player;
    

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
            player.PlayerOperation = false;
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
        }
    }
}
