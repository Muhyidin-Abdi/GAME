using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum weaponAim
{
    NONE,
    SELF_AIM,
    AIM
}

public enum weapondsFireType
{
    SINGLE,
    MULTIPLE
}
public enum WeapondBulletTYPE
{
    BULLET,
    SPEAR,
    ARROW,
    NONE
}


public class handers : MonoBehaviour
{
    private Animator anim;

    public weaponAim weapon_Aim;

    [SerializeField]
    private GameObject muzzleflash;

    [SerializeField]
    private AudioSource shootSound, Reload_sound;

    public weapondsFireType FireType;

    public WeapondBulletTYPE BulletTYPE;

    public GameObject attack_point;



    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void shootAnimation ()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }
    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }
    
    void Trun_On_MuzzleFlash()
    {
        muzzleflash.SetActive(true);
    }


    void Trun_OFF_MuzzleFlash()
    {
        muzzleflash.SetActive(false);
    }



    void Play_Shoot_Sound()
    {

    }


    private void Reload_Sound_Play()
    {
        
    }
    void Trun_On_AttackPoint()
    {

    }
    void Trun_Off_AttackPoint()
    {
        if (attack_point.activeInHierarchy)
        {
            attack_point.SetActive(false);
        }
    }
}


