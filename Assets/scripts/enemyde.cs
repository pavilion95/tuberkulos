using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyde : MonoBehaviour
{
    float health = 10;
    // use OnCollisionEnter2D if you don't have trigger on your bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // You just put script where you have saved your bullet's damage 
            float Damage = other.GetComponent<bulletsssss>().Damage;
            health -= Damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
