using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Load Secne
    public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //ExitGame
    public void ExitGame()
    {
        Application.Quit();
    }
}


