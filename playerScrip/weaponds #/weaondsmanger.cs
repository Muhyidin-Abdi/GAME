using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaondsmanger : MonoBehaviour
{  
    
    [SerializeField]
    private handers[] weapons;

    private int current_Weapon_index;


    void Start()
    {
        current_Weapon_index = 0;
        weapons[current_Weapon_index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TurnOnSelectedWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TurnOnSelectedWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TurnOnSelectedWeapon(5);
        }
    }


    void TurnOnSelectedWeapon(int weaponIndex)
    {
        //turns of current weapon  
        weapons[current_Weapon_index].gameObject.SetActive(false);
        //turns on the selected weapon!!
        weapons[weaponIndex].gameObject.SetActive(true);
        //stores the current weapon index
        current_Weapon_index = weaponIndex;
    }


    public handers GetCurrentSelectedWeapon()
    {
        return weapons[current_Weapon_index];
    }
} 
