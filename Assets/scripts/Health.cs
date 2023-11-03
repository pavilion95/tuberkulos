using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    public HealthbarBehaviour Healthbar;
    private Health health;
    public lootdrop thisloot;


    private void Start()
    {
        thisloot = GetComponent<lootdrop>();
        
    
    }


    private void Awake()
    {
        currentHealth = startingHealth;
        Healthbar.SetHealth(currentHealth, startingHealth);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        Healthbar.SetHealth(currentHealth, startingHealth);




        if (currentHealth  <= 0)
        {
            scoreSystem.scoreValue += 10;
            if(thisloot !=null)
            {
                thisloot.DropItem();
                Debug.Log("Dropped an item" + thisloot);
            }
            Die();

        }
        
        
        else
        {

            
            //player dead


        }



    }

    
   


    void Die()
    {
        
        Destroy(gameObject);
    }


}
