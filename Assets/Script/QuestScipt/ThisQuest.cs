using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisQuest : MonoBehaviour
{
    public List<Quest> thisQuest = new List<Quest>();
    public int thisId;

    public Text mainQuestText;
    public Text conditionText1;
    public Text conditionText2;
    public Text conditionText3;
    public Text questStatusText;

    // Start is called before the first frame update
    void Start()
    {
        thisQuest.Add(new Quest()); 
        thisQuest[0] = QuestDataBase.questList[thisId];
        UpdateQuestUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the quest status based on conditions (you need to implement this logic)
        if (AreQuestConditionsMet(thisQuest[0]))
        {
            thisQuest[0].isCompleted = true;
        }

        UpdateQuestUI();
    }

   
    private bool AreQuestConditionsMet(Quest quest)
    {
        return false; 
    }

    private void UpdateQuestUI()
    {
        mainQuestText.text = thisQuest[0].mainQuest;
        conditionText1.text = thisQuest[0].conditions1;
        conditionText2.text = thisQuest[0].conditions2;
        conditionText3.text = thisQuest[0].conditions3;

        if (thisQuest[0].isCompleted)
        {
            questStatusText.text = "ภารกิจสำเร็จ";
        }
        else
        {
            questStatusText.text = "ดำเนินการ";
        }
    }
}