using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ballPrefab;
    public GameObject GrenadePrefab;
    string Bulletq;
    

    public float bulletforce = 20f;
    public float ballforce = 50f;
    public float GranadeForce = 7f;
    
    
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    void Update()
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

        if (Input.GetButtonDown("Fire1") && Bulletq == "Bullet")
        {
            ShootBullet();
        }

        if (Input.GetButtonDown("Fire1") && Bulletq == "Ball")
        {
            Ball();
        }

        if (Input.GetButtonDown("Fire1") && Bulletq == "Granade")
        {
            Granade();
        }
    }

    public void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Bullet")
        {
            Bulletq = other.tag;
            Debug.Log(Bulletq + "= Change to Bullets");
          
        }
        
        if (other.tag == "Ball")
        {
            Bulletq = other.tag;
            Debug.Log(Bulletq + "= Change to ball");

        }

        if (other.tag == "Granade")
        {
           Bulletq = other.tag;
           Debug.Log(Bulletq + "= Change to Granade");

        }

    }

    public void OnTriggerExit(Collider other)
    {
        Bulletq = null;
    }

    public void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody RB = bullet.GetComponent<Rigidbody>();
        RB.AddForce(firePoint.forward * bulletforce, ForceMode.Impulse);

    }

    public void Ball()
    {
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody ballT = ball.GetComponent<Rigidbody>();
        ballT.AddForce(firePoint.forward * ballforce, ForceMode.Impulse);

    }


    private void Granade()
    {
        GameObject grenade = Instantiate(GrenadePrefab, firePoint.transform.position, firePoint.rotation);
        Rigidbody RbGrenade = grenade.GetComponent<Rigidbody>();
        RbGrenade.AddForce((firePoint.forward + firePoint.up) * GranadeForce, ForceMode.Impulse);
 
    }
}
