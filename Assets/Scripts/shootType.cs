using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootType : MonoBehaviour
{
    private GameObject ShootType;    
    [SerializeField] Transform gun;
    [SerializeField] GameObject ball, bullet, grenade;
    
 
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && ShootType != null)
        {
            Instantiate(ShootType, gun.position, gun.rotation);
        }                
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {           
            ShootType = bullet;
            Debug.Log("Type : bullet");          
        }
        
        if (other.tag == "Ball")
        {            
            ShootType = ball;
            Debug.Log("Type : ball");          
        }
        
        if (other.tag == "Grenade")
        {          
            ShootType = grenade;
            Debug.Log("Type : grenade");          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ShootType = null;     
    }
}
