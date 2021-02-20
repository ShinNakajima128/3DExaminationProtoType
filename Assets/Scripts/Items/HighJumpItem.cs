using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpItem : ItemBase
{
    [SerializeField] Rigidbody m_player = null;
    [SerializeField] float m_jumpPower = 30f;

    public override void Use()
    {
        Debug.Log("高くジャンプしました");
        m_player.velocity = new Vector3(0f, 0f, 0f);
        m_player.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
        base.Use();
    }
}
