using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rigidbody を使ってプレイヤーを動かすコンポーネント
/// 入力を受け取り、それに従ってオブジェクトを動かす。
/// PlayerControllerRb との違いは以下の通り。
/// 1. Rigidbody.AddForce() ではなく Rigidbody.velocity で動かしている（※１）
/// 2. World 座標系ではなく、カメラの座標系に対して動かしている（※２）
/// 3. 方向転換時に Quartenion.Slerp() を使って滑らかに方向転換している
/// （※１）AddForce() 動かすことは問題ではなく、挙動や実装を比較するために変えている。
/// （※２）World 座標系で動かすと、カメラの回転に対応できないため
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerRbEx : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float m_movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] float m_turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] float m_jumpPower = 5f;
    /// <summary>接地判定の際、中心 (Pivot) からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] float m_isGroundedLength = 1.1f;
    [SerializeField] int m_maxJumpCount = 2;
    [SerializeField] AudioClip m_jumpSfx = null;
    Rigidbody m_rb;
    Animator m_anim;
    int m_jumpCount;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMove();

        if (IsGrounded())
        {
            playerAnimation();
        }
    }

    void LateUpdate()
    {
        if (m_anim)
        {
            if (IsGrounded())
            {
                Vector3 velo = m_rb.velocity;
                velo.y = 0;
                m_anim.SetFloat("Speed", velo.magnitude);
            }
        }
    }

    /// <summary>
    /// 地面に接触しているか判定する
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        Vector3 start = this.transform.position;   // start: オブジェクトの中心
        Vector3 end = start + Vector3.down * m_isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }

    void PlayerMove()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("LstickV");
        float h = Input.GetAxisRaw("LstickH");

        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);  // Slerp を使うのがポイント

            Vector3 velo = dir.normalized * m_movingSpeed; // 入力した方向に移動する
            velo.y = m_rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する
            m_rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }
    }
    void playerAnimation()
    {
        //Aボタンの入力を取得し、接地している時か、1回目のジャンプ中に押されていたらジャンプする
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                JumpMove();
                m_jumpCount = 1;
            }
            else if (m_jumpCount < m_maxJumpCount)
            {
                JumpMove();
                m_jumpCount++;
            }
        }
        //Xボタンが押されたら
        //if (Input.GetButtonDown("Attack1") && IsGrounded())
        //{
        //    m_anim.SetBool("Attack1", true);
        //}
        ////Yボタンが押されたら
        //if (Input.GetButtonDown("Attack2") && IsGrounded())
        //{
        //    m_anim.SetBool("Attack2", true);
        //}
        //R1ボタンが押されたら
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            m_anim.SetBool("Wire", true);
        }
    }
    void JumpMove()
    {
        AudioSource.PlayClipAtPoint(m_jumpSfx, this.transform.position);
        m_rb.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
        m_anim.SetBool("Jump", true);
    }
}
