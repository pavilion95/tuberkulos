using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stab : MonoBehaviour
{

    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Start is called before the first frame update
    void Update()
    {
       
    if(Time.time >= nextAttackTime) 
        
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
                nextAttackTime = Time.time + 0.25f / attackRange;

            }
        }    
    

    }

    void Attack()
    {
        anim.SetTrigger("stab");

        //detect enemies 
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        
        
        
        ///dmg them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);

        }

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
