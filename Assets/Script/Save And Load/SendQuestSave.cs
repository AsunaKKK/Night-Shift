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

}
