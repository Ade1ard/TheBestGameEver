using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyhealt : MonoBehaviour
{
    public playerprogress playerProgress;

    public Animator animatorEnemy;


    public float value = 100;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            playerProgress.AddEXP(15);
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.GetComponent<enemyai>().enabled = false;
        gameObject.GetComponent<enemyhealt>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        animatorEnemy.SetBool("is run", false);
        animatorEnemy.SetTrigger("IsAlive");

        Invoke("FullDead", 30);
    }

    public void FullDead()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
