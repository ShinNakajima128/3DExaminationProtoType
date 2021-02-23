using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHookshotController : MonoBehaviour
{
    /// <summary> RayCastが衝突するオブジェクトを制限するMask </summary>
    [SerializeField] LayerMask whatIsHookshot;
    /// <summary> ワイヤーを飛ばす位置 </summary>
    [SerializeField] Transform m_muzzle;
    /// <summary> カメラ </summary>
    [SerializeField] Transform m_camera;
    /// <summary> プレイヤー </summary>
    [SerializeField] Transform m_player;
    /// <summary> ワイヤーで移動してる時の速度 </summary>
    [SerializeField] float m_wireMoveSpeed = 0.5f;
    /// <summary> プレイヤーのオーディオ </summary>
    [SerializeField] AudioSource audioSource;
    /// <summary> ショットがターゲットに当たった時のSE </summary>
    [SerializeField] AudioClip m_hookHitSfx = null;
    /// <summary> ワイヤーが届く距離 </summary>
    [SerializeField] float m_maxDistance = 40f;
    /// <summary> 画面中央のレティクル </summary>
    [SerializeField] GameObject m_reticle;
    /// <summary> ターゲットとプレイヤーを繋ぐジョイント </summary>
    SpringJoint joint;
    /// <summary> レティクルのImage </summary>
    Image reticleImage;
    /// <summary> ワイヤーのRenderer </summary>
    LineRenderer lr;
    /// <summary> Rayが当たった時のターゲットの場所 </summary>
    Vector3 hookPoint;
    /// <summary> ワイヤーを飛ばしているクラス </summary>
    HookshotController hookshotController;
    /// <summary> レティクルのRayの当たり判定 </summary>
    RaycastHit reticleHit;
    /// <summary> プレイヤーのRigidbody </summary>
    Rigidbody m_rb;
    /// <summary> ワインダーが可能か否か </summary>
    bool winderState = false;

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

        ///LBを押したらターゲットへワイヤーを飛ばす
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            hookshotController.enabled = false;
            StartHookshot();
        }
        ///LBを離したらターゲットからワイヤーを外す
        else if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            hookshotController.enabled = true;
            StopHookshot();
            audioSource.Stop();   
        }
        ///ターゲットにワイヤーを飛ばした状態でLBとRBを押すとターゲットの位置へ移動する
        if (Input.GetKey(KeyCode.JoystickButton4) && Input.GetKey(KeyCode.Joystick1Button5) && winderState)
        {
            audioSource.Play();
            m_rb.velocity = new Vector3(0f, 0f, 0f);
            m_rb.transform.position = Vector3.MoveTowards(transform.position, hookPoint, m_wireMoveSpeed);
        }
        
    }

    /// <summary>
    /// ワイヤーを表示する
    /// </summary>
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Rayが
    /// </summary>
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
            joint.maxDistance = distanceFromPoint;

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
            else
            {
                reticleImage.color = new Color(0, 1.0f, 1.0f, 1.0f);
                m_reticle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
