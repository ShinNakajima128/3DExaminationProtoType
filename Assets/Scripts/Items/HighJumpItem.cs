using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpItem : ItemBase
{
    public override void Use()
    {
        Debug.Log("高くジャンプしました");
        base.Use();
    }
}
