using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    public bool Playerisonplatform;
    public float Alpha;
    private Color currentColor;
    public float Speed;
    public float ComeBackTimer;
    public float ComeBackTimerMax;
    void Start()
    {
         currentColor = GetComponent<SpriteRenderer>().color;

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Playerisonplatform = true;
        }

    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Playerisonplatform = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Playerisonplatform == true)
        {
            if (Alpha >= 0)
            {
                Alpha -= Time.deltaTime + Speed;
                GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, Alpha);
            }
            if (Alpha <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                ComeBackTimer = ComeBackTimerMax;
            }
        }
        else
        {
            if (ComeBackTimer < 0)
            {
                if (Alpha <= 1)
                {
                    Alpha += Time.deltaTime + Speed;
                    GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, Alpha);
                }
                if (Alpha >= 1)
                {
                    GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }

        if(ComeBackTimer > 0)
        {
            ComeBackTimer -= Time.deltaTime;
        }
    }
}
