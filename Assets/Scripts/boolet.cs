using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemyhealt = collision.gameObject.GetComponent<enemyhealt>();
        if (enemyhealt != null)
        {
            enemyhealt.DealDamage(damage);
        }



        DestroyFireball();
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
