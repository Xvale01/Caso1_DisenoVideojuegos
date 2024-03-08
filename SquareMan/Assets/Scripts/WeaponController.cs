using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Segunda Arma 25 PUNTOS
//  * Animación por rotacion
public class WeaponController : MonoBehaviour
{
    //getaxis devuelve un vector
    //getbutton devuelve true/false
    [SerializeField]
    AttackController[] weapons;

    AttackController _currentWeapon;

    int _selectedWeapon;

    private void Start()
    {
       _selectedWeapon = 0;
        SelectWeapon();
    }

    private void Update()
    {
        HandleScrollWheel();
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            _currentWeapon.Attack();
        }
    }

    private void HandleScrollWheel()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0F)
        {
            //indica si esta incrementado o decresiendo
            _selectedWeapon = scrollWheel > 0.0F
                ? _selectedWeapon + 1
                : _selectedWeapon - 1;

            if (_selectedWeapon >= weapons.Length)
            {
                _selectedWeapon = 0;
            }
            else if (_selectedWeapon < 0)
            {
                _selectedWeapon = weapons.Length - 1;
            }

            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            bool isActive = (_selectedWeapon == index);
            AttackController controller = weapons[index];
            controller.gameObject.SetActive(isActive); 
        }

        _currentWeapon = weapons[_selectedWeapon];
    }
}
