using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
   
    [SerializeField] GameObject m_Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_Explosion, this.transform.position,this.transform.rotation);
        Debug.Log(m_Explosion.transform.position);
        Destroy(this.gameObject);
    }
}
