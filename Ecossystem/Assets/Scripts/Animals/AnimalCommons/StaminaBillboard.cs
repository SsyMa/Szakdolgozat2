using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBillboard : MonoBehaviour
{
    public Transform cam;
    private void Start()
    {
        cam = GameObject.Find("Camera").transform;
    }
    void LateUpdate()
    {
        if(cam != null)
        {
            transform.LookAt(transform.position + cam.forward);
        }
        else
        {
            cam = FindObjectOfType<Camera>()?.transform;
        }
    }
}
