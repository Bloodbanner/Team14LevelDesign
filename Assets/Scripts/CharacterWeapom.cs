using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterWeapom : MonoBehaviour
{
    // this is in seconds so 0.5 seconds till they can shoot again
    [SerializeField] private float shootCooldown = 1.5f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootinStartPostion;
    [SerializeField] private GameObject attackIndicatorPrefab;
        

    private float shootTimer = 0f;
    public Animator m_Animator;

    float waitfiretime;

    private void Start()
    {

    }


    private void Update()
    {
        if (shootTimer < shootCooldown)
        {
            shootTimer += Time.deltaTime;
        }
    }

    // Update is called once per frame
   public void Fire()
    {

        waitfiretime = 180f;
        m_Animator.SetBool("Attack", true);
        GameObject newProjectile = Instantiate(projectilePrefab, shootinStartPostion.position, shootinStartPostion.rotation);
        GameObject attackIndicator = Instantiate(attackIndicatorPrefab, shootinStartPostion.position, shootinStartPostion.rotation);
        Destroy(attackIndicator, 0.2f);
        StartCoroutine(FireCoroutine());
        
    }

    IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(waitfiretime);
        m_Animator.SetBool("Attack", false);

    }


}