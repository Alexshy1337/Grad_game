using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase
{
    
    public int damage;
    public float useTime, spread;
    public string weaponName;
    public Transform FirePoint, GunBack;
    public GameObject impactEffect;
    public LineRenderer line;
    public bool stop = false;

    public virtual IEnumerator ShootCoroutine()
    {
        stop = false;
        while (true)
        {
            if (stop)
                break;
            Shoot();
            line.enabled = true;
            yield return new WaitForSeconds(0.03f);
            line.enabled = false;
            yield return new WaitForSeconds(useTime);
        }
        yield return 0;
    }

    public virtual void Shoot()
    {
        Vector3 dir = FirePoint.position;
        dir.y += Mathf.Lerp(-spread, spread, Random.value);
        Mathf.Lerp(FirePoint.position.y - spread, FirePoint.position.y + spread, Random.value);
        RaycastHit2D hitInfo = Physics2D.Raycast(dir, dir - GunBack.position);
        if (hitInfo)
        {
            EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();
            if (enemy != null)
                enemy.TakeDamage(damage);
            Object.Destroy(Object.Instantiate(impactEffect, hitInfo.point, Quaternion.identity), 1);
            line.SetPosition(0, FirePoint.transform.position);
            line.SetPosition(1, hitInfo.point);
        }

    }

    public void StopAllCoroutines()
    {
        stop = true;
    }
}
