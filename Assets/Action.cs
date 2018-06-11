using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject {

    public static GameObject selectedObject;

    public Sprite icon;
    public string desc;

    public abstract void DoAction(GameObject target);
}
