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




    public static bool quest1Completion;
    public static bool quest2Completion;
    public static bool quest3Completion;
    public static bool quest4Completion;
    public static bool quest5Completion;
    public static bool quest6Completion;
    public static bool quest7Completion;
    public static bool quest8Completion;
    public static bool quest9Completion;
    public static bool quest10Completion;
    public static bool quest11Completion;
    public static bool quest12Completion;
    public static bool quest13Completion;
    public static bool quest14Completion;
    public static bool quest15Completion;
    public static bool quest16Completion;
    public static bool quest17Completion;
    public static bool quest18Completion;
    public static bool quest19Completion;
    public static bool quest20Completion;
    public static bool quest21Completion;

    


    // The ID of the new quest task we want to retrieve from the list
    public int newQuestId = 1;
    int chack;

    void Start()
    {
        // Load and display the new quest task when the game starts

        quest1 = true;
        chack = newQuestId;
      


    }
    void Update()
    {
        LoadQuestData();
        RunQuest();
        ChackQuest();



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
     public void RunQuest()
    {
        if(newQuestId == 1 && quest1 == true&& quest1Completion == true)
        {
            newQuestId = 2;
            quest2 = true;
        }
        if(newQuestId == 2 && quest2 == true&& quest2Completion == true)
        {
            newQuestId = 3;
            quest3 = true;
        }
        if (newQuestId == 3 && quest3 == true && quest3Completion == true)
        {
            newQuestId = 4;
            quest4 = true;
        }
        if (newQuestId == 4 && quest4 == true && quest4Completion == true)
        {
            newQuestId = 5;
            quest5 = true;
        }
        if (newQuestId == 5 && quest5 == true && quest5Completion == true)
        {
            newQuestId = 6;
            quest6 = true;
        }
        if (newQuestId == 6 && quest6 == true && quest6Completion == true)
        {
            newQuestId = 7;
            quest7 = true;
        }
        if (newQuestId == 7 && quest7 == true && quest7Completion == true)
        {
            newQuestId = 8;
            quest8 = true;
        }
        if (newQuestId == 8 && quest8 == true && quest8Completion == true)
        {
            newQuestId = 9;
            quest9 = true;
        }
        if(newQuestId == 9 && quest9 == true && quest9Completion == true)
        {
            newQuestId = 10;
            quest10 = true;
        }
        if (newQuestId == 10 && quest10 == true && quest10Completion == true)
        {
            newQuestId = 11;
            quest11 = true;
        }
        if (newQuestId == 11 && quest11 == true && quest11Completion == true)
        {
            newQuestId = 12;
            quest12 = true;
        }
        if (newQuestId == 12 && quest12 == true && quest12Completion == true)
        {
            newQuestId = 13;
            quest13 = true;
        }
        if (newQuestId == 13 && quest13 == true && quest13Completion == true)
        {
            newQuestId = 14;
            quest14 = true;
        }
        if (newQuestId == 14 && quest14 == true && quest14Completion == true)
        {
            newQuestId = 15;
            quest15 = true;
        }
        if (newQuestId == 15 && quest15 == true && quest15Completion == true)
        {
            newQuestId = 16;
            quest16 = true;
        }
        if (newQuestId == 16 && quest16 == true && quest16Completion == true)
        {
            newQuestId = 17;
            quest17 = true;
        }
        if (newQuestId == 17 && quest17 == true && quest17Completion == true)
        {
            newQuestId = 18;
            quest18 = true;
        }
        if (newQuestId == 18 && quest18== true && quest18Completion == true)
        {
            newQuestId = 19;
            quest19 = true;
        }
        if (newQuestId == 19 && quest19 == true && quest19Completion == true)
        {
            newQuestId =20;
            quest20 = true;
        }
        if (newQuestId == 20 && quest20 == true && quest20Completion == true)
        {
            newQuestId = 21;
            quest21 = true;
        }
    }
    public void ChackQuest()
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
       



    }

    public void SaveData(ref GameData data)
    {
        data.questID = newQuestId;
    }

    public void LoadData(GameData data)
    {
        newQuestId = data.questID;
    }

}
