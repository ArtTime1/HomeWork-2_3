using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bullet;
    [SerializeField] float bulletVelocity = 10f;
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bullet.AddForce(transform.forward * bulletVelocity, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
