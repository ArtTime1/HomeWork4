using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float radius = 7f;
    float forceGrenade = 900f;
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void Explode()
    {
        Instantiate(gameObject, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider near in colliders)
        {
            Rigidbody rigidbody = near.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(forceGrenade, transform.position, radius );
            }
            
        }

       
        Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
       
    }
}