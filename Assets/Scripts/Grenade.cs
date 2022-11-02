using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    Rigidbody grenade;   
    [SerializeField] float radius = 7f;
    [SerializeField] float throwForce = 5f;
    [SerializeField] ParticleSystem grenadeEffect;
    private float forceGrenade = 900f;
    void Start()
    {      
        grenade = GetComponent<Rigidbody>();
        grenade.AddForce((transform.forward + transform.up) * throwForce, ForceMode.VelocityChange);
    }
    public void Explosion()
    {       
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider near in colliders)
        {
            Rigidbody rigidbody = near.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(forceGrenade, transform.position, radius);
            }
            
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
        Instantiate(grenadeEffect, collision.contacts[0].point, Quaternion.identity);               
    }
}