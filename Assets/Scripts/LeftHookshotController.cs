using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHookshotController : MonoBehaviour
{
    [SerializeField] LayerMask whatIsHookshot;
    [SerializeField] Transform m_muzzle;
    [SerializeField] Transform m_camera;
    [SerializeField] Transform m_player;
    [SerializeField] AudioClip m_flyingSfx = null;
    [SerializeField] AudioClip m_hookHitSfx = null;
    [SerializeField] float m_maxDistance = 40f;
    [SerializeField] GameObject m_reticle;
    Image reticleImage;
    LineRenderer lr;
    SpringJoint joint;
    Vector3 hookPoint;
    HookshotController hookshotController;
    RaycastHit reticleHit;


    void Start()
    {
        lr = GetComponent<LineRenderer>();
        hookshotController = GetComponent<HookshotController>();
        reticleImage = m_reticle.GetComponent<Image>();
    }
    void Update()
    {
        ReticleHitAnim();
       
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            hookshotController.enabled = false;
            StartHookshot();   
        }
        else if (Input.GetKeyUp(KeyCode.Joystick1Button4))
        {
            hookshotController.enabled = true;
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

        if (Physics.Raycast( m_camera.position, m_camera.forward, out hit, m_maxDistance, whatIsHookshot))
        {
            AudioSource.PlayClipAtPoint(m_hookHitSfx, m_player.position);
            hookPoint = hit.point;
            joint = m_player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = hookPoint;

            AudioSource.PlayClipAtPoint(m_flyingSfx, m_player.position);

            float distanceFromPoint = Vector3.Distance(m_player.position, hookPoint);

            joint.minDistance = distanceFromPoint * 0.8f;
            joint.maxDistance = distanceFromPoint * 0.3f;

            joint.spring = 10.0f;
            joint.damper = 1.0f;
            joint.massScale = 6.0f;

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

    void ReticleHitAnim()
    {
        if (Physics.Raycast(m_camera.position, m_camera.forward, out reticleHit, m_maxDistance))
        {
            string hittag = reticleHit.collider.tag;

            if (hittag.Equals("HookTarget"))
            {
                reticleImage.color = new Color(1.0f, 0, 0, 1.0f);
                m_reticle.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        else if (Physics.Raycast(m_camera.position, m_camera.forward, out reticleHit, 200f))
        {
            string hittag = reticleHit.collider.tag;

            if (hittag.Equals("Stage"))
            {
                reticleImage.color = new Color(0, 1.0f, 1.0f, 1.0f);
                m_reticle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }


    }
}
