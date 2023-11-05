using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{

    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage =0;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Start is called before the first frame update
    void Update()
    {
       
    if(Time.time >= nextAttackTime) 
        
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Attack();
                nextAttackTime = Time.time + 0.25f / attackRange;

            }
        }    
    

    }

    void Attack()
    {
        anim.SetTrigger("boi");

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
