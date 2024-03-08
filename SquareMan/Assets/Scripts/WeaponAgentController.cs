using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAgentController : MonoBehaviour
{
    [SerializeField]
    AttackController _weapon;


    private void Start()
    {
        if (_weapon != null)
        {
            _weapon.gameObject.SetActive(true);
            Attack();
        }
    }

    private void Attack()
    {
        _weapon.Attack();
    }
}
