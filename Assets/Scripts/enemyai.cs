using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
    public List<Transform> targetpoints;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    public Animator _animatorEnemy;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        PickNewTargetPoint();
    }

    void Update()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewTargetPoint();
            }
        }
        

        var direction = player.transform.position - transform.position;

        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }

        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        
        if (_navMeshAgent.isStopped == false)
        {
            _animatorEnemy.SetBool("is run", true);
        }

        if (_navMeshAgent.isStopped == true)
        {
            _animatorEnemy.SetBool("is run", false);
        }
    }
    private void PickNewTargetPoint()
    {
        _navMeshAgent.destination = targetpoints[Random.Range(0, targetpoints.Count)].position;
    }
}
