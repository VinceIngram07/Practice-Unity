using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNoise : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;
    public AudioClip engineSound; // Assign the engine sound in the Inspector.

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // Configure the AudioSource.
        audioSource.clip = engineSound;
        audioSource.loop = true; // Loop the audio clip.
        audioSource.playOnAwake = false; // Don't play on start; start when the car moves.
    }

    private void Update()
    {
        // Check if the car is moving (you can adjust the threshold).
        if (rb.velocity.magnitude > 0.1f)
        {
            // Play the engine sound when the car moves.
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop the engine sound when the car stops.
            audioSource.Stop();
        }
    }
}