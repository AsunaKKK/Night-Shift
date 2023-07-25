using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour , IDataSave
{
    public TextMeshProUGUI mainQuestTextUI;
    public TextMeshProUGUI condition1TextUI;
    public TextMeshProUGUI condition2TextUI;
    public TextMeshProUGUI condition3TextUI;

    public static bool quest1;
    public static bool quest2;
    public static bool quest3;
    public static bool quest4;
    public static bool quest5;
    public static bool quest6;
    public static bool quest7;
    public static bool quest8;
    public static bool quest9;
    public static bool quest10;
    public static bool quest11;
    public static bool quest12;
    public static bool quest13;
    public static bool quest14;
    public static bool quest15;
    public static bool quest16;
    public static bool quest17;
    public static bool quest18;
    public static bool quest19;
    public static bool quest20;
    public static bool quest21;


    public static bool quest1Completion = false;
    public static bool quest2Completion = false;
    public static bool quest3Completion = false;
    public static bool quest4Completion = false;
    public static bool quest5Completion = false;
    public static bool quest6Completion = false;
    public static bool quest7Completion = false;
    public static bool quest8Completion = false;
    public static bool quest9Completion = false;
    public static bool quest10Completion = false;
    public static bool quest11Completion = false;
    public static bool quest12Completion = false;
    public static bool quest13Completion = false;
    public static bool quest14Completion = false;
    public static bool quest15Completion = false;
    public static bool quest16Completion = false;
    public static bool quest17Completion = false;
    public static bool quest18Completion = false;
    public static bool quest19Completion = false;
    public static bool quest20Completion = false;
    public static bool quest21Completion = false;

    // The ID of the new quest task we want to retrieve from the list
    public static int newQuestId = 1;
    public static int questID = 1;
    public static int completionID = 0;
    int chack;

    void Start()
    {
        Debug.Log("new" + newQuestId);
        Debug.Log("qu" + questID);
        Debug.Log("com" + completionID);

    }
    void Update()
    {
        LoadQuestData();
        RunQuest();
        SetIDQuest();
        SetCompletQuest();

        //ChackQuest();
    }

    // Call this method when you want to display the quest information
    public void LoadQuestData()
    {
        Quest questData = GetQuestData(newQuestId);

        if (questData != null)
        {
            // Update the UI elements with quest information
            mainQuestTextUI.text = questData.mainQuest;
            condition1TextUI.text = questData.conditions1;
            condition2TextUI.text = questData.conditions2;
            condition3TextUI.text = questData.conditions3;
        }
        else
        {
            Debug.LogWarning("QuestData not found or failed to load.");
        }
    }

    // Function to retrieve Quest from the QuestDataBase.questList based on quest ID
    private Quest GetQuestData(int questId)
    {
        foreach (Quest quest in QuestDataBase.questList)
        {
            if (quest.idQuest == questId)
            {
                return quest;
            }
        }

        return null;
    }

    //Run Quest
     public void RunQuest()
    {
        if(newQuestId == 1 && questID == 1 && completionID == 1)
        {
            newQuestId = 2;
            questID = 2;
        }
        if (newQuestId == 2 && questID == 2 && quest2Completion == true)
        {
            newQuestId = 3;
            questID = 3;
            Debug.Log("run");
        }
        if (newQuestId == 3 && questID == 3 && quest3Completion == true)
        {
            newQuestId = 4;
            questID = 4;
        }
        if (newQuestId == 4 && questID == 4 && quest4Completion == true)
        {
            newQuestId = 5;
            questID = 5;
        }
        if (newQuestId == 5 && questID == 5 && quest5Completion == true)
        {
            newQuestId = 6;
            questID = 6;
        }
        if (newQuestId == 6 && questID == 6 && quest6Completion == true)
        {
            newQuestId = 7;
            questID = 7;
        }
        if (newQuestId == 7 && questID == 7 && quest7Completion == true)
        {
            newQuestId = 8;
            questID = 8;
        }
        if (newQuestId == 8 && questID == 8 && quest8Completion == true)
        {
            newQuestId = 9;
            questID = 9;
        }
        if (newQuestId == 9 && questID == 9 && quest9Completion == true)
        {
            newQuestId = 10;
            questID = 10;
        }
        if (newQuestId == 10 && questID == 10 && quest10Completion == true)
        {
            newQuestId = 11;
            questID = 11;
        }
        if (newQuestId == 11 && questID == 11 && quest11Completion == true)
        {
            newQuestId = 12;
            questID = 12;
        }
        if (newQuestId == 12 && questID == 12 && quest12Completion == true)
        {
            newQuestId = 13;
            questID = 13;
        }
        if (newQuestId == 13 && questID == 13 && quest13Completion == true)
        {
            newQuestId = 14;
            questID = 14;
        }
        if (newQuestId == 14 && questID == 14 && quest14Completion == true)
        {
            newQuestId = 15;
            questID = 15;
        }
        if (newQuestId == 15 && questID == 15 && quest15Completion == true)
        {
            newQuestId = 16;
            questID = 16;
        }
        if (newQuestId == 16 && questID == 16 && quest16Completion == true)
        {
            newQuestId = 17;
            questID = 17;
        }
        if (newQuestId == 17 && questID == 17 && quest17Completion == true)
        {
            newQuestId = 18;
            questID = 18;
        }
        if (newQuestId == 18 && questID == 18 && quest18Completion == true)
        {
            newQuestId = 19;
            questID = 19;
        }
        if (newQuestId == 19 && questID == 19 && quest19Completion == true)
        {
            newQuestId = 20;
            questID = 20;
        }
        if (newQuestId == 20 && questID == 20 && quest20Completion == true)
        {
            newQuestId = 21;
            questID = 21;
        }
        if (newQuestId == 21 && questID == 21 && quest21Completion == true)
        {
            newQuestId = 22;
            questID = 22;
        }


    }
    /*public void ChackQuest()
    {

        if(newQuestId == 2)
        {
            quest1 = true;
            quest1Completion = true;
        }
         if(newQuestId == 3)
        {
            quest2 = true;
            quest2Completion = true;
        }
         if (newQuestId == 4)
        {
            quest3 = true;
            quest3Completion = true;
        }
         if (newQuestId == 5)
        {
            quest4 = true;
            quest4Completion = true;
        }
         if (newQuestId == 6)
        {
            quest5 = true;
            quest5Completion = true;
        }
         if (newQuestId == 7)
        {
            quest6 = true;
            quest6Completion = true;
        }
         if (newQuestId == 8)
        {
            quest7 = true;
            quest7Completion = true;
        }
         if (newQuestId == 9)
        {
            quest8 = true;
            quest8Completion = true;
        }
         if (newQuestId == 10)
        {
            quest9 = true;
            quest9Completion = true;
        }
         if (newQuestId == 11)
        {
            quest10 = true;
            quest10Completion = true;
        }
         if (newQuestId == 12)
        {
            quest11 = true;
            quest11Completion = true;
        }
         if (newQuestId == 13)
        {
            quest12 = true;
            quest12Completion = true;
        }
         if (newQuestId == 14)
        {
            quest13 = true;
            quest13Completion = true;
        }
         if (newQuestId == 15)
        {
            quest14 = true;
            quest14Completion = true;
        }
         if (newQuestId == 16)
        {
            quest15 = true;
            quest15Completion = true;
        }
         if (newQuestId == 17)
        {
            quest16 = true;
            quest16Completion = true;
        }
        if (newQuestId == 18)
        {
            quest17 = true;
            quest17Completion = true;
        }
         if (newQuestId == 19)
        {
            quest18 = true;
            quest18Completion = true;
        }
         if (newQuestId == 20)
        {
            quest19 = true;
            quest19Completion = true;
        }
         if (newQuestId == 21)
        {
            quest20 = true;
            quest20Completion = true;
        }
       



    }*/

    //SetId Quest
    public void SetIDQuest()
    {
        if(questID == 1)
        {
            quest1 = true;
        }
        if (questID == 2)
        {
            quest2 = true;
        }
        if (questID == 3)
        {
            quest3 = true;
        }
        if (questID == 4)
        {
            quest4 = true;
        }
        if (questID == 5)
        {
            quest5 = true;
        }
        if (questID == 6)
        {
            quest6 = true;
        }
        if (questID == 7)
        {
            quest7 = true;
        }
        if (questID == 8)
        {
            quest8 = true;
        }
        if (questID == 9)
        {
            quest9 = true;
        }
        if (questID == 10)
        {
            quest10 = true;
        }
        if (questID == 11)
        {
            quest11 = true;
        }
        if (questID == 12)
        {
            quest12 = true;
        }
        if (questID == 13)
        {
            quest13 = true;
        }
        if (questID == 14)
        {
            quest14 = true;
        }
        if (questID == 15)
        {
            quest15 = true;
        }
        if (questID == 16)
        {
            quest16 = true;
        }
        if (questID == 17)
        {
            quest17 = true;
        }
        if (questID == 18)
        {
            quest18 = true;
        }
        if (questID == 19)
        {
            quest19 = true;
        }
        if (questID == 20)
        {
            quest20 = true;
        }
        if (questID == 21)
        {
            quest21 = true;
        }
    }

    //Set Completion Quest
    public void SetCompletQuest()
    {
        if(quest1Completion == true)
        {
            completionID = 1;
        }
        if (quest2Completion == true)
        {
            completionID = 2;
        }
        if (quest3Completion == true)
        {
            completionID = 3;
        }
        if (quest4Completion == true)
        {
            completionID = 4;
        }
        if (quest5Completion == true)
        {
            completionID = 5;
        }
        if (quest6Completion == true)
        {
            completionID = 6;
        }
        if (quest7Completion == true)
        {
            completionID = 7;
        }
        if (quest8Completion == true)
        {
            completionID = 8;
        }
        if (quest9Completion == true)
        {
            completionID = 9;
        }
        if (quest10Completion == true)
        {
            completionID = 10;
        }
        if (completionID == 11)
        {
            quest11Completion = true;
        }
        if (completionID == 12)
        {
            quest12Completion = true;
        }
        if (completionID == 13)
        {
            quest13Completion = true;
        }
        if (completionID == 14)
        {
            quest14Completion = true;
        }
        if (completionID == 15)
        {
            quest15Completion = true;
        }
        if (completionID == 16)
        {
            quest16Completion = true;
        }
        if (completionID == 17)
        {
            quest17Completion = true;
        }
        if (completionID == 18)
        {
            quest18Completion = true;
        }
        if (completionID == 19)
        {
            quest19Completion = true;
        }
        if (completionID == 20)
        {
            quest20Completion = true;
        }
        if (completionID == 21)
        {
            quest21Completion = true;
        }
    }
    public void SaveData(ref GameData data)
    {
        data.questID = newQuestId;
        data.setQuestID = questID;
        data.setCompletionID = completionID;
    }

    public void LoadData(GameData data)
    {
        newQuestId = data.questID;
        questID = data.setQuestID;
        completionID = data.setCompletionID;
    }

}
