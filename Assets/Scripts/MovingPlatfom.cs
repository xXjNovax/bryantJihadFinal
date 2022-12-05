using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfom : MonoBehaviour
{
   
     public Transform StartPosition;
    public Transform EndPosition;
    public GameObject Platform;
    public Transform CurrentDestination;
    public float Speed;
    public bool PlayerIsOn;
    public bool NeedsPlayer;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.parent = gameObject.transform;
            PlayerIsOn = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.parent = null;
            PlayerIsOn = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Platform.transform.position = StartPosition.position;
        CurrentDestination = EndPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(NeedsPlayer == true)
        {
            if (PlayerIsOn == true)
            {
                MovePlatform();
            }
            else
            {
                ReturPlatform();
            }
            
        
        }
        else
        {

            MovePlatform();
            
        }
        

     
    }

    public void MovePlatform()
    {

        float step = Speed * Time.deltaTime;
        Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, CurrentDestination.position, step);
        if (Platform.transform.position == CurrentDestination.position)
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
        
    }
    public void ReturPlatform()
    {
        float step = Speed * Time.deltaTime;
        Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, StartPosition.position, step);
        
        
        }
}
