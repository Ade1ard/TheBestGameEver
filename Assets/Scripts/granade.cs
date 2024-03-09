using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explasionPrefab;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", 3);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explasionPrefab);
        explosion.transform.position = transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
