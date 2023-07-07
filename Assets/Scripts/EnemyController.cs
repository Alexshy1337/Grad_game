using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100, damage = 13, reward = 10;
    public GameObject deathEffect;
    public GameObject[] blood;
    public Transform start, direction;
    public HealthBar playerHP;
    public ScoreMoneyController score;

    void Start()
    {
        direction = GameObject.FindGameObjectWithTag("Player").transform;
        score = GameObject.FindGameObjectWithTag("ScoreLabel").GetComponent<ScoreMoneyController>();
        playerHP = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        StartCoroutine(damageCoroutine());
    }

    void Update()
    {
        //if(condition) { StopCoroutine(damageCoroutine()); }
    }

    IEnumerator damageCoroutine()
    {
        while (true)
        {
            DealDamage();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (Random.value > 0.35f)
            Instantiate(blood[Random.Range(0, 7)], gameObject.transform.position, gameObject.transform.rotation);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        score.AddScore(reward);
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 2);
        Destroy(gameObject);
    }

    void DealDamage()
    {
        if (direction != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(start.position, direction.position, 0.35f);
            if (hit)
            {
                PCPlayerController player = hit.transform.GetComponent<PCPlayerController>();
                if (player != null)
                {
                    playerHP.TakeDamage(damage);
                }
            }
        }
        else
            StopAllCoroutines();
    }
}
