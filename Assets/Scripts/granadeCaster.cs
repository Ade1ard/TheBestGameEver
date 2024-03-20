﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granadeCaster : MonoBehaviour
{
    public Rigidbody granadeprefab;
    public Transform granadeSourseTransform;

    public float delay = 3;
    private float _timeLastSpawned;

    public float force = 250;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - _timeLastSpawned < delay) return;
            var granade = Instantiate(granadeprefab);
            granade.transform.position = granadeSourseTransform.position;
            granade.GetComponent<Rigidbody>().AddForce(granadeSourseTransform.forward * force);
            _timeLastSpawned = Time.time;
        }
    }
}
