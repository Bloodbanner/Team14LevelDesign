using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject weaponPistol;
    [SerializeField] GameObject weaponAxe;
    [SerializeField] GameObject weaponHammer;
    [SerializeField] GameObject crowbar;
    [SerializeField] private Animator m_Animator;

    [SerializeField] GameUi gameUi;

    public bool havePistol = false;
    public bool haveAxe = false;
    public bool haveHammer = false;
    public bool havecrowBar = false;

    public int equippedItem;

    public int bullets = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (havePistol == true)
            {
                equippedItem = 1;
                weaponPistol.SetActive(true);
                weaponAxe.SetActive(false);
                weaponHammer.SetActive(false);
                crowbar.SetActive(false);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (haveHammer == true)
            {
                equippedItem = 2;
                weaponPistol.SetActive(false);
                weaponAxe.SetActive(false);
                weaponHammer.SetActive(true);
                crowbar.SetActive(false);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (havecrowBar == true)
            {
                equippedItem = 3;
                weaponPistol.SetActive(false);
                weaponAxe.SetActive(false);
                weaponHammer.SetActive(false);
                crowbar.SetActive(true);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (haveAxe == true)
            {
                equippedItem = 4;
                weaponPistol.SetActive(false);
                weaponAxe.SetActive(true);
                weaponHammer.SetActive(false);
                crowbar.SetActive(false);
            }
            
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        

        if (collision.gameObject.CompareTag("Crowbar"))
        {
            Destroy(collision.gameObject);
            havecrowBar = true;
            equippedItem = 3;
                                 

            weaponPistol.SetActive(false);
            weaponAxe.SetActive(false);
            weaponHammer.SetActive(false);
            crowbar.SetActive(true);
           
        }
        if (collision.gameObject.CompareTag("Axe"))
        {
            Destroy(collision.gameObject);
            haveAxe = true;
            equippedItem = 4;

            weaponPistol.SetActive(false);
            weaponAxe.SetActive(true);
            weaponHammer.SetActive(false);
            crowbar.SetActive(false);
          
        }
        if (collision.gameObject.CompareTag("Pistol"))
        {
            Destroy(collision.gameObject);
            bullets = bullets + 10;
            havePistol = true;
            equippedItem = 1;

            weaponPistol.SetActive(true);
            weaponAxe.SetActive(false);
            weaponHammer.SetActive(false);
            crowbar.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Hammer"))
        {
            Destroy(collision.gameObject);
            haveHammer = true;
            equippedItem = 2;

            weaponPistol.SetActive(false);
            weaponAxe.SetActive(false);
            weaponHammer.SetActive(true);
            crowbar.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
            bullets = bullets + 10;


        }
    }

  



}