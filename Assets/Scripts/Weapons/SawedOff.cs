using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawedOff : WeaponBase
{
    private int bulletAmount = 8;
    //public LineRenderer[] lines;

    public SawedOff()
    {
        spread = 0.03f;
        damage = 12;
        weaponName = "Sawed Off shotgun";
        useTime = 0.5f;
    }

    public override IEnumerator ShootCoroutine()
    {
        Shoot();
        yield return new WaitForSeconds(useTime);
    }

    public override void Shoot()
    {
        for(int i = 0; i< bulletAmount; i++)
        {
            //Vector3 dir = FirePoint.position;
            Quaternion dir = FirePoint.rotation; // new Quaternion (0, FirePoint.rotation.y, FirePoint.rotation.z, FirePoint.rotation.w);
            dir.w += Mathf.Lerp(-spread, spread, Random.value);
            dir.z += Mathf.Lerp(-spread, spread, Random.value);
            //Mathf.Lerp(FirePoint.position.y - spread, FirePoint.position.y + spread, Random.value);
            GameObject bullet = UnityEngine.Object.Instantiate(bulletPrefab, FirePoint.position, dir);  //FirePoint.rotation*dir);
        }
    }

    /*
    public override IEnumerator ShootCoroutine()
    {
        stop = false;
        while (true)
        {
            if (stop)
                break;
            Shoot();

            foreach(LineRenderer l in lines)
                l.enabled = true;

            yield return new WaitForSeconds(0.03f);

            foreach (LineRenderer l in lines)
                l.enabled = false;

            yield return new WaitForSeconds(useTime);
        }
        yield return 0;
    }
    

    public override void Shoot()
    {
        for (int i = 0; i < bulletAmount; i++)
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
                lines[i].SetPosition(0, FirePoint.transform.position);
                lines[i].SetPosition(1, hitInfo.point);
            }
        }
    }*/
}
