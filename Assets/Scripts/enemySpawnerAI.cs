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
    public float delay = 5;
    public float increaseEnemyesCountDelay = 30;

    private List<Transform> _enemySpawnPoints;
    private List<enemyai> _enemyes;

    private float _timeLastSpawned;

    private void Start()
    {
        _enemySpawnPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemyes = new List<enemyai>();
        Invoke("IncreaseEnemyesMaxCount", increaseEnemyesCountDelay);

    }

    private void IncreaseEnemyesMaxCount()
    {
        enemiesMax++;
        Invoke("IncreaseEnemyesMaxCount", increaseEnemyesCountDelay);
    }

    private void Update()
    {
        for(var i = 0; i <_enemyes.Count; i++)
        {
            if (_enemyes[i].IsAlive()) continue;
            _enemyes.RemoveAt(i);
            i--;
        }

        if (_enemyes.Count >= enemiesMax) return;
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
        _enemyes.Add(enemy);
        _timeLastSpawned = Time.time;
    }


}
