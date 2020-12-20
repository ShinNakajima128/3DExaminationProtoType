using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HookshotController : MonoBehaviour
{
    [SerializeField] Transform debugHitPointTransform;
    [SerializeField] Camera playerCamera;
    [SerializeField] float m_maxWireDistance = 10f;
    [SerializeField] float m_hookshotSpeed = 5f;
    Rigidbody m_rb;
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
        state = State.Normal;
    }
    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HookshotStart();
                break;
            case State.HookshotFlyingPlayer:
                HookshotMovement();
                break;
        }
    }

    void HookshotStart()
    {
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit Hit))
            {
                debugHitPointTransform.position = Hit.point;
                hookshotPosition = Hit.point;
                state = State.HookshotFlyingPlayer;
            }
        }
    }
    void HookshotMovement()
    {
        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        //プレイヤーをhit.pointへ飛ばす
        m_rb.MovePosition(hookshotDir);
        //m_rb.MovePosition(hookshotDir * m_hookshotSpeed * Time.deltaTime);
    }
}
