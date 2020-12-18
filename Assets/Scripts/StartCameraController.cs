using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraController : MonoBehaviour
{
    [SerializeField] Transform[] m_routePoints;
    [SerializeField] float m_moveSpeed = 1f;
    [SerializeField] float m_distanceToTargetToSwitchTarget = 0.01f;
    Vector3 m_currentDestination;
    int m_routePointIndex = 0;

    void Start()
    {
        m_currentDestination = m_routePoints[m_routePointIndex].position;
    }

    void Update()
    {
        MoveTowards(m_currentDestination);
        Debug.Log(m_routePointIndex);

        float distance = Vector3.Distance(this.transform.position, m_currentDestination);
        if (distance < m_distanceToTargetToSwitchTarget)
        {
            SwitchDistination();
        }
    }
    void MoveTowards(Vector3 target)
    {
        //this.transform.position = Vector3.Slerp(this.transform.position, target, Time.deltaTime * m_moveSpeed);
        Vector3 dir = (target - this.transform.position).normalized;
        this.transform.Translate(dir * m_moveSpeed * Time.deltaTime);
    }

    void SwitchDistination()
    {
        if (m_routePoints.Length - 1 > m_routePointIndex)
        {
            m_routePointIndex++;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        m_currentDestination = m_routePoints[m_routePointIndex].position;
    }
}
