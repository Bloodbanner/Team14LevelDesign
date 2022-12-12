using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public bool canmove = true;
    [SerializeField] private Animator m_Animator;

    Rigidbody m_Rigidbody;
    public float m_Speed;
    public float m_RotationSpeed;
    public float sprintspeed;
    public bool isAiming;

    // Start is called before the first frame update  
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    public CharacterWeapom characterWeapon;

    void FixedUpdate()
    {
         
            if (canmove == true)
            {

                //Movment

                if (Input.GetKey(KeyCode.W))
                {
                    m_Rigidbody.velocity = transform.forward * m_Speed * Time.deltaTime;
                    m_Animator.SetBool("RunForward", true);                 
                }
              
                if (Input.GetKey(KeyCode.S))
                {
                    m_Rigidbody.velocity = transform.forward * -1 * m_Speed * Time.deltaTime;
                    m_Animator.SetBool("RunBackwards", true);                     
                }
           
                if (Input.GetKey(KeyCode.E))
                {
                    m_Rigidbody.velocity = transform.right * 1 * m_Speed * Time.deltaTime;
                    m_Animator.SetBool("WalkingLeft", true);
                }
             
                if (Input.GetKey(KeyCode.Q))
                {
                    m_Rigidbody.velocity = transform.right * -1 * m_Speed * Time.deltaTime;
                    m_Animator.SetBool("WalkingRight", true);
                }
                                
                //Rotation

                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.Rotate(Vector3.up, -m_RotationSpeed);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.Rotate(Vector3.up, m_RotationSpeed);
                }
                       
            }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isAiming == true)
            {
                characterWeapon.Fire();
                m_Animator.SetTrigger("Fire");
            }
        }





        if (Input.GetKeyUp(KeyCode.Q))
        {
            m_Animator.SetBool("WalkingRight", false);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            m_Animator.SetBool("WalkingLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            m_Animator.SetBool("RunForward", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            m_Animator.SetBool("RunBackwards", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_Speed += sprintspeed;
            m_Animator.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_Speed -= sprintspeed;
            m_Animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isAiming = true;
            m_Animator.SetBool("Aiming", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isAiming = false;
            m_Animator.SetBool("Aiming", false);
        }
    }
}