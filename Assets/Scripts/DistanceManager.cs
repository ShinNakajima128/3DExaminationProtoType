using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] Transform m_goalObject = null;
    [SerializeField] Transform m_player = null;
    [SerializeField] Text distanceText = null;
    string m_text;
    
    void Update()
    {
        float dist = Vector3.Distance(m_goalObject.position, m_player.position);
        m_text = dist.ToString("F1");
        distanceText.text = $" ゴールまで{m_text}m";
    }
}
