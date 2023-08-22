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
        questList.Add(new Quest(11, questNames[10], conditions1[10], conditions2[10], conditions3[10]));
        questList.Add(new Quest(12, questNames[11], conditions1[11], conditions2[11], conditions3[11]));
        questList.Add(new Quest(13, questNames[12], conditions1[12], conditions2[12], conditions3[12]));
        questList.Add(new Quest(14, questNames[13], conditions1[13], conditions2[13], conditions3[13]));
        questList.Add(new Quest(15, questNames[14], conditions1[14], conditions2[14], conditions3[14]));
        questList.Add(new Quest(16, questNames[15], conditions1[15], conditions2[15], conditions3[15]));
        questList.Add(new Quest(17, questNames[16], conditions1[16], conditions2[16], conditions3[16]));
        questList.Add(new Quest(18, questNames[17], conditions1[17], conditions2[17], conditions3[17]));
        questList.Add(new Quest(19, questNames[18], conditions1[18], conditions2[18], conditions3[18]));
        questList.Add(new Quest(20, questNames[19], conditions1[19], conditions2[19], conditions3[19]));
        questList.Add(new Quest(21, questNames[20], conditions1[20], conditions2[20], conditions3[20]));
        questList.Add(new Quest(22, questNames[21], conditions1[21], conditions2[21], conditions3[21]));
        questList.Add(new Quest(23, questNames[22], conditions1[22], conditions2[22], conditions3[22]));
        questList.Add(new Quest(24, questNames[23], conditions1[23], conditions2[23], conditions3[23]));
        questList.Add(new Quest(25, questNames[24], conditions1[24], conditions2[24], conditions3[24]));




    }
}