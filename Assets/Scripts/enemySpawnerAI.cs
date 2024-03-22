using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerAI : MonoBehaviour
{
    public enemyai enemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints;
    public playerprogress playerProg;

    public int enemiesMax = 5;
    public float delay = 15f;
    public float increaseEnemyesCountDelay = 25;

    public List<Transform> _enemySpawnPoints;

    private float _timeLastSpawned;

    private void Start()
    {

        Invoke("IncreaseEnemyesMaxCount", increaseEnemyesCountDelay);
    }

    private void IncreaseEnemyesMaxCount()
    {
        if (delay >= 2)
        {
            delay -= 0.5f;
        }
        Invoke("IncreaseEnemyesMaxCount", increaseEnemyesCountDelay);
    }

    private void Update()
    {
        if (Time.time - _timeLastSpawned < delay) return;


        CreateEnemy();
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Count)].position;
        enemy.player = player;
        enemy.targetpoints = patrolPoints;
        enemy.GetComponent<enemyhealt>().playerProgress = playerProg;
        _timeLastSpawned = Time.time;
    }


}
