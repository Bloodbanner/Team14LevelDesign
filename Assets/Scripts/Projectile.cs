using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody bulletRB;
    public int bulletSpeed;
    [SerializeField] GameObject damageIndicatorsPrefab;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB.useGravity = false;
        bulletRB.AddForce(bulletRB.transform.forward * bulletSpeed, ForceMode.VelocityChange);
        player = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
           

            // Checks if the tag is an Enemy
            if (collision.gameObject.CompareTag("Enemy"))
            {

                bulletRB.velocity = Vector3.zero;
                Destroy(this.gameObject);
                GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
                damageIndicator.transform.position = collision.GetContact(0).point;
                Destroy(damageIndicator, 0.5f);


                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(3);

                

            }
            if (collision.gameObject.CompareTag("Terrain"))
            {

                bulletRB.velocity = Vector3.zero;
                Destroy(this.gameObject);
                GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
                damageIndicator.transform.position = collision.GetContact(0).point;
                Destroy(damageIndicator, 0.5f);

                
            }
            if (collision.gameObject.CompareTag("DoorExp"))
            {
                if(player.GetComponent<Inventory>().equippedItem == 2 || player.GetComponent<Inventory>().equippedItem == 3)
                { 
                    bulletRB.velocity = Vector3.zero;
                    Destroy(this.gameObject);
                    GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
                    damageIndicator.transform.position = collision.GetContact(0).point;
                    Destroy(damageIndicator, 0.5f);

                    Destroy(collision.gameObject);

                    
                }
                

            }
        
    }


}
