using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG42 : WeaponBase
{
    public MG42()
    {
        spread = 0.01f;
        damage = 60;
        weaponName = "MG42";
        useTime = 0.08f;
    }
}
