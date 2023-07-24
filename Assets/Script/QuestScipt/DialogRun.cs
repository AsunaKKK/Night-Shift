using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRun : MonoBehaviour
{
    public GameObject dialogQuest;
    public GameObject dialogQuest1;
    public GameObject dialogQuest2;
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
            dialogQuest.SetActive(true);
        }
        if(QuestManager.quest5==true)
        {
            dialogQuest1.SetActive(true);
        }
        if (QuestManager.quest6 == true)
        {
            dialogQuest2.SetActive(true);
        }


    }
}
