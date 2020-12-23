using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
   
    [SerializeField] GameObject m_explosion;
    [SerializeField] AudioClip m_explosionSfx = null;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_explosion, this.transform.position,this.transform.rotation);
        AudioSource.PlayClipAtPoint(m_explosionSfx, this.transform.position);
        Destroy(this.gameObject);
    }
}
