using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyCartController : MonoBehaviour
{
    CinemachineDollyCart dollyCart;

    void Start()
    {
        dollyCart = this.gameObject.GetComponent<CinemachineDollyCart>();
        dollyCart.m_Speed = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(this.transform);
            dollyCart.m_Speed = 15f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
