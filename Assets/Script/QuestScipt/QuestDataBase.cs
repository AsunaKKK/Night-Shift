using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataBase : MonoBehaviour
{
    public static List<Quest> questList = new List<Quest>();

    void Awake()
    {
        questList.Add (new Quest (0,"None", "None", "None", "None"));
        questList.Add(new Quest(1, "����Ҹٻ�����¹���͡�Һ����", "None", "None", "None"));
        questList.Add(new Quest(2, "�һ�еٷҧ�͡", "None", "None", "None"));
        questList.Add(new Quest(3, "���ǡ�Ѻ����¹", "None", "None", "None"));
        questList.Add(new Quest(4, "�ѧ����������", "None", "None", "None"));
        questList.Add(new Quest(5, "������͹�ͧ", "None", "None", "None"));
    }
}


