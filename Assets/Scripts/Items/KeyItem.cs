using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : ItemBase
{
    [SerializeField] Transform m_throwPosition;
    [SerializeField] AudioClip m_noHitSfx;
    [SerializeField] GameObject m_explosion;
    
    public override void Use()
    {
        Debug.Log("鍵を使用しました");
        this.transform.position = m_throwPosition.position;
        AudioSource.PlayClipAtPoint(m_noHitSfx, Camera.main.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Instantiate(m_explosion, this.transform.position, this.transform.rotation);
            AudioSource.PlayClipAtPoint(base.m_sfx, Camera.main.transform.position);
            this.gameObject.SetActive(false);
        }
    }
}
