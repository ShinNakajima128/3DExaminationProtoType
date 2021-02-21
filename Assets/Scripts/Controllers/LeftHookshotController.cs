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
    [SerializeField] float m_wireMoveSpeed = 0.5f;
    [SerializeField] AudioClip m_hookHitSfx = null;
    [SerializeField] float m_maxDistance = 40f;
    [SerializeField] GameObject m_reticle;
    SpringJoint joint;
    Image reticleImage;
    LineRenderer lr;
    Vector3 hookPoint;
    HookshotController hookshotController;
    RaycastHit reticleHit;
    Rigidbody m_rb;

    bool winderState = false;
    bool audioOneshot = true;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        hookshotController = GetComponent<HookshotController>();
        reticleImage = m_reticle.GetComponent<Image>();
        m_rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ReticleHitAnim();

        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            hookshotController.enabled = false;
            StartHookshot();
            //m_rb.useGravity = true;
        }
        else if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            hookshotController.enabled = true;
            StopHookshot();
            //m_rb.useGravity = true;
            audioOneshot = true;
            
        }

        if (Input.GetKey(KeyCode.JoystickButton4) && Input.GetKey(KeyCode.Joystick1Button5) && winderState)
        {
            if (audioOneshot)
            {
                //AudioSource.PlayClipAtPoint(m_flyingSfx, Camera.main.transform.position);
            }
            m_rb.velocity = new Vector3(0f, 0f, 0f);
            m_rb.transform.position = Vector3.MoveTowards(transform.position, hookPoint, m_wireMoveSpeed);
            //m_rb.useGravity = false;
            audioOneshot = false;
        }
        
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartHookshot()
    {
        RaycastHit hit;

        if (Physics.Raycast(m_camera.position, m_camera.forward, out hit, m_maxDistance, whatIsHookshot))
        {
            AudioSource.PlayClipAtPoint(m_hookHitSfx, m_player.position);
            hookPoint = hit.point;
            joint = m_player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = hookPoint;

            float distanceFromPoint = Vector3.Distance(m_player.position, hookPoint);

            joint.minDistance = 0.2f;
            joint.maxDistance = distanceFromPoint * 0.8f;

            joint.spring = 1.0f;
            joint.damper = 1.0f;
            joint.massScale = 6.0f;

            lr.positionCount = 2;
            winderState = true;
        } 
    }
    void StopHookshot()
    {
        winderState = false;
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
        else if (Physics.Raycast(m_camera.position, m_camera.forward, out reticleHit, 300f))
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
