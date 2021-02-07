using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelectController : MonoBehaviour
{
    [SerializeField] GameObject m_fadeController;
    FadeController FC;
    float m_timer;
    int m_SceneLoadTime = 2;

    void Start()
    {
        FC = m_fadeController.GetComponent<FadeController>();
        FC.isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
