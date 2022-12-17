using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUi : MonoBehaviour
{
    public GameObject player;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Inventory inventory;

    [SerializeField] public Image healthBar;
    [SerializeField] public Image gunWeaponImage;
    [SerializeField] public Image axeWeaponImage;
    [SerializeField] public Image crowbarWeaponImage;
    [SerializeField] public Image hammerWeaponImage;
    [SerializeField] public Image button1;
    [SerializeField] public Image button2;
    [SerializeField] public Image button3;
    [SerializeField] public Image button4;
    [SerializeField] public TextMeshProUGUI buttonText1;
    [SerializeField] public TextMeshProUGUI buttonText2;
    [SerializeField] public TextMeshProUGUI buttonText3;
    [SerializeField] public TextMeshProUGUI buttonText4;
    [SerializeField] public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Update Health&ActionBar
        healthBar.fillAmount = playerStats.currentHealth / playerStats.maxhealth;

        if(inventory.equippedItem == 1)
        {
            ammoText.enabled = true;
            ammoText.text = "Ammo: " + inventory.bullets;
        }
        else 
        {
            ammoText.enabled = false;
        }
        

        if(inventory.haveAxe == true)
        {
            axeWeaponImage.enabled = true;
            button4.enabled = true;
            buttonText4.enabled = true;
        }
        else
        {
            axeWeaponImage.enabled = false;
            button4.enabled = false;
            buttonText4.enabled = false;
        }
        if (inventory.havePistol == true)
        {
            gunWeaponImage.enabled = true;
            button1.enabled = true;
            buttonText1.enabled = true;
        }
        else
        {
            gunWeaponImage.enabled = false;
            button1.enabled = false;
            buttonText1.enabled = false;
        }
        if (inventory.havecrowBar == true)
        {
            crowbarWeaponImage.enabled = true;
            button3.enabled = true;
            buttonText3.enabled = true;
        }
        else
        {
            crowbarWeaponImage.enabled = false;
            button3.enabled = false;
            buttonText3.enabled = false;
        }
        if (inventory.haveHammer == true)
        {
            hammerWeaponImage.enabled = true;
            button2.enabled = true;
            buttonText2.enabled = true;
        }
        else
        {
            hammerWeaponImage.enabled = false;
            button2.enabled = false;
            buttonText2.enabled = false;
        }
    }
}
