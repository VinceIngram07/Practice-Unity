using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get input for steering.
        float verticalInput = Input.GetAxis("Vertical"); // Get input for acceleration and braking.

        // Calculate the movement and rotation vectors.
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);

        // Apply forces to move and rotate the car.
        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation * rotation);
    }
}

