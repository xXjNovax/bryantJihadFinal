using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerOne;
        public float playerSpeed;
    public float playerJump; 
    // Start is called before the first frame update
    void Start()
    {
        playerOne = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            playerOne.AddForce(Vector2.up * playerJump);
        }
    }
    private void FixedUpdate()
    {
        
        if (Input.GetKey("d"))
        {
            playerOne.velocity = new Vector2(playerSpeed, playerOne.velocity.y);
        }
        if (Input.GetKey("a"))
        {
            playerOne.velocity = new Vector2(-playerSpeed, playerOne.velocity.y);
        }
    }
}
