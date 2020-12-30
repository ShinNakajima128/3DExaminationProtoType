using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] GameObject m_UI;
    [SerializeField] GameObject m_menuUI;

    void Start()
    {
        m_UI.SetActive(true);
        m_menuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Xが押されました");
            m_UI.SetActive(false);
            m_menuUI.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                m_UI.SetActive(true);
                m_menuUI.SetActive(false);
            }
        }
    }
}
