using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the object the camera will follow.
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the target's position.

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired camera position based on the target's position and the offset.
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate the current camera position towards the desired position.
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Make the camera look at the target.
            transform.LookAt(target);
        }
    }
}
