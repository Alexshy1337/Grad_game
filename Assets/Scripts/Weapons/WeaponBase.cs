using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase
{

    public int damage;
    public float useTime;
    public float spread;
    public string weaponName;
    public Transform FirePoint;
    public Transform GunBack;
    public GameObject impactEffect;
    public GameObject bulletPrefab;
    //public LineRenderer line;
    public bool stop = false;

    public virtual IEnumerator ShootCoroutine()
    {
        stop = false;
        while (true)
        {
            if (stop)
                break;
            Shoot();
            yield return new WaitForSeconds(useTime);
        }
        yield return 0;
    }

    public virtual void Shoot()
    {
        Vector3 dir = FirePoint.position;
        dir.y += Mathf.Lerp(-spread, spread, Random.value);
        Mathf.Lerp(FirePoint.position.y - spread, FirePoint.position.y + spread, Random.value);
        GameObject bullet = UnityEngine.Object.Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        //Object.Destroy(Object.Instantiate(impactEffect, hitInfo.point, Quaternion.identity), 1);
    }

    public void StopAllCoroutines()
    {
        stop = true;
    }
}
