using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
   
    [SerializeField] GameObject m_Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_Explosion, this.transform.position,this.transform.rotation);
        Destroy(this.gameObject);
    }
}
