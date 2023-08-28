using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour , IDataSave
{
    public TextMeshProUGUI mainQuestTextUI;
    public TextMeshProUGUI condition1TextUI;
    public TextMeshProUGUI condition2TextUI;
    public TextMeshProUGUI condition3TextUI;

    public static bool quest1 = false;
    public static bool quest2 = false;
    public static bool quest3 = false;
    public static bool quest4 = false;
    public static bool quest5 = false;
    public static bool quest6 = false;
    public static bool quest7 = false;
    public static bool quest8 = false;
    public static bool quest9 = false;
    public static bool quest10 = false;
    public static bool quest11 = false;
    public static bool quest12 = false;
    public static bool quest13 = false;
    public static bool quest14 = false;
    public static bool quest15 = false;
    public static bool quest16 = false;
    public static bool quest17 = false;
    public static bool quest18 = false;
    public static bool quest19 = false;
    public static bool quest20 = false;
    public static bool quest21 = false;
    public static bool quest22 = false;
    public static bool quest23 = false;
    public static bool quest24 = false;


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
    public static bool quest22Completion = false;
    public static bool quest23Completion = false;
    public static bool quest24Completion = false;


    // The ID of the new quest task we want to retrieve from the list
    public static int newQuestId = 1;
    public static int questID = 1;
    public static int completionID = 0;

    void Start()
    {
        quest1 = true;
    }
    void Update()
    {
        LoadQuestData();
        RunQuest();
        SetIDQuest();
        SetCompletQuest();

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
        if(newQuestId == 1 && questID == 1 && quest1Completion == true && completionID == 1)
        {
            newQuestId = 2;
            questID = 2;
        }
        if (newQuestId == 2 && questID == 2 && quest2Completion == true && completionID == 2)
        {
            newQuestId = 3;
            questID = 3;
        }
        if (newQuestId == 3 && questID == 3 && quest3Completion == true && completionID == 3)
        {
            newQuestId = 4;
            questID = 4;
        }
        if (newQuestId == 4 && questID == 4 && quest4Completion == true && completionID == 4)
        {
            newQuestId = 5;
            questID = 5;
        }
        if (newQuestId == 5 && questID == 5 && quest5Completion == true && completionID == 5)
        {
            newQuestId = 6;
            questID = 6;
        }
        if (newQuestId == 6 && questID == 6 && quest6Completion == true && completionID == 6)
        {
            newQuestId = 7;
            questID = 7;
        }
        if (newQuestId == 7 && questID == 7 && quest7Completion == true && completionID == 7)
        {
            newQuestId = 8;
            questID = 8;
        }
        if (newQuestId == 8 && questID == 8 && quest8Completion == true && completionID == 8)
        {
            newQuestId = 9;
            questID = 9;
        }
        if (newQuestId == 9 && questID == 9 && quest9Completion == true && completionID == 9)
        {
            newQuestId = 10;
            questID = 10;
        }
        if (newQuestId == 10 && questID == 10 && quest10Completion == true && completionID == 10)
        {
            newQuestId = 11;
            questID = 11;
        }
        if (newQuestId == 11 && questID == 11 && quest11Completion == true && completionID == 11)
        {
            newQuestId = 12;
            questID = 12;
        }
        if (newQuestId == 12 && questID == 12 && quest12Completion == true && completionID == 12)
        {
            newQuestId = 13;
            questID = 13;
        }
        if (newQuestId == 13 && questID == 13 && quest13Completion == true && completionID == 13)
        {
            newQuestId = 14;
            questID = 14;
        }
        if (newQuestId == 14 && questID == 14 && quest14Completion == true && completionID == 14)
        {
            newQuestId = 15;
            questID = 15;
        }
        if (newQuestId == 15 && questID == 15 && quest15Completion == true && completionID == 15)
        {
            newQuestId = 16;
            questID = 16;
        }
        if (newQuestId == 16 && questID == 16 && quest16Completion == true && completionID == 16)
        {
            newQuestId = 17;
            questID = 17;
        }
        if (newQuestId == 17 && questID == 17 && quest17Completion == true && completionID == 17)
        {
            newQuestId = 18;
            questID = 18;
        }
        if (newQuestId == 18 && questID == 18 && quest18Completion == true && completionID == 18)
        {
            newQuestId = 19;
            questID = 19;
        }
        if (newQuestId == 19 && questID == 19 && quest19Completion == true && completionID == 19)
        {
            newQuestId = 20;
            questID = 20;
        }
        if (newQuestId == 20 && questID == 20 && quest20Completion == true && completionID == 20)
        {
            newQuestId = 21;
            questID = 21;
        }
        if (newQuestId == 21 && questID == 21 && quest21Completion == true && completionID == 21)
        {
            newQuestId = 22;
            questID = 22;
        }
        if (newQuestId == 22 && questID == 22 && quest21Completion == true && completionID == 22)
        {
            newQuestId = 23;
            questID = 23;
        }
        if (newQuestId == 23 && questID == 23 && quest21Completion == true && completionID == 23)
        {
            newQuestId = 24;
            questID = 24;
        }
        if (newQuestId == 24 && questID == 24 && quest21Completion == true && completionID == 24)
        {
            newQuestId = 25;
            questID = 25;
        }


    }
    //SetId Quest
    public void SetIDQuest()
    {
        if (questID == 1)
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
        if (questID == 22)
        {
            quest22 = true;
        }
        if (questID == 23)
        {
            quest23 = true;
        }
        if (questID == 24)
        {
            quest24 = true;
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
        if (quest11Completion == true)
        {
            completionID = 11;
        }
        if (quest12Completion ==true)
        {
            completionID = 12;
        }
        if (quest13Completion == true)
        {
          completionID=13;
        }
        if (quest14Completion == true)
        {
            completionID = 14; 
        }
        if (quest15Completion == true)
        {
            completionID = 15;
        }
        if (quest16Completion==true)
        {
           completionID=16;
        }
        if  (quest17Completion == true)
        {
            completionID = 17;
        }
        if (quest18Completion == true)
        {
            completionID = 18;
        }
        if (quest19Completion ==true)
        {
            completionID = 19;
        }
        if (quest20Completion == true)
        {
            completionID = 20;
        }
        if (quest21Completion == true)
        {
            completionID = 21;
        }
        if (quest22Completion == true)
        {
            completionID = 22;
        }
        if (quest23Completion == true)
        {
            completionID = 23;
        }
        if (quest24Completion == true)
        {
            completionID = 24;
        }
    }
    public void SaveData(GameData data)
    {
        data.questID = newQuestId;
        data.setQuestID = questID;
        data.setCompletionID = completionID;
        data.quest1 = quest1;
        data.quest2 = quest2;
        data.quest3 = quest3;
        data.quest4 = quest4;
        data.quest5 = quest5;
        data.quest6 = quest6;
        data.quest7 = quest7;
        data.quest8 = quest8;
        data.quest9 = quest9;
        data.quest10 = quest10;
        data.quest11 = quest11;
        data.quest12 = quest12;
        data.quest13 = quest13;
        data.quest14 = quest14;
        data.quest15 = quest15;
        data.quest16 = quest16;
        data.quest17 = quest17;
        data.quest18 = quest18;
        data.quest19 = quest19;
        data.quest20 = quest20;
        data.quest21 = quest21;
        data.quest22 = quest22;
        data.quest23 = quest23;
        data.quest24 = quest24;

        data.quest1Completion = quest1Completion;
        data.quest2Completion = quest2Completion;
        data.quest3Completion = quest3Completion;
        data.quest4Completion = quest4Completion;
        data.quest5Completion = quest5Completion;
        data.quest6Completion = quest6Completion;
        data.quest7Completion = quest7Completion;
        data.quest8Completion = quest8Completion;
        data.quest9Completion = quest9Completion;
        data.quest10Completion = quest10Completion;
        data.quest11Completion = quest11Completion;
        data.quest12Completion = quest12Completion;
        data.quest13Completion = quest13Completion;
        data.quest14Completion = quest14Completion;
        data.quest15Completion = quest15Completion;
        data.quest16Completion = quest16Completion;
        data.quest17Completion = quest17Completion;
        data.quest18Completion = quest18Completion;
        data.quest19Completion = quest19Completion;
        data.quest20Completion = quest20Completion;
        data.quest21Completion = quest21Completion;
        data.quest22Completion = quest22Completion;
        data.quest23Completion = quest23Completion;
        data.quest24Completion = quest24Completion;

    }

    public void LoadData(GameData data)
    {
        newQuestId = data.questID;
        questID = data.setQuestID;
        completionID = data.setCompletionID;
        quest1 = data.quest1;
        quest2 = data.quest2;
        quest3 = data.quest3;
        quest4 = data.quest4;
        quest5 = data.quest5;
        quest6 = data.quest6;
        quest7 = data.quest7;
        quest8 = data.quest8;
        quest9 = data.quest9;
        quest10 = data.quest10;
        quest11 = data.quest11;
        quest12 = data.quest12;
        quest13 = data.quest13;
        quest14 = data.quest14;
        quest15 = data.quest15;
        quest16 = data.quest16;
        quest17 = data.quest17;
        quest18 = data.quest18;
        quest19 = data.quest19;
        quest20 = data.quest20;
        quest21 = data.quest21;
        quest22 = data.quest22;
        quest23 = data.quest23;
        quest24 = data.quest24;

        quest1Completion = data.quest1Completion;
        quest2Completion = data.quest2Completion;
        quest3Completion = data.quest3Completion;
        quest4Completion = data.quest4Completion;
        quest5Completion = data.quest5Completion;
        quest6Completion = data.quest6Completion;
        quest7Completion = data.quest7Completion;
        quest8Completion = data.quest8Completion;
        quest9Completion = data.quest9Completion;
        quest10Completion = data.quest10Completion;
        quest11Completion = data.quest11Completion;
        quest12Completion = data.quest12Completion;
        quest13Completion = data.quest13Completion;
        quest14Completion = data.quest14Completion;
        quest15Completion = data.quest15Completion;
        quest16Completion = data.quest16Completion;
        quest17Completion = data.quest17Completion;
        quest18Completion = data.quest18Completion;
        quest19Completion = data.quest19Completion;
        quest20Completion = data.quest20Completion;
        quest21Completion = data.quest21Completion;
        quest22Completion = data.quest22Completion;
        quest23Completion = data.quest23Completion;
        quest24Completion = data.quest24Completion;

    }

}
