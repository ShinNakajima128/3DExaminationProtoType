using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : ItemBase
{
    
    public override void Use()
    {
        Debug.Log("鍵を使用しました");
        base.Use();
    }
}
