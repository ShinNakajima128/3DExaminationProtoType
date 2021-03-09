using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HookshotController : MonoBehaviour
{
    [SerializeField] Transform m_muzzle;
    [SerializeField] Camera m_playerCamera;
    [SerializeField] float m_maxWireDistance = 100f;
    [SerializeField] float m_hookshotSpeed = 5f;
    Rigidbody m_rb;
    LineRenderer m_line;
    Vector3 hookshotPosition;
    State state;

    enum State
    {
        Normal,
        HookshotFlyingPlayer
    }
    
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_line = GetComponent<LineRenderer>();
        state = State.Normal;
        
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HookshotStart();
                break;
            case State.HookshotFlyingPlayer:
                m_line.positionCount = 2;
                HookshotMovement();
                break;
        }
    }

    /// <summary>
    /// //R1が押されたらHitした位置の情報を取得し、プレイヤーのステータスを「飛行中」にする
    /// </summary>
    void HookshotStart()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            state = State.HookshotFlyingPlayer;
        }
        else
        {
            m_line.positionCount = 0;
        }
    }
    /// <summary>
    /// //プレイヤーをhit.pointへ飛ばし、ステータスを「通常」に変更する
    /// </summary>
    void HookshotMovement()
    {
        //m_rb.useGravity = false;
        m_line.SetPosition(0, m_muzzle.position);
        m_line.SetPosition(1, hookshotPosition);
        state = State.Normal;
    }
}
