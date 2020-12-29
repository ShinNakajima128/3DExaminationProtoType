using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
   
    [SerializeField] GameObject m_explosion;
    [SerializeField] AudioClip m_explosionSfx = null;
    [SerializeField] GameObject m_fadeController;
    FadeController FC;

    private void Start()
    {
        FC = m_fadeController.GetComponent<FadeController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //FC.isFadeOut = true;
        Instantiate(m_explosion, this.transform.position,this.transform.rotation);
        AudioSource.PlayClipAtPoint(m_explosionSfx, collision.transform.position);
        Destroy(this.gameObject);
    }
}
