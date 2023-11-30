using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerATACK : MonoBehaviour
{
    private weaondsmanger weaonds_manger;
    public float fireRate = 15f;
    private float NectTimeToFire;
    public float damage=20f;


    private Animator ZoomCameraAnim;
    private bool zoomed;
    private Camera MainCam;
    private GameObject crosshair;

    private bool is_Aiming;
    [SerializeField]
    private GameObject arrow_prefab, spear_prefab;

    [SerializeField]
    private Transform arrow_spear_StartPosistion;

     void Awake()
    {
        weaonds_manger = GetComponent<weaondsmanger>();

        ZoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        crosshair = GameObject.FindGameObjectWithTag(Tags.CROSSHAIR);
        MainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        weaponShoot();
        ZoomInAndOut();
    }
    void weaponShoot()
    {          //if we selected the AR
        if (weaonds_manger.GetCurrentSelectedWeapon().FireType == weapondsFireType.MULTIPLE)
        {           //if pressed and holded the left mouse click
            if (Input.GetMouseButton(0) && Time.time > NectTimeToFire)//helps with fire fate since update is called 60 times.
            {

                NectTimeToFire = Time.time + 1f / fireRate;

                weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();
            }
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {           //handle axe
                if (weaonds_manger.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();
                }
                //handle shoot
                if (weaonds_manger.GetCurrentSelectedWeapon().BulletTYPE == WeapondBulletTYPE.BULLET)
                {
                    weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();

                 // bulletFired();

                }
                else
                {
                    if (is_Aiming)//arrow or spear 
                    {
                        weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();

                        if (weaonds_manger.GetCurrentSelectedWeapon().BulletTYPE == WeapondBulletTYPE.ARROW) 
                        {
                            ThrowArrowOrSpear(true);
                        }
                        else if (weaonds_manger.GetCurrentSelectedWeapon().BulletTYPE == WeapondBulletTYPE.SPEAR)
                        {
                            ThrowArrowOrSpear(false);
                        }
                    }
                }

            }
        }
    }
    void ZoomInAndOut()
    {
        if (weaonds_manger.GetCurrentSelectedWeapon().weapon_Aim == weaponAim.AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ZoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crosshair.SetActive(false);
            }
        }
        if (weaonds_manger.GetCurrentSelectedWeapon().weapon_Aim == weaponAim.AIM)
        {
            if (Input.GetMouseButtonUp(1))
            {
                ZoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crosshair.SetActive(true);
            }
        } //if we need tozoom self aim

        if (weaonds_manger.GetCurrentSelectedWeapon().weapon_Aim == weaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weaonds_manger.GetCurrentSelectedWeapon().Aim(true);
                is_Aiming = true;
            }
        }
        if (weaonds_manger.GetCurrentSelectedWeapon().weapon_Aim == weaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonUp(1))
            {
                weaonds_manger.GetCurrentSelectedWeapon().Aim(false);
                is_Aiming = false;
            }
        }
    }
    void ThrowArrowOrSpear(bool throwArrow)
    {
         if (throwArrow)
        {
            GameObject arrow = Instantiate(arrow_prefab);
            arrow.transform.position = arrow_spear_StartPosistion.position;
            arrow.GetComponent<arrowSpear>().Launch(MainCam);
        }
        else
        {
            GameObject spear = Instantiate(spear_prefab);
            spear.transform.position = arrow_spear_StartPosistion.position;
            spear.GetComponent<arrowSpear>().Launch(MainCam);
        }
    }
    //throearrow 
}
