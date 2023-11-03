using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBig : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
   [SerializeField] public HealthbarBehaviour HealthbarBig;
    private HealthBig health;

    private void Awake()
    {
        currentHealth = startingHealth;
        HealthbarBig.SetHealth(currentHealth, startingHealth);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        HealthbarBig.SetHealth(currentHealth, startingHealth);




        if (currentHealth  <= 0)
        {
            scoreSystem.scoreValue += 50;
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
