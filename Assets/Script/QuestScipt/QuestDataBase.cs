using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataBase : MonoBehaviour
{
    public static List<Quest> questList = new List<Quest>();

    void Awake()
    {
        questList.Add (new Quest (0,"None", "None", "None", "None"));
        questList.Add(new Quest(1, "ตามหาธูปและเทียนเพื่อกราบไหว้", "None", "None", "None"));
        questList.Add(new Quest(2, "หาประตูทางออก", "None", "None", "None"));
        questList.Add(new Quest(3, "เดียวกลับมาเขียน", "None", "None", "None"));
        questList.Add(new Quest(4, "ยังงงแต่ได้อยู่", "None", "None", "None"));
        questList.Add(new Quest(5, "มาเลยไอน้อง", "None", "None", "None"));
    }
}


