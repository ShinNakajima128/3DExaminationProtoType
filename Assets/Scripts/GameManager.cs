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
    [SerializeField] GameObject m_fadeController;
    [SerializeField] AudioClip m_MenuSfx;
    FadeController FC;
    AudioSource audioSource;
    bool isLoadStarted = false;
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
        FC = m_fadeController.GetComponent<FadeController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (m_UI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Xが押されました");
            audioSource.PlayOneShot(m_MenuSfx);
            m_UI.SetActive(false);
            m_menuUI.GetComponent<Canvas>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                menuState = State.Restart;
            }
        }
        else if (!m_UI.activeSelf && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioSource.PlayOneShot(m_MenuSfx);
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
                Restart();
                break;
            case State.StageSelect:
                StageSelect();
                break;
            case State.Exit:
                GameExit();
                break;
        }
    }
    void Restart()
    {

    }

    void StageSelect()
    {

    }

    private void GameExit()
    {
        
    }
}
