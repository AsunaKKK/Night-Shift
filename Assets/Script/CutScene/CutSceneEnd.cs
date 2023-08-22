using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneEnd : MonoBehaviour
{
    public float changeTime;
    private void Update()
    {

        if (Input.GetKey(KeyCode.K))
        {
            changeTime = 0;
        }
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneManager.LoadSceneAsync("Scene00");
        }

    }
}
