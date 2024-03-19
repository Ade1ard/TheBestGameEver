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
    public float delay = 15;
    public float increaseEnemyesCountDelay = 20;

    private List<Transform> _enemySpawnPoints;

    private float _timeLastSpawned;

    private void Start()
    {
        _enemySpawnPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        Invoke("IncreaseEnemyesMaxCount", increaseEnemyesCountDelay);

    }

    private void IncreaseEnemyesMaxCount()
    {
        if (delay >= 1)
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
