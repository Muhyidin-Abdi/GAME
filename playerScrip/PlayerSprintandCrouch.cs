using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintandCrouch : MonoBehaviour
{
    private PlayerMoverment PlayerMoverment;



    public float sprint_speed=10f;
    public float move_speed=5f;
    public float crouch_speed=2f;

    private Transform look_Root;
    private float stand_Height=1.6f;
    private float crouch_Height=1f;

    bool is_Crouching;

    private FootStepsAudio pleyer_FootStep;
    private float Sprint_volume = 1f;
    private float crouch_volume = 0.1f;
    private float walk_volume_min = 0.2f, walk_volume_max=0.6f;

    private float walk_step_Distance = 0.4f;
    private float sprint_step_Distance = 0.25f;
    private float Crouch_step_Distance = 0.5f;
    void Awake()
    {
        PlayerMoverment=GetComponent<PlayerMoverment>();

        look_Root=transform.GetChild(0);

        pleyer_FootStep = GetComponentInChildren<FootStepsAudio>();
    }

    private void Start()
    {
        pleyer_FootStep.Volume_min = walk_volume_min;
        pleyer_FootStep.Volume_max = walk_volume_max;
        pleyer_FootStep.Step_Distance = walk_step_Distance;
        
    }
    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
                                                //is NOT Crouching > !
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching )   
        {
            PlayerMoverment.speed=sprint_speed;

            pleyer_FootStep.Step_Distance = sprint_step_Distance;
            pleyer_FootStep.Volume_min = Sprint_volume;//able to hear hard sounds!
            pleyer_FootStep.Volume_max = Sprint_volume;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)   &&!is_Crouching )
        {
         PlayerMoverment.speed=move_speed;

            pleyer_FootStep.Step_Distance = walk_step_Distance;
            pleyer_FootStep.Volume_min = walk_volume_min;
            pleyer_FootStep.Volume_max = walk_volume_max;
            

        }//sprint
    }

    void Crouch()
    {

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {

            if(is_Crouching)
            {
                 look_Root.localPosition= new Vector3(0f,stand_Height,0f);
                 PlayerMoverment.speed=move_speed;

                pleyer_FootStep.Step_Distance = walk_step_Distance;
                pleyer_FootStep.Volume_min = walk_volume_min;
                pleyer_FootStep.Volume_max = walk_volume_max;
                is_Crouching =false;
            }
            else
            {
                look_Root.localPosition= new Vector3(0f,crouch_Height ,0f);
                 PlayerMoverment.speed=crouch_speed;

                pleyer_FootStep.Step_Distance = Crouch_step_Distance;
                pleyer_FootStep.Volume_min = crouch_volume;
                pleyer_FootStep.Volume_max = crouch_volume;


                is_Crouching = true;
            }
        }
    }
}
