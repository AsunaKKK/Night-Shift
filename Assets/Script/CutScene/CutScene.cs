using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public float changeTime;

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            changeTime = 0;
        }
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            //SaveManager.instance.NewGame();
            SceneManager.LoadSceneAsync("Scene001");
        }

    }
}
