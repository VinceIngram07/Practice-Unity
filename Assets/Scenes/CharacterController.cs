using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float limbSwingSpeed = 2f;

    public float turnSpeed = 70f;

    private Transform leftArm;
    private Transform rightArm;
    private Transform leftLeg;
    private Transform rightLeg;

    private Rigidbody rb;

    private float armSwing = 0f;
    private float legSwing = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Assign the arm and leg objects in the Inspector
        leftArm = transform.Find("LeftArm");
        rightArm = transform.Find("RightArm");
        leftLeg = transform.Find("LeftLeg");
        rightLeg = transform.Find("RightLeg");

        
    }

    private void Update()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);

        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation * rotation);
        // Move the character
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Update arm and leg swing
        armSwing = Mathf.Sin(Time.time * limbSwingSpeed);
        legSwing = Mathf.Sin(Time.time * limbSwingSpeed);

        // Apply arm and leg animation
        AnimateLimb(leftArm, armSwing);
        AnimateLimb(rightArm, -armSwing);
        AnimateLimb(leftLeg, -legSwing);
        AnimateLimb(rightLeg, legSwing);
    }

    // Animate a limb's rotation
    private void AnimateLimb(Transform limb, float rotationOffset)
    {
        if (limb != null)
        {
            Vector3 localRotation = limb.localRotation.eulerAngles;
            localRotation.x = rotationOffset * 30f; // Adjust the multiplier for desired rotation
            limb.localRotation = Quaternion.Euler(localRotation);
        }
    }
}