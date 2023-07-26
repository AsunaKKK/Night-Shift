using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRun : MonoBehaviour
{
    public GameObject dialogQuest;
    public GameObject dialogQuest1;
    public GameObject dialogQuest2;
    public GameObject dialogQuest3;
    public GameObject dialogQuest4;
    public GameObject dialogQuest5;
    public GameObject dialogQuest6;
    public GameObject dialogQuest7;
    public GameObject dialogQuest8;
    public GameObject dialogQuest9;
    public GameObject dialogQuest10;

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
        if (QuestManager.questID == 7)
        {
            dialogQuest3.SetActive(true);
        }
        
        if (QuestManager.quest8Completion)
        {
            dialogQuest4.SetActive(true);
        }
        if (QuestManager.quest9Completion)
        {
            dialogQuest5.SetActive(true);
        }
        if (QuestManager.quest10Completion)
        {
            dialogQuest6.SetActive(true);
        }
        if (QuestManager.questID == 12)
        {
            dialogQuest7.SetActive(true);
        }
        if (QuestManager.questID == 13)
        {
            dialogQuest8.SetActive(true);
        }
        if (QuestManager.questID == 14)
        {
            dialogQuest9.SetActive(true);
        }
        if (QuestManager.questID == 15)
        {
            dialogQuest10.SetActive(true);
        }


    }
}
