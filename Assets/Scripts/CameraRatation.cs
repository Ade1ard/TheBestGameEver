using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRatation : MonoBehaviour
{
    public float RotatoinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotatoinSpeed * Input.GetAxis("Mouse X"), 0);
    }
}
