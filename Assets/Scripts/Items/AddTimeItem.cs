using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTimeItem : ItemBase
{
    [SerializeField] GameManager GM = null;
    [SerializeField] Text m_addText = null;
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
