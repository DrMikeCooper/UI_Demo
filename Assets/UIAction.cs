using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAction : MonoBehaviour, IToolTip {

    public Action action;
    public Image icon;
    public Text nameTag;
    public Text descTag;
    public Button button;

    void Start()
    {
        // hook up button
        button.onClick.AddListener(OnClicked);
    }

    public void OnClicked()
    {
        action.DoAction(Action.selectedObject);
    }

    public void SetAction(Action a)
    {
        action = a;
        if (icon)
            icon.sprite = action.icon;
        if (nameTag)
            nameTag.text = action.name;
        if (descTag)
            descTag.text = action.desc;
    }

    string IToolTip.getToolTipMessage()
    {
        return "<b>"+action.name + "</b>\n"+action.desc;
    }
}
