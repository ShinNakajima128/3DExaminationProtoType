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
    State menuState;
    int stateCount;

    enum State
    {
        Restart,
        StageSelect,
        Exit
    }

    void Start()
    {
        //m_menuUI.SetActive(false);
    }

    void Update()
    {
        if (m_UI.activeSelf == true && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Xが押されました");
            m_UI.SetActive(false);
            m_menuUI.GetComponent<Canvas>().enabled = true;
        }
        else if (m_UI.activeSelf == false && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            m_UI.SetActive(true);
            m_menuUI.GetComponent<Canvas>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        switch (menuState)
        {
            default:
            case State.Restart:
                break;
            case State.StageSelect:
                break;
            case State.Exit:
                break;
        }
    }
}
