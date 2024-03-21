using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apteqkaAI : MonoBehaviour
{
    public float healAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealt = other.gameObject.GetComponent<playerHealt>();
        if(playerHealt != null)
        {
            playerHealt.addHealt(healAmount);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 2, 0);
    }
}
