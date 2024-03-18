using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealt : MonoBehaviour
{
    public playerprogress playerProgress;

    public float value = 100;
    // Start is called before the first frame update

    public bool IsAlive()
    {
        return value > 0;
    }
    void Start()
    {
        
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            playerProgress.AddEXP(20);
            Dead();
        }
    }

    public void Dead()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
