
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   [Header ("Patrol Points")]
   [SerializeField] private Transform leftEdge;
   [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    float health = 10;





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            float damage = other.GetComponent<bulletsssss>().Damage;
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    private void Awake()
    {
        initScale = enemy.localScale;
    }



    private void Update()
    {
      if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
        
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }




    private void MoveInDirection(int _direction)
    {
        //Make enemy face direction
        enemy.localScale = new Vector3((initScale.x) * _direction, initScale.y, initScale.z);



        //move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

}
