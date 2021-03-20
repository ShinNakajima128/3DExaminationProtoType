using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTimeItem : ItemBase
{
    /// <summary> ゲームマネージャー </summary>
    [SerializeField] GameManager GM = null;
    /// <summary> 加算した制限時間のText </summary>
    [SerializeField] Text m_addText = null;
    /// <summary> 加算する時間 </summary>
    [SerializeField] int m_addTime = 30;

    public override void Use()
    {
        Debug.Log("制限時間が増加しました");
        GM.m_currentTime += m_addTime;
        m_addText.enabled = true;
        m_addText.text = $"+{m_addTime}";
        base.Use();
    }
}
