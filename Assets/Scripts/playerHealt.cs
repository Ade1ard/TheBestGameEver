using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealt : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;

    private float _maxValue;
    // Start is called before the first frame update
    void Start()
    {
        _maxValue = value;

        DrawHealtBar();
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            Destroy(gameObject);
        }

        DrawHealtBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawHealtBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
 
}
