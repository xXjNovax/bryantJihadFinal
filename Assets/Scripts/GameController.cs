using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))

        {

            Application.Quit();

        }

        else if (Input.GetKey(KeyCode.R))

        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
    }
}
