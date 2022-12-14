using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform FirePoint;
    public Transform GunBack;
    public GameObject impactEffect, FireBlast, linesObj;
    public LineRenderer line;
    private SpriteRenderer GunRenderer;//acutally player renderer
    private WeaponBase[] weapon;
    private int currentWeapon = 0;
    private bool isShooting = false, isChangingWeapons = false;
    private Sprite[] GunSprites;

    //fill the gun object with necessary pointers to objects
    private void FillGun(WeaponBase gun)
    {
        gun.FirePoint = FirePoint.transform;
        gun.GunBack = GunBack.transform;
        gun.impactEffect = impactEffect;
        gun.line = line;
    }

    private void Start()
    {
        //weapon array init
        weapon = new WeaponBase[4];
        weapon[0] = new StarterWeapon();
        weapon[1] = new MG42();
        weapon[2] = new SawedOff() {
            spread = 0.1f,
            damage = 35,
            weaponName = "Sawed Off shotgun",
            useTime = 0.5f,
            lines = linesObj.GetComponentsInChildren<LineRenderer>(true) 
        };
        weapon[3] = new Magnum();

        foreach (WeaponBase w in weapon)
            FillGun(w);
        
        GunRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
        
        //Gunsprites array init
        GunSprites = new Sprite[4];
        GunSprites[0] = Resources.Load<Sprite>("mp40");
        GunSprites[1] = Resources.Load<Sprite>("mg42");
        GunSprites[2] = Resources.Load<Sprite>("shotgun");
        GunSprites[3] = Resources.Load<Sprite>("magnum");
    }

    void Update()
    {
        if (!isChangingWeapons)
        {
            if (!isShooting && Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(weapon[currentWeapon].ShootCoroutine());
                isShooting = true;
                FireBlast.SetActive(true);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                weapon[currentWeapon].StopAllCoroutines();
                isShooting = false;
                FireBlast.SetActive(false);
            }
        }
    }

    //buy and change the gun randomly
    public void GetNewGun()
    {
        isChangingWeapons = true;

        weapon[currentWeapon].StopAllCoroutines();
        isShooting = false;
        FireBlast.SetActive(false);
        currentWeapon = Random.Range(1, 4);//for some reason in random(int min, int max) max is excluded
        GunRenderer.sprite = GunSprites[currentWeapon];

        //checking for weapon that needs to shoot bullets from a different point
        //switch (currentWeapon)
        //{
        //    case 1:
        //        ChangeChildTransforms(new Vector3(0.4f, -0.06f, 0), new Vector3(0.36f, -0.06f, 0), new Vector3(0.47f, -0.06f, 0));
        //        break;
        //    default:
        //        ChangeChildTransforms(new Vector3(0.3f, 0, 0), new Vector3(0.28f, 0, 0), new Vector3(0.36f, 0, 0));
        //        break;
        //}

        isChangingWeapons = false;
    }

    //doesn't work properly unfortunately
    void ChangeChildTransforms(Vector3 firePoint, Vector3 gunBack, Vector3 fireblast)
    {
        FirePoint.transform.Translate(firePoint - FirePoint.transform.localPosition);
        //Debug.Log(FirePoint.transform.localPosition.ToString());


        GunBack.transform.Translate(gunBack - GunBack.transform.localPosition);
        //Debug.Log(GunBack.transform.localPosition.ToString()); 

        FireBlast.transform.Translate(fireblast - FireBlast.transform.localPosition);
        //Debug.Log(FireBlast.transform.localPosition.ToString());
    }
}
