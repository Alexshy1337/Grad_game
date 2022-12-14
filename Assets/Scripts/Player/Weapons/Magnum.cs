using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Magnum : WeaponBase
{
    public Magnum()
    {
        spread = 0;
        damage = 150;
        weaponName = "Magnum .365";
        useTime = 0;
    }

    public override IEnumerator ShootCoroutine()
    {
        Shoot();
        line.enabled = true;
        yield return new WaitForSeconds(0.03f);
        line.enabled = false;
        yield return 0;
    }
}
