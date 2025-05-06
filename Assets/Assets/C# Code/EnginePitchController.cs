using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePitchController : MonoBehaviour
{
    public AudioSource engineSound;
    public Rigidbody2D playerRigidbody;
    public float minPitch = 0.8f;
    public float maxPitch = 1.5f;
    public float maxSpeed = 5f;

    void Update()
    {  
        float speed = Mathf.Abs(playerRigidbody.velocity.x);
        float targetPitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed);
        engineSound.pitch = targetPitch;
    }
}