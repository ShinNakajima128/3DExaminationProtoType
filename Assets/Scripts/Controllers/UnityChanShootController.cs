using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanShootController : MonoBehaviour
{
    /// <summary> UnityChanを打ち出す場所 </summary>
    [SerializeField] Transform[] m_muzzle;
    /// <summary> UnityChanを打ち出した時のSE </summary>
    [SerializeField] AudioClip[] m_Sfx;
    /// <summary> UnityChan </summary>
    [SerializeField] GameObject m_unityChan = null;
    /// <summary> 打ち出す場所をランダムにする </summary>
    int m_randomMuzzle;
    /// <summary> 打ち出した時のSEをランダムにする </summary>
    int m_randomSfx;
    void Update()
    {
        //RBボタンが押されたら、打ち出す場所とSEをランダムに決めて発射する
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            m_randomMuzzle = Random.Range(0, m_muzzle.Length);
            m_randomSfx = Random.Range(0, m_Sfx.Length);
            AudioSource.PlayClipAtPoint(m_Sfx[m_randomSfx], Camera.main.transform.position);
            Instantiate(m_unityChan, m_muzzle[m_randomMuzzle].position, m_muzzle[m_randomMuzzle].rotation);
        }
        
    }
}
