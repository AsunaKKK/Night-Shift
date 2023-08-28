using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRun : MonoBehaviour , IDataSave
{
    public GameObject dialogQuest0;
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
    public GameObject dialogQuest11;
    public GameObject dialogQuest12;

    //Save dialog
    public int dialogSave1 = 0;
    // Update is called once per frame
    void Update()
    {
        RunDialog();
    }
    public void RunDialog()
    {
        if (QuestManager.questID == 1)
        {
            dialogSave1 = 1;
        }
        if(dialogSave1 == 1)
        {
            dialogQuest0.SetActive(true);
        }

        if (QuestManager.questID == 4)
        {
            dialogSave1 = 2;
        }
        if (dialogSave1 == 2)
        {
            dialogQuest.SetActive(true);
        }

        if (QuestManager.questID == 5)
        {
            dialogSave1 = 3;
        }
        if (dialogSave1 == 3)
        {
            dialogQuest1.SetActive(true);
        }

        if (QuestManager.questID == 6)
        {
            dialogSave1 = 4;
        }
        if (dialogSave1 == 4)
        {
            dialogQuest2.SetActive(true);
        }

        if (QuestManager.questID == 7)
        {
            dialogSave1 = 5;
        }
        if (dialogSave1 == 5)
        {
            dialogQuest3.SetActive(true);
        }

        if (QuestManager.quest8Completion)
        {
            dialogSave1 = 6;
        }
        if (dialogSave1 == 6)
        {
            dialogQuest4.SetActive(true);
        }

        if (QuestManager.quest9Completion)
        {
            dialogSave1 = 7;
        }
        if (dialogSave1 == 7)
        {
            dialogQuest5.SetActive(true);
        }

        if (QuestManager.quest10Completion)
        {
            dialogSave1 = 8;
        }
        if (dialogSave1 == 8)
        {
            dialogQuest6.SetActive(true);
        }

        if (QuestManager.quest11Completion)
        {
            dialogSave1 = 9;
        }
        if (dialogSave1 == 9)
        {
            dialogQuest7.SetActive(true);
        }

        if (QuestManager.questID == 13)
        {
            dialogSave1 = 10;
        }
        if (dialogSave1 == 10)
        {
            dialogQuest8.SetActive(true);
        }

        if (QuestManager.questID == 14)
        {
            dialogSave1 = 11;
        }
        if (dialogSave1 == 11)
        {
            dialogQuest9.SetActive(true);
        }

        if (QuestManager.questID == 15)
        {
            dialogSave1 = 12;
        }
        if (dialogSave1 == 12)
        {
            dialogQuest10.SetActive(true);
        }

        if (QuestManager.questID == 17)
        {
            dialogSave1 = 13;
        }
        if (dialogSave1 == 13)
        {
            dialogQuest11.SetActive(true);
        }

        if (QuestManager.questID == 20)
        {
            dialogSave1 = 14;
        }
        if (dialogSave1 == 14)
        {
            dialogQuest12.SetActive(true);
        }


    }

    public void SaveData(GameData data)
    {
        data.dialogSave1s = dialogSave1;

    }

    public void LoadData(GameData data)
    {
        dialogSave1 = data.dialogSave1s;
    }
}
