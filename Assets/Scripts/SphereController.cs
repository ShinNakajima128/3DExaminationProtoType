using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    Rigidbody m_rb;
    [SerializeField] GameObject m_exprosion;

    void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_exprosion);
        Destroy(this.gameObject);
    }
}
