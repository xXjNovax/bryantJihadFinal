using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float PlayerMovement;
    public bool JumpButtonPress;
    Rigidbody2D playerOne;
        public float PlayerSpeed;
    public float PlayerJump;
    public LayerMask RayCastMask;
    public GameObject fireball;
    public HealthBar health;
    public int EndLevel;
    public bool HopzPowerUp;
    public float PlayerDirection;
    public float RaycastDistance;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hopz")
        {
            HitHopzPowerUp();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health.slider.value -= 20;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health.slider.value -= 20;
        }
        if(collision.gameObject.tag == "EndOfLevel")
        {
           // SceneManager.LoadScene(EndLevel);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerOne = GetComponent<Rigidbody2D>();
        health.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
           JumpButtonPress = true;
        }
        PlayerMovement = Input.GetAxis("Horizontal");
        if(PlayerMovement > 0)
        {
            PlayerDirection = 1;
        }
        else if(PlayerMovement < 0)
        {
            PlayerDirection = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           var currentFireball = Instantiate(fireball, transform.position, Quaternion.identity);
            currentFireball.GetComponent<Fireball>().Direction = PlayerDirection;
           
            
        }

        
             
        
       
        
            
      
    }

    private void HitHopzPowerUp()
    {
        PlayerJump = 675;
    }
    private void FixedUpdate()
    {
        if (JumpButtonPress == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RaycastDistance, RayCastMask);
            if(hit.transform != null)
            {
                Debug.Log("hit ground");
                playerOne.AddForce(Vector2.up * PlayerJump);
            }
            JumpButtonPress=false;

        }
        playerOne.velocity = new Vector2(PlayerSpeed * PlayerMovement, playerOne.velocity.y);
    


    
    }
    
}
