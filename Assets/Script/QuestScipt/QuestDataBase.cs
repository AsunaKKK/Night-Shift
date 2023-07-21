using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataBase : MonoBehaviour
{
    public static List<Quest> questList = new List<Quest>();

    [Header("Quest1")]
    public string questName1;
    public string condition11;
    public string condition12;
    
    [Header("Quest2")]
    public string questName2;
    public string condition21;
    public string condition22;



    void Awake()
    {
        // Clear the questList before adding new quests to avoid duplicates
        questList.Clear();

        questList.Add(new Quest(0, "None", "None", "None", "None"));
        questList.Add(new Quest(1, questName1, condition11, condition12, ""));
        questList.Add(new Quest(2, questName2, "None", "None", "None" ));
        questList.Add(new Quest(3, "เดียวกลับมาเขียน", "None", "None", "None"));
        questList.Add(new Quest(4, "ยังงงแต่ได้อยู่", "None", "None", "None"));
        questList.Add(new Quest(5, "มาเลยไอน้อง", "None", "None", "None"));
       
        questList.Add(new Quest(6, "New Quest Task", "Condition 1", "Condition 2", "Condition 3"));
    }
}