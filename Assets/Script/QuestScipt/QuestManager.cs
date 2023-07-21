using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
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
    public static bool quest1Completion;
    public static bool quest2Completion;
    public static bool quest3Completion;
    public static bool quest4Completion;
    public static bool quest5Completion;
   

    // The ID of the new quest task we want to retrieve from the list
    public int newQuestId = 1;

    void Start()
    {
        // Load and display the new quest task when the game starts

        quest1 = true; 
        quest2 = false;
        quest3 = false;
        quest4= false;
        quest5 = false;
        quest1Completion = false;
        quest2Completion = false;
        quest3Completion = false;
        quest4Completion = false;
        quest5Completion = false;



    }
    void Update()
    {
        LoadQuestData();
        RunQuest();



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
        if(quest1 == true&& quest1Completion == true)
        {
            newQuestId = 2;
            quest2 = true;
        }
        if(quest2 == true&& quest2Completion == true)
        {
            newQuestId = 3;
            quest3 = true;
        }
        if (quest3 == true && quest3Completion == true)
        {
            newQuestId = 4;
            quest4 = true;
        }
        if (quest4 == true && quest4Completion == true)
        {
            newQuestId = 5;
            quest5 = true;
        }
    }

    public void MisstionCompletion()
    {

    }
}
