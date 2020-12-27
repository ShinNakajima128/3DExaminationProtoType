using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHookshotController : MonoBehaviour
{
    [SerializeField] LayerMask whatIsHookshot;
    [SerializeField] Transform m_muzzle;
    [SerializeField] Transform m_camera;
    LineRenderer lr;
    SpringJoint joint;
    Vector3 hookPoint;
    float maxDistance = 100f;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            StartHookshot();
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button4))
        {
            StopHookshot();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartHookshot()
    {
        RaycastHit hit;

        if (Physics.Raycast( m_camera.position, m_camera.forward, out hit, maxDistance, whatIsHookshot))
        {
            hookPoint = hit.point;
            joint = this.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = hookPoint;

            float distanceFromPoint = Vector3.Distance(this.transform.position, hookPoint);

            joint.minDistance = distanceFromPoint * 0.8f;
            joint.maxDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }
    void StopHookshot()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint) return;
        lr.SetPosition(0, m_muzzle.position);
        lr.SetPosition(1, hookPoint);
    }
}
