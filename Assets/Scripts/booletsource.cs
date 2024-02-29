using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booletsource : MonoBehaviour
{
    public Transform targetpoint;
    public Camera cameralink;
    public float targetinskydistance;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameralink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetpoint.position = hit.point;
        }
        else
        {
            targetpoint.position = ray.GetPoint(targetinskydistance);
        }

        transform.LookAt(targetpoint.position);
    }
}
