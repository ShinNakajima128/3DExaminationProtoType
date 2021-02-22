using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
   
    [SerializeField] GameObject m_explosion;
    [SerializeField] AudioClip m_explosionSfx = null;
    [SerializeField] GameObject m_fadeController;
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("KeyItem"))
        {
            Instantiate(m_explosion, this.transform.position, this.transform.rotation);
            AudioSource.PlayClipAtPoint(m_explosionSfx, collision.transform.position);
            this.gameObject.SetActive(false);
        }
    }           
}
