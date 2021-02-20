using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeItem : ItemBase
{
    [SerializeField] GameManager GM = null;

    public override void Use()
    {
        Debug.Log("制限時間が増加しました");
        base.Use();
    }
}
