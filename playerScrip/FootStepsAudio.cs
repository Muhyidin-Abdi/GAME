using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsAudio : MonoBehaviour
{
    private AudioSource footsteps_sound;

    [SerializeField]
    private AudioClip[] footsteps_clip;

    private CharacterController Character_Controller;

    [HideInInspector]
    public float Volume_min, Volume_max;

    private float accumlated_Distance;//how far can we go till we need to play the aduio

    [HideInInspector]
    public float Step_Distance;
    //how far we can go in each step state ig-sprinting,crouching or walkin 


    void Awake()
    {
        footsteps_sound = GetComponent<AudioSource>();
        Character_Controller = GetComponentInParent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootStepSound();
    }

    void CheckToPlayFootStepSound()
    {
        if (!Character_Controller.isGrounded)
            return;


        if (Character_Controller.velocity.sqrMagnitude > 0)
        {   //is how far we can go until we can play the foot step sound
            accumlated_Distance += Time.deltaTime;
            if (accumlated_Distance > Step_Distance)
            {
                footsteps_sound.volume = Random.Range(Volume_min, Volume_max);
                footsteps_sound.clip = footsteps_clip[Random.Range(0, footsteps_clip.Length)];
                footsteps_sound.Play();

                accumlated_Distance = 0f;
            }
        }
        else
        {
            accumlated_Distance = 0f;//resets if not moving 
        }
    }
}
