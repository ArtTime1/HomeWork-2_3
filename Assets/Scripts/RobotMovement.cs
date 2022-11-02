using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;

        if (sideForce != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }
    }
}
