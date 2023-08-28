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
    public int dialogSave2 = 0;
    public int dialogSave3 = 0;
    public int dialogSave4 = 0;
    public int dialogSave5 = 0;
    public int dialogSave6 = 0;
    public int dialogSave7 = 0;
    public int dialogSave8 = 0;
    public int dialogSave9 = 0;
    public int dialogSave10 = 0;
    public int dialogSave11 = 0;
    public int dialogSave12 = 0;
    public int dialogSave13 = 0;
    public int dialogSave14 = 0;
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
            dialogSave2 = 1;
        }
        if (dialogSave2 == 1)
        {
            dialogQuest.SetActive(true);
        }

        if (QuestManager.questID == 5)
        {
            dialogSave3 = 1;
        }
        if (dialogSave3 == 1)
        {
            dialogQuest1.SetActive(true);
        }

        if (QuestManager.questID == 6)
        {
            dialogSave4 = 1;
        }
        if (dialogSave4 == 1)
        {
            dialogQuest2.SetActive(true);
        }

        if (QuestManager.questID == 7)
        {
            dialogSave5 = 1;
        }
        if (dialogSave5 == 1)
        {
            dialogQuest3.SetActive(true);
        }

        if (QuestManager.quest8Completion)
        {
            dialogSave6 = 1;
        }
        if (dialogSave6 == 1)
        {
            dialogQuest4.SetActive(true);
        }

        if (QuestManager.quest9Completion)
        {
            dialogSave7 = 1;
        }
        if (dialogSave7 == 1)
        {
            dialogQuest5.SetActive(true);
        }

        if (QuestManager.quest10Completion)
        {
            dialogSave8 = 1;
        }
        if (dialogSave8 == 1)
        {
            dialogQuest6.SetActive(true);
        }

        if (QuestManager.quest11Completion)
        {
            dialogSave9 = 1;
        }
        if (dialogSave9 == 1)
        {
            dialogQuest7.SetActive(true);
        }

        if (QuestManager.questID == 13)
        {
            dialogSave10 = 1;
        }
        if (dialogSave10 == 1)
        {
            dialogQuest8.SetActive(true);
        }

        if (QuestManager.questID == 14)
        {
            dialogSave11 = 1;
        }
        if (dialogSave11 == 1)
        {
            dialogQuest9.SetActive(true);
        }

        if (QuestManager.questID == 15)
        {
            dialogSave12 = 1;
        }
        if (dialogSave12 == 1)
        {
            dialogQuest10.SetActive(true);
        }

        if (QuestManager.questID == 17)
        {
            dialogSave13 = 1;
        }
        if (dialogSave13 == 1)
        {
            dialogQuest11.SetActive(true);
        }

        if (QuestManager.questID == 20)
        {
            dialogSave14 = 1;
        }
        if (dialogSave14 == 1)
        {
            dialogQuest12.SetActive(true);
        }


    }

    public void SaveData(GameData data)
    {
        data.dialogSave1s = dialogSave1;
        data.dialogSave2s = dialogSave2;
        data.dialogSave3s = dialogSave3;
        data.dialogSave4s = dialogSave4;
        data.dialogSave5s = dialogSave5;
        data.dialogSave6s = dialogSave6;
        data.dialogSave7s = dialogSave7;
        data.dialogSave8s = dialogSave8;
        data.dialogSave9s = dialogSave9;
        data.dialogSave10s = dialogSave10;
        data.dialogSave11s = dialogSave11;
        data.dialogSave12s = dialogSave12;
        data.dialogSave13s = dialogSave13;
        data.dialogSave14s = dialogSave14;

    }

    public void LoadData(GameData data)
    {
        dialogSave1 = data.dialogSave1s;
        dialogSave2 = data.dialogSave2s;
        dialogSave3 = data.dialogSave3s;
        dialogSave4 = data.dialogSave4s;
        dialogSave5 = data.dialogSave5s;
        dialogSave6 = data.dialogSave6s;
        dialogSave7 = data.dialogSave7s;
        dialogSave8 = data.dialogSave8s;
        dialogSave9 = data.dialogSave9s;
        dialogSave10 = data.dialogSave10s;
        dialogSave11 = data.dialogSave11s;
        dialogSave12 = data.dialogSave12s;
        dialogSave13 = data.dialogSave13s;
        dialogSave14 = data.dialogSave14s;
    }
}
