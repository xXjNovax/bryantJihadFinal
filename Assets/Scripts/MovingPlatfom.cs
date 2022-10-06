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
    // Start is called before the first frame update
    void Start()
    {
        Platform.transform.position = StartPosition.position;
        CurrentDestination = EndPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Speed * Time.deltaTime;
        Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, CurrentDestination.position, step);
    }
}
