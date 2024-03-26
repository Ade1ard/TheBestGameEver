using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballcaster : MonoBehaviour
{
    public float damage = 10;
    public boolet booletprefab;
    public Transform booletSourceTransform;
    public AudioSource audio;

    private float _timeLastSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - _timeLastSpawned < 0.2) return;
            var fireball = Instantiate(booletprefab, booletSourceTransform.position, booletSourceTransform.rotation);
            fireball.damage = damage;
            audio.Play();
            _timeLastSpawned = Time.time;
        }
    }
}
