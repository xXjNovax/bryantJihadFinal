using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProximityEnemy : MonoBehaviour
{
    public float DistanceToPlayer;
    public GameObject Player;
    public float Speed;
    public float MinDistance;
    public float MaxDistance;
    public AudioClip ProximitysEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            AudioSource.PlayClipAtPoint(ProximitysEffect, transform.position);
            Destroy(gameObject);

        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        if (DistanceToPlayer < MaxDistance && DistanceToPlayer > MinDistance)
        {
            float step = Speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ( collision.gameObject.tag == "Fireball")
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {
            //Damage to Player
            Destroy (gameObject);
        }
    }
}
