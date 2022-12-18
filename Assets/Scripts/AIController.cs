using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    //Annimator
    [SerializeField] private Animator m_Animator;

    //AI
    [Header("Combat")]
    [SerializeField] float attackCd = 3f;
    [SerializeField] float attackRange = 3f;
    [SerializeField] float attackAggroRange = 12f;

    Rigidbody rb;
    GameObject player;
    NavMeshAgent agent;
    private float timepassed;
    private float newDestinationCD = 0.5f;

    [SerializeField] EnemyStats enemystats;

    void Start()
    {
        player = GameObject.FindWithTag("GameController");
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(enemystats.alive == true)
        {
            //Ai
            m_Animator.SetFloat("Run", agent.velocity.magnitude / agent.speed);
            if (timepassed >= attackCd)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {

                    m_Animator.SetTrigger("Attack");
                    timepassed = 0;
                    player.GetComponent<PlayerStats>().currentHealth += 5;
                }
            }
            timepassed += Time.deltaTime;

            if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= attackAggroRange)
            {
                newDestinationCD = 0.5f;
                agent.SetDestination(player.transform.position);
            }
            newDestinationCD -= Time.deltaTime;
            transform.LookAt(player.transform);
        }
        else
        {
            m_Animator.SetFloat("Run", 0);
            m_Animator.SetTrigger("Die");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackAggroRange);
    }
}
