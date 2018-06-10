using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraRotate : MonoBehaviour
{
    public Transform target;
    public float speed = 10;
    public float distance = 5;
    public float distanceMin = 2;
    public float distanceMax = 20;
    public float heightOffset = 1.5f;
    public float zoomSpeed = 100;

    float actualDistance = 1000;

    float lastMouseX;
    float lastMouseY;

    Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);
        if (Input.GetMouseButton(1))
        {
            float deltaX = Input.mousePosition.x - lastMouseX;
            float deltaY = Input.mousePosition.y - lastMouseY;

            Vector3 angles = transform.eulerAngles + (Vector3.right * deltaY + Vector3.up * deltaX) * Time.deltaTime * speed;
            if (angles.x > 180)
                angles.x -= 360;
            angles.x = Mathf.Clamp(angles.x, -70, 70);
            transform.eulerAngles = angles;
        }

        targetPosition = Vector3.MoveTowards(targetPosition, target.position, 20.0f * Time.deltaTime);
        Vector3 lookAtPosition = targetPosition + Vector3.up * heightOffset;

        // find the distance we want to be at, either full distance or on the surface behind us
        float dist = distance;
        RaycastHit hit;
        if (Physics.Raycast(lookAtPosition, -transform.forward, out hit, distance))
        {
            if (hit.collider.gameObject != target.gameObject)
                dist = hit.distance;
        }

        // if we need to pull in, snap immediately
        if (actualDistance > dist)
            actualDistance = dist;
        else
            actualDistance = Mathf.MoveTowards(actualDistance, dist, 5 * Time.deltaTime); // relax back to fuill distance

        transform.position = lookAtPosition - transform.forward * actualDistance;

        lastMouseX = Input.mousePosition.x;
        lastMouseY = Input.mousePosition.y;
    }
}
