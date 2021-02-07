using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button m_button;
    void Start()
    {
        m_button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
