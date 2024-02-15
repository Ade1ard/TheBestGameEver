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

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        PickNewTargetPoint();
    }

    void Update()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewTargetPoint();
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
        
    }
    private void PickNewTargetPoint()
    {
        _navMeshAgent.destination = targetpoints[Random.Range(0, targetpoints.Count)].position;
    }
}
