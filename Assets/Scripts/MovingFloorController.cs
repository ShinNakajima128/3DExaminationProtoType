using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingFloorController : MonoBehaviour
{
    [SerializeField] float m_MoveTime = 2f;
    [SerializeField] Transform m_target = null;
    Vector3 m_originPosition;

    void Start()
    {
        m_originPosition = this.transform.position;
        MoveFloor();
    }

    void MoveFloor()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(this.transform.DOMove(m_target.position, m_MoveTime).SetEase(Ease.Linear))
           .AppendInterval(1)
           .Append(this.transform.DOMove(m_originPosition, m_MoveTime).SetEase(Ease.Linear))
           .AppendInterval(1)
           .SetLoops(-1);
    }
}
