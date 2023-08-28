using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendQuestSave : MonoBehaviour
{
    public GameObject senQuest1;

    public int seveSen1 = 0;
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
    }


    public void SaveData(GameData data)
    {
        data.seveSen1s = seveSen1;
    }

    public void LoadData(GameData data)
    {
        seveSen1 = data.seveSen1s;
    }

}
