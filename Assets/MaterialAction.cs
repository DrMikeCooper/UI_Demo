using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialAction", menuName = "UI_Demo/MaterialAction", order =1)]
public class MaterialAction : Action {

    public Material material;

    public override void DoAction(GameObject target)
    {
        Renderer renderer = target.GetComponent<Renderer>();
        if (renderer)
            renderer.material = material;
    }
}
