﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ToolTipUser : MonoBehaviour
{
    string message = "<b>Message</b>\nSub-message for all you freakers out there!";
    IToolTip helper;

    // Use this for initialization
    void Start()
    {
        helper = GetComponent<IToolTip>();
        if (helper == null)
            helper = GetComponentInChildren<IToolTip>();

        // make sure we have an EventTrigger
        EventTrigger trigger = GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        // add callbacks to mouse enter and mouse exit
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((data) => { OnPointerEnter(); });
        trigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((data) => { OnPointerExit(); });
        trigger.triggers.Add(pointerExit);
    }

    public void OnPointerEnter()
    {
        if (helper != null)
            message = helper.getToolTipMessage();

        Tooltip.instance.Show(transform.position, message, helper);
    }

    public void OnPointerExit()
    {
        Tooltip.instance.Hide();
    }

    public void SetMessage(string s)
    {
        message = s;
    }
}

