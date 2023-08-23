using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnd : MonoBehaviour
{
    void Update()
    {
        if(QuestManager.questID == 25)
        {
            SceneManager.LoadSceneAsync("Scene03");
        }
    }
}
