using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HookshotController : MonoBehaviour
{
    [SerializeField] Transform m_debugHitPointTransform;
    [SerializeField] Transform m_muzzle;
    [SerializeField] Camera m_playerCamera;
    [SerializeField] float m_maxWireDistance = 10f;
    [SerializeField] float m_hookshotSpeed = 5f;
    [SerializeField] AudioClip m_flyingSfx = null;
    private Rigidbody m_rb;
    private SpringJoint m_joint;
    private LineRenderer m_line;
    private Vector3 hookshotPosition;
    State state;
    enum State
    {
        Normal,
        HookshotFlyingPlayer
    }
    
    
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_joint = GetComponent<SpringJoint>();
        m_line = GetComponent<LineRenderer>();
        state = State.Normal;
        
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HookshotStart();
                m_line.enabled = false;
                break;
            case State.HookshotFlyingPlayer:

                m_line.enabled = true;
                HookshotMovement();
                break;
        }
    }

    /// <summary>
    /// //R1が押されたらHitした位置の情報を取得し、プレイヤーのステータスを「飛行中」にする
    /// </summary>
    void HookshotStart()
    {
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            if (Physics.Raycast(m_playerCamera.transform.position, m_playerCamera.transform.forward, out RaycastHit Hit))
            {
                m_debugHitPointTransform.position = Hit.point;
                hookshotPosition = Hit.point;
                state = State.HookshotFlyingPlayer;
            }
        }
    }
    /// <summary>
    /// //プレイヤーをhit.pointへ飛ばし、ステータスを「通常」に変更する
    /// </summary>
    void HookshotMovement()
    {
        m_line.SetPosition(0, m_muzzle.position);
        m_line.SetPosition(1, hookshotPosition);
        AudioSource.PlayClipAtPoint(m_flyingSfx, hookshotPosition);
        m_rb.transform.position = Vector3.Lerp(m_rb.transform.position, hookshotPosition, Time.deltaTime * m_hookshotSpeed);
        state = State.Normal;
    }
}
