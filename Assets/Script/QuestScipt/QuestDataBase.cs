using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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
        questList.Add(new Quest(6, questNames[5], conditions1[5], conditions2[5], conditions3[5]));
        questList.Add(new Quest(7, questNames[6], conditions1[6], conditions2[6], conditions3[6]));
        questList.Add(new Quest(8, questNames[7], conditions1[7], conditions2[7], conditions3[7]));
        questList.Add(new Quest(9, questNames[8], conditions1[8], conditions2[8], conditions3[8]));
        questList.Add(new Quest(10, questNames[9], conditions1[9], conditions2[9], conditions3[9]));

    }

    /*public void SaveData(ref GameData data)
    {
        data.questData = questList.ToList();
        data.questNamedata = questNames.ToArray();
    }

    public void LoadData(GameData data)
    {
        questList = new List<Quest>(data.questData);
        questNames = data.questNamedata.ToList().ToArray();
    }*/
}