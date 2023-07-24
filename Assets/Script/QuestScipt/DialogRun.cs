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
        if(QuestManager.questID == 4)
        {
            dialogQuest.SetActive(true);
        }
        if(QuestManager.questID == 5)
        {
            dialogQuest1.SetActive(true);
        }
        if (QuestManager.questID == 6)
        {
            dialogQuest2.SetActive(true);
        }


    }
}
