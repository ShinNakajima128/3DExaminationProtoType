using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : ItemBase
{
    [SerializeField] Transform m_throwPosition;
    [SerializeField] float m_throwPower = 10f;
    Rigidbody m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    public override void Use()
    {
        Debug.Log("鍵を使用しました");
        this.transform.position = m_throwPosition.position;
        m_rb.useGravity = true;
        m_rb.AddForce(transform.forward * m_throwPower, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            //Instantiate(m_explosion, this.transform.position, this.transform.rotation);
            //AudioSource.PlayClipAtPoint(m_explosionSfx, collision.transform.position);
            this.gameObject.SetActive(false);
        }
    }
}
