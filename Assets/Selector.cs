using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour {

    public EventSystem eventSystem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && eventSystem.IsPointerOverGameObject() == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Action.selectedObject = hit.collider.gameObject;
            }
        }
    }
}
