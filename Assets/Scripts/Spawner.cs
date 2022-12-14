using Pathfinding;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie_normal;
    public float difficultyCoeff = 0.1f;
    public float timedDifficulty = 0;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad < 100)
            timedDifficulty = Time.timeSinceLevelLoad * difficultyCoeff;
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject zombie = Instantiate(zombie_normal, gameObject.transform.position, gameObject.transform.rotation);
            EnemyController zombieController = (EnemyController)zombie.GetComponent("EnemyController");
            AIPath zPath = (AIPath)zombie.GetComponent("AIPath");
            zombieController.health = Mathf.RoundToInt(Random.Range(70 + timedDifficulty * 2, 312 + timedDifficulty * 3));
            zombieController.damage = Mathf.RoundToInt(Random.Range(10 + timedDifficulty * 1.5f, 57 + timedDifficulty * 1.5f));
            zPath.maxSpeed = Random.Range(1 + timedDifficulty, 4 + timedDifficulty);
            zombieController.reward = Mathf.RoundToInt((zombieController.health * 0.05f + zombieController.damage * 0.1f + zPath.maxSpeed * 2));
            yield return new WaitForSeconds(Random.Range(4, 12));
        }
    }

    public void endGame()
    {
        StopAllCoroutines();
    }
}
