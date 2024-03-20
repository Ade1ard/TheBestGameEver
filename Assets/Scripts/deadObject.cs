using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadObject : MonoBehaviour
{
    public float timetodead;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timetodead);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
