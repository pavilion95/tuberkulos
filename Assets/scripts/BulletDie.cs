using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public GameObject DiePEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
       
        if (collisionGameObject.name != "Player")
        {
            Die();
        }
    }

    void Die()
    {
        
        if (DiePEffect != null)
        {
            Instantiate(DiePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
