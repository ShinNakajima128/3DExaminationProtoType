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
    
    
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();  
    }
    void Update()
    {
       
        HookshotStart();
        HookshotMovement();
    }

    void HookshotStart()
    {
        if (Input.GetKey(KeyCode.JoystickButton5))
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit Hit))
            {
                debugHitPointTransform.position = Hit.point;
                hookshotPosition = Hit.point;
            }
            else
            {
                debugHitPointTransform.position = playerCamera.transform.forward * m_maxWireDistance;
            }
        }
    }
    void HookshotMovement()
    {
        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        //プレイヤーをhit.pointへ飛ばす
        m_rb.MovePosition(hookshotDir * m_hookshotSpeed * Time.deltaTime);
    }
}
