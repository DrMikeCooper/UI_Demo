using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPalette : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 startDrag;
    Vector2 startPosition;

    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startDrag = eventData.position;
        startPosition = transform.position;
        rectTransform.anchorMax = rectTransform.anchorMin = Vector2.one * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = startPosition + eventData.position - startDrag;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // anchor to the nearest edge
        rectTransform.anchorMax 
            = rectTransform.anchorMin 
            = new Vector2(rectTransform.anchoredPosition.x < 0 ? 0 : 1, rectTransform.anchoredPosition.y < 0 ? 0 : 1);

        transform.position = startPosition + eventData.position - startDrag;
    }
}
