using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody ball;
    [SerializeField] float ballForce = 5f;
    [SerializeField] float throwForce = 5f;
    [SerializeField] ParticleSystem ballEffect;
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.AddForce(transform.forward * ballForce + transform.up * throwForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ballEffect, collision.contacts[0].point, Quaternion.identity);
        Destroy(gameObject, 5);
        ballEffect.Play();
    }
}
