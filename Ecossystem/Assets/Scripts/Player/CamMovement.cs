using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CamMovement : NetworkBehaviour
{
    float speed = 5f;
    float rotationSpeed = 5f;

    int playerNumber;

    private void Start()
    {
        
        if (IsOwner)
        {
            GameObject cam = gameObject.GetComponentInChildren<Camera>().gameObject;
            JoinManager joinManager = JoinManager.Instance;
            playerNumber = joinManager.OnPlayerJoined(cam);
            cam.SetActive(true);
        }
        else
        {
            GameObject cam = gameObject.GetComponentInChildren<Camera>().gameObject;
            cam.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!IsOwner) return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.position += -transform.up * Time.deltaTime * speed;
        }

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            Quaternion pitch = Quaternion.AngleAxis(mouseX, Vector3.up);
            Quaternion yaw = Quaternion.AngleAxis(-mouseY, transform.right);
            Vector3 lookDirection = pitch * yaw * transform.forward;
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
