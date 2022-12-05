using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 900f;
    public Rigidbody2D rb;
    public float Direction;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * Direction;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        
    }

    private void Update()
    {
      
    }

}
