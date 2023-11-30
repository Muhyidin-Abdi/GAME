using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moucelook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    bool invert;

    [SerializeField]
    bool can_unlock = true;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private int soomth_steps = 10;
    [SerializeField]
    private float smooth_weight = 0.4f;

    

    [SerializeField]
    private float roll_speed = 3f;

    [SerializeField]
    private Vector2 default_look_limits = new Vector2(-70, 80f);

    private Vector2 look_angles;

    private Vector2 current_mouse_look;

    private Vector2 smooth_move;

    private float current_roll_angles;
    private int last_look_Frame;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        LockAndUnlockCursor();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }


    }
    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }//lock&unluck

    void LookAround()
    {
        current_mouse_look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_angles.x += current_mouse_look.x * sensivity * (invert? 1f : -1f);
        look_angles.y += current_mouse_look.y * sensivity;

        look_angles.x = Mathf.Clamp(look_angles.x, default_look_limits.x, default_look_limits.y);

     // current_roll_angles =
        //   Mathf.Lerp(current_roll_angles, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_angle, Time.deltaTime * roll_speed);


        lookRoot.localRotation = Quaternion.Euler(look_angles.x, 0f, current_roll_angles);
        playerRoot.localRotation = Quaternion.Euler(0f, look_angles.y, 0f);
    }//lookaround
}