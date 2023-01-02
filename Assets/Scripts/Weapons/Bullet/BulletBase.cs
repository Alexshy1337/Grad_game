using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speed = 100f;
    public int damage = 10;
    public Rigidbody2D rb;
    //public GameObject impactEffect;
    private ContactPoint2D[] contacts = new ContactPoint2D[10];

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(!hitInfo.gameObject.CompareTag("Bullet")&& !hitInfo.gameObject.CompareTag("Shop"))
        {
            EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();

            if (enemy != null)
                enemy.TakeDamage(damage);
            //Debug.Log("points amount: " + gameObject.GetComponent<BoxCollider2D>().GetContacts(contacts));

            //Object.Destroy(Instantiate(impactEffect, contacts[0].point, new Quaternion(0,0,0,0)), 1);
            //Debug.Log("point: " + contacts[0].point.x + " " + contacts[0].point.y);
            Destroy(gameObject);
        }
    }

}
