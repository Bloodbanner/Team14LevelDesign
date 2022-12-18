using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public bool alive = true;
    public float MaxHealth;
    public float currentHealth;
    public float minDamage;
    public float maxDamage;

    [SerializeField] Animator m_Animator;
    [SerializeField] CapsuleCollider capsulCollider;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            alive = false;

           
            Destroy(capsulCollider, 1);
            
           
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount;
    }
}
