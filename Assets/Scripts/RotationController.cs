using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] float m_rotateX = 0.5f;
    [SerializeField] float m_rotateY = 0.5f;
    [SerializeField] float m_rotateZ = 0.5f;

    void Update()
    {
        transform.Rotate(new Vector3(m_rotateX, m_rotateY, m_rotateZ));
    }
}
