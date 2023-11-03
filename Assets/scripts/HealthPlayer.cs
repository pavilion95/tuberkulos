using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    public int currentHealth { get; private set; }

    public HealthBar healthBar;
    public int maxHealth = 10;
    private Vector3 respawnPoint;
    
    public TextMeshProUGUI Text;

    [SerializeField] Gameover Gameover;
    


    private void Awake()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(maxHealth);

        // HealthBar.SetHealth(currentHealth, startingHealth);
    }

    public void AddHealth(int Maxhealth)
    {
        currentHealth = +Maxhealth;
        healthBar.SetHealth(currentHealth);
    }


    private void Update()

    {
       if (Input.GetKeyDown(KeyCode.T))
            TakeDamage(1);


    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        // X
        // HealthBar.SetHealth(currentHealth, startingHealth);

        healthBar.SetHealth(currentHealth);



        if (currentHealth <= 0)
        {
            
            Die();
            Gameover.SetGameOver();
        }
        else
        {


            //player dead


        }

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "FallDetector")
        {

            transform.position = respawnPoint;
            Die();
            Gameover.SetGameOver();

        }







    }




        void Die()
        {
            Destroy(gameObject);
            transform.position = respawnPoint;
            
        }




    
}
