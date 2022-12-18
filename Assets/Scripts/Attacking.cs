using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private GameObject meleePrefab;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootinStartPostion;
    [SerializeField] private GameObject attackIndicatorPrefab;
    [SerializeField] private Animator m_Animator;

    [SerializeField] Inventory inventory;

    public void Update()
    {
        //Fire
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(inventory.equippedItem == 1)
            {
                if(inventory.bullets>= 1)
                {
                    Fire();
                    m_Animator.SetTrigger("Shoot");
                    inventory.bullets = inventory.bullets - 1;
                }
                
            }
            if (inventory.equippedItem == 2 || inventory.equippedItem == 3 || inventory.equippedItem == 4)
            {
                Attack();
                m_Animator.SetTrigger("AttackMelee");
                
            }


        }
    }

    public void Fire()
    {
        {
            GameObject newProjectile = Instantiate(projectilePrefab, shootinStartPostion.position, shootinStartPostion.rotation);
            GameObject attackIndicator = Instantiate(attackIndicatorPrefab, shootinStartPostion.position, shootinStartPostion.rotation);
            Destroy(attackIndicator, 0.2f);          
        }
    }
    public void Attack()
    {
        GameObject newProjectile = Instantiate(meleePrefab, shootinStartPostion.position, shootinStartPostion.rotation);       
        Destroy(newProjectile, 0.7f);
      
    }

}
