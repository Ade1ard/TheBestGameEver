using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosioAi : MonoBehaviour
{
    public float damage = 50;
    public float maxSize = 6;
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;

        if(transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealt = other.GetComponent<playerHealt>();
        if (playerHealt != null)
        {
            playerHealt.DealDamage(damage);
        }

        var enemyHealt = other.GetComponent<enemyhealt>();
        if (enemyHealt != null)
        {
            enemyHealt.DealDamage(damage);
        }
    }
}
