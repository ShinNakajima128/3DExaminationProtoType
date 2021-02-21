using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityChanShootController : MonoBehaviour
{
    [SerializeField] Transform[] m_muzzle;
    [SerializeField] AudioClip[] m_Sfx;
    [SerializeField] GameObject m_unityChan = null;
    int m_randomMuzzle;
    int m_randomSfx;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            m_randomMuzzle = Random.Range(0, m_muzzle.Length);
            m_randomSfx = Random.Range(0, m_Sfx.Length);
            AudioSource.PlayClipAtPoint(m_Sfx[m_randomSfx], Camera.main.transform.position);
            Instantiate(m_unityChan, m_muzzle[m_randomMuzzle].position, m_muzzle[m_randomMuzzle].rotation);
        }
        
    }
}
