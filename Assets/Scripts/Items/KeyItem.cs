using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : ItemBase
{
    [SerializeField] Transform m_throwPosition;
    
    public override void Use()
    {
        Debug.Log("鍵を使用しました");
        this.transform.position = m_throwPosition.position;
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
