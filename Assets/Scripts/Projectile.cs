using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody bulletRB;
    public int bulletSpeed;
    [SerializeField] GameObject damageIndicatorsPrefab;


    // Start is called before the first frame update
    void Start()
    {
        bulletRB.useGravity = false;
        bulletRB.AddForce(bulletRB.transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
               

        {
            // Checks if the tag is an Enemy
            if (collision.gameObject.CompareTag("Enemy"))
            {

                bulletRB.velocity = Vector3.zero;
                Destroy(this.gameObject);
                GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
                damageIndicator.transform.position = collision.GetContact(0).point;
                Destroy(damageIndicator, 0.5f);
            }
            else if (collision.gameObject.CompareTag("Terrain"))
            {

                bulletRB.velocity = Vector3.zero;
                Destroy(this.gameObject);
                GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
                damageIndicator.transform.position = collision.GetContact(0).point;
                Destroy(damageIndicator, 0.5f);
            }

        }
    }


}
