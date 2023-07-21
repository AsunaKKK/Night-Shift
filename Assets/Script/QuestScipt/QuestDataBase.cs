using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataBase : MonoBehaviour
{
    public static List<Quest> questList = new List<Quest>();

    public string[] questNames;
  
    public string[] conditions1;
    public string[] conditions2;
    public string[] conditions3;

   
   



    void Awake()
    {
        // Clear the questList before adding new quests to avoid duplicates
        questList.Clear();

        questList.Add(new Quest(0, "None", "None", "None", "None"));
        questList.Add(new Quest(1, questNames[0], conditions1[0], conditions2[0], conditions3[0]));
        questList.Add(new Quest(2, questNames[1], conditions1[1], conditions2[1], conditions3[1]));
        questList.Add(new Quest(3, questNames[2], conditions1[2], conditions2[2], conditions3[2]));
        questList.Add(new Quest(4, questNames[3], conditions1[3], conditions2[3], conditions3[3]));
        questList.Add(new Quest(5, questNames[4], conditions1[4], conditions2[4], conditions3[4]));
        
       
       
    }
}