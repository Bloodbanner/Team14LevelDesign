using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float maxhealth = 100;
    public float currentHealth = 100;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= 100)
        {

            Destroy(this, 3);
                        
        }
    }
}
