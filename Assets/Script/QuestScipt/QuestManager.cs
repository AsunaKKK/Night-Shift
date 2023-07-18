using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Text mainQuestTextUI;
    public Text condition1TextUI;
    public Text condition2TextUI;
    public Text condition3TextUI;

    // Call this method when you want to display the quest information
    public void LoadQuestData()
    {
        
        QuestData questData = Resources.Load<QuestData>("Quests/1");

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
            Debug.LogWarning("QuestData asset not found or failed to load.");
        }
    }
}