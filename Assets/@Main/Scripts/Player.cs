using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGoal = false;

    public AudioClip jumpClip;

    // Start is called before the first frame update
    void Start()
    {
        var motor = GetComponent<PlatformerMotor2D>();
        motor.onJump += OnJump;
    }

    void OnJump()
    {
        var audiosource = FindObjectOfType<AudioSource>();
        audiosource.PlayOneShot(jumpClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
