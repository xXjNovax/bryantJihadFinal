using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityEnemy : MonoBehaviour
{
    public float DistanceToPlayer;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        if (DistanceToPlayer < 10 && DistanceToPlayer > 2)
        {
            Debug.Log("Is in range");
        }
    }
}
