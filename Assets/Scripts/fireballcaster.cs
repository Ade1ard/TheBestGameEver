using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballcaster : MonoBehaviour
{
    public float damage = 10;
    public boolet booletprefab;
    public Transform booletSourceTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(booletprefab, booletSourceTransform.position, booletSourceTransform.rotation);
            fireball.damage = damage;
        }
    }
}
