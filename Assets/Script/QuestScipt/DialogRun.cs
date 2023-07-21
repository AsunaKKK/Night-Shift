using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRun : MonoBehaviour
{
    public GameObject dialogQuest4;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        RunDialog();
    }
    public void RunDialog()
    {
        if(QuestManager.quest4==true)
        {
            dialogQuest4.SetActive(true);
        }

    }
}
