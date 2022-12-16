using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    public GameObject Crowbar;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                CrowbarAttack();
            }
        }
    }

    public void CrowbarAttack()
    {
        CanAttack = false;
        Animator anim = Crowbar.GetComponent<Animator>();
        anim.SetTrigger("Attack");


        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

}