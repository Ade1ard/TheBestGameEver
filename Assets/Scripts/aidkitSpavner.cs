using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aidkitSpavner : MonoBehaviour
{
    public apteqkaAI apteqkaPrefab;
    public float delaymin = 10;
    public float delaymax = 25;

    public List<Transform> spawnPoints;

    private apteqkaAI _aidkit;

    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;
        Invoke("CreateAidkit", Random.Range(delaymin, delaymax));
    }

    private void CreateAidkit()
    {
        _aidkit = Instantiate(apteqkaPrefab);
        _aidkit.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
    }

}