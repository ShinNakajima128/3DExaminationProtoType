using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingFloorController : MonoBehaviour
{
    /// <summary> 移動にかける時間 </summary>
    [SerializeField] float m_MoveTime = 2f;
    /// <summary> 移動先 </summary>
    [SerializeField] Transform m_target = null;
    /// <summary> 自身の場所 </summary>
    Vector3 m_originPosition;

    void Start()
    {
        m_originPosition = this.transform.position;
        MoveFloor();
    }

    /// <summary>
    /// 床を動かす
    /// </summary>
    void MoveFloor()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(this.transform.DOMove(m_target.position, m_MoveTime).SetEase(Ease.Linear))
           .AppendInterval(1)
           .Append(this.transform.DOMove(m_originPosition, m_MoveTime).SetEase(Ease.Linear))
           .AppendInterval(1)
           .SetLoops(-1);
    }

    /// <summary>
    /// プレイヤーが乗ったら自身の子オブジェクトにして一緒に移動する
    /// </summary>
    /// <param name="collision"> 触れたオブジェクト </param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    /// <summary>
    /// プレイヤーが降りたらプレイヤーを自身の子オブジェクトから外す
    /// </summary>
    /// <param name="collision">触れたオブジェクト </param>
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
