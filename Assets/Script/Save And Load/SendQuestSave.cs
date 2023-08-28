using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendQuestSave : MonoBehaviour
{
    public GameObject senQuest1;
    public GameObject senQuest2;
    public GameObject senQuest3;
    public GameObject senQuest4;
    public GameObject senQuest5;
    public GameObject senQuest6;
    public GameObject senQuest7;
    public GameObject senQuest8;
    public GameObject senQuest9;
    public GameObject senQuest10;

    public int seveSen1 = 0;
    public int seveSen2 = 0;
    public int seveSen3 = 0;
    public int seveSen4 = 0;
    public int seveSen5 = 0;
    public int seveSen6 = 0;
    public int seveSen7 = 0;
    public int seveSen8 = 0;
    public int seveSen9 = 0;
    public int seveSen10 = 0;
    // Update is called once per frame
    void Update()
    {
        if(QuestManager.quest2Completion == true)
        {
            seveSen1 = 1;
        }
        if(seveSen1 == 1)
        {
            senQuest1.SetActive(false);
        }
        if (QuestManager.quest4Completion == true)
        {
            seveSen2 = 1;
        }
        if (seveSen2 == 1)
        {
            senQuest2.SetActive(false);
        }
        if (QuestManager.quest5Completion == true)
        {
            seveSen3 = 1;
        }
        if (seveSen3 == 1)
        {
            senQuest3.SetActive(false);
        }
        if (QuestManager.quest6Completion == true)
        {
            seveSen4 = 1;
        }
        if (seveSen4 == 1)
        {
            senQuest4.SetActive(false);
        }
        if (QuestManager.quest11Completion == true)
        {
            seveSen5 = 1;
        }
        if (seveSen5 == 1)
        {
            senQuest5.SetActive(false);
        }
        if (QuestManager.quest12Completion == true)
        {
            seveSen6 = 1;
        }
        if (seveSen6 == 1)
        {
            senQuest6.SetActive(false);
        }
        if (QuestManager.quest13Completion == true)
        {
            seveSen7 = 1;
        }
        if (seveSen7 == 1)
        {
            senQuest7.SetActive(false);
        }
        if (QuestManager.quest14Completion == true)
        {
            seveSen8 = 1;
        }
        if (seveSen8 == 1)
        {
            senQuest8.SetActive(false);
        }
        if (QuestManager.quest17Completion == true)
        {
            seveSen9 = 1;
        }
        if (seveSen9 == 1)
        {
            senQuest9.SetActive(false);
        }
        if (QuestManager.quest19Completion == true)
        {
            seveSen10 = 1;
        }
        if (seveSen10 == 1)
        {
            senQuest10.SetActive(false);
        }
    }


    public void SaveData(GameData data)
    {
        data.seveSen1s = seveSen1;
        data.seveSen2s = seveSen2;
        data.seveSen3s = seveSen3;
        data.seveSen4s = seveSen4;
        data.seveSen5s = seveSen5;
        data.seveSen6s = seveSen6;
        data.seveSen7s = seveSen7;
        data.seveSen8s = seveSen8;
        data.seveSen9s = seveSen9;
        data.seveSen10s = seveSen10;
    }

    public void LoadData(GameData data)
    {
        seveSen1 = data.seveSen1s;
        seveSen2 = data.seveSen2s;
        seveSen3 = data.seveSen3s;
        seveSen4 = data.seveSen4s;
        seveSen5 = data.seveSen5s;
        seveSen6 = data.seveSen6s;
        seveSen7 = data.seveSen7s;
        seveSen8 = data.seveSen8s;
        seveSen9 = data.seveSen9s;
        seveSen10 = data.seveSen10s;
    }

}
