using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SizeAction", menuName = "UI_Demo/SizeAction", order =1)]
public class SizeAction : Action {

    public float scale;

    public override void DoAction(GameObject target)
    {
        target.transform.localScale = Vector3.one * scale;
    }
}
