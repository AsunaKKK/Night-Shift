using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSendQuest : MonoBehaviour
{
    public int checkIDQuest = 0;

    public GameObject[] sendQ;

    private void Update()
    {
        SetIDQuests();
        CheckObj();
    }

    public void SetIDQuests()
    {
        if (QuestManager.completionID == 2)
        {
            checkIDQuest = 1;
        }
        if (QuestManager.completionID == 4)
        {
            checkIDQuest = 2;
        }
        if (QuestManager.completionID == 5)
        {
            checkIDQuest = 3;
        }
        if (QuestManager.completionID == 6)
        {
            checkIDQuest = 4;
        }
        if (QuestManager.completionID == 11)
        {
            checkIDQuest = 5;
        }
        if (QuestManager.completionID == 12)
        {
            checkIDQuest = 6;
        }
        if (QuestManager.completionID == 13)
        {
            checkIDQuest = 7;
        }
        if (QuestManager.completionID == 14)
        {
            checkIDQuest = 8;
        }

    }

    public void CheckObj()
    {
        if(checkIDQuest == 0)
        {
            GameObject DD = sendQ[0];
            DD.SetActive(true);
        }
        if(checkIDQuest == 1)
        {
            GameObject DD =  sendQ[1];
            DD.SetActive(true);
        }
        if (checkIDQuest == 2)
        {
            GameObject DD = sendQ[2];
            DD.SetActive(true);
        }
        if (checkIDQuest == 3)
        {
            GameObject DD = sendQ[3];
            DD.SetActive(true);
        }
        if (checkIDQuest == 4)
        {
            GameObject DD = sendQ[4];
            DD.SetActive(true);

        }
        if (checkIDQuest == 5)
        {
            GameObject DD = sendQ[5];
            DD.SetActive(true);
        }
        if (checkIDQuest == 6)
        {
            GameObject DD = sendQ[6];
            DD.SetActive(true);
        }
        if (checkIDQuest == 7)
        {
            GameObject DD = sendQ[7];
            DD.SetActive(true);
        }
        if (checkIDQuest == 8)
        {
            GameObject DD = sendQ[8];
            DD.SetActive(true);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.chackQuestId = checkIDQuest;
    }

    public void LoadData(GameData data)
    {
        checkIDQuest = data.chackQuestId;
    }
}
