using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterWeapon : WeaponBase
{
    public StarterWeapon()
    {
        spread = 0.02f;
        damage = 45;
        weaponName = "MP40";
        useTime = 0.2f;
    }
}
