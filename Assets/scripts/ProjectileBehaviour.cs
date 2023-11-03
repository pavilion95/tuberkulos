using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float timer;
    public float Speed = 4.5f;
    public float TakeDamage = 0f;
   private void Update()
    {
        if (timer >= 3f)
        {
            GameObject.Destroy(gameObject);
        }
        
        
        
        timer += 2f * Time.deltaTime;

        transform.position += transform.right * Time.deltaTime * Speed;
    }


   



    private void OnTriggerEnter2D (Collider2D collision)
    {
       // Destroy(gameObject);

        if (collision.tag == "Enemy")
           
            collision.GetComponent<Health>().TakeDamage(2);

    }

}
