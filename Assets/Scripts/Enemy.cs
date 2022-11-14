using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public Transform StartPosition;
    public Transform EndPosition;
    public GameObject FlyGuy;
    public Transform CurrentDestination;
    public float Speed;
    public float DistanceToPlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Fireball")
        {
            Destroy(gameObject);

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        FlyGuy.transform.position = StartPosition.position;
        CurrentDestination = EndPosition;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        float step = Speed * Time.deltaTime;
       FlyGuy.transform.position = Vector2.MoveTowards(FlyGuy.transform.position, CurrentDestination.position, step);
        if (FlyGuy.transform.position == CurrentDestination.position)
        {
            if (CurrentDestination == StartPosition)
            {
                CurrentDestination = EndPosition;
            }
            else
            {
                CurrentDestination = StartPosition;
            }
        }
        if(DistanceToPlayer < 10 && DistanceToPlayer> 2)
        {
            Debug.Log("Is in range");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fireball")
        {
            Destroy(gameObject);

        }
    }
    }
