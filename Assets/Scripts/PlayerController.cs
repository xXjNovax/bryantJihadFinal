using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float PlayerDirection;
    public bool JumpButtonPress;
    Rigidbody2D playerOne;
        public float PlayerSpeed;
    public float PlayerJump;
    public LayerMask RayCastMask;
    public GameObject fireball;
    public HealthBar health;
    public int EndLevel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health.slider.value =- 20;
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
        PlayerDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            
        }
        
             
        
       
        
            
      
    }
    private void FixedUpdate()
    {
        if (JumpButtonPress == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f, RayCastMask);
            if(hit.transform != null)
            {
                Debug.Log("hit ground");
                playerOne.AddForce(Vector2.up * PlayerJump);
            }
            JumpButtonPress=false;

        }
        playerOne.velocity = new Vector2(PlayerSpeed * PlayerDirection, playerOne.velocity.y);
    


    
    }
    
}
