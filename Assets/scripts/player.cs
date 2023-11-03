using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 10f;
    
    public float jumpForce = 11f;

    private float movementX;
    private float movementY;
    public Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string GROUND_TAG = "Ground";
	private string ENEMY_TAG = "Enemy";
	Vector3 velocity = new Vector3(10f, 10f, 10f);
    private bool isGrounded ;
    private bool isEnemy;
    private object rb;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public Transform LaunchOffset2;
    bool facingRight = true;
    public int maxAmmo;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    
    

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f, 0f);
    }

    private void Awake ()
    {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
       // GetComponent<Rigidbody2D>().velocity = velocity;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {

        currentAmmo = maxAmmo;
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

        
        //fall to death
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        





        if (Input.GetButtonDown("Fire1") && currentAmmo >= 0)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.transform.rotation);
            ammoText.text = currentAmmo.ToString();
            currentAmmo--;
        }


      

        if (movementX<0 && facingRight)
        {
            flip();
        }
        else if (movementX>0 && !facingRight)
        {
            flip();
        }
    }
    //death after falling
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "FallDetector")
        {

            transform.position = respawnPoint;
            


        }
    }

    



    void PlayerMoveKeyboard() {

        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
//ner knapp
       // movementY = Input.GetAxis("Vertical");

      // transform.position += new Vector3(0f, movementY) * Time.deltaTime * 10;

    }
    void AnimatePlayer() {
       
        //we are going right
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            

        }

        else if (movementX < 0 )
        {
           
            //walk left
          
            anim.SetBool(WALK_ANIMATION, true);
            


        }
        else 
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    
    }
    //jumping
    void PlayerJump() {

        if (Input.GetButtonDown("Jump") && isGrounded  ) {
           isGrounded = false;
           
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
            anim.SetBool("Jump", true);
            anim.Play("Jump");

        
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag (GROUND_TAG) | collision.gameObject.CompareTag(ENEMY_TAG) ) {
           isGrounded = true;
            
            //Debug.Log("marken");
       
            anim.SetBool("Jump", !isGrounded);
        
        }


    }



    public void UpdateAmmo (int ammo)
    {
        currentAmmo += ammo;
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        ammoText.text = currentAmmo.ToString();
    }



    void Die()
    {
       
       // Destroy(gameObject);
        transform.position = respawnPoint;
    }



    

}

