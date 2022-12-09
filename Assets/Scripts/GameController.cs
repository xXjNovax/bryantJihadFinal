using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int LevelNumber;
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

            MainMenuLoad();

        }

    }
    public void MainMenuLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
