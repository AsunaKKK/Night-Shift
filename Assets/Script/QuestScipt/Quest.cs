using System;

[System.Serializable]
public class Quest
{
    public int idQuest;
    public string mainQuest;
    public string conditions1;
    public string conditions2;
    public string conditions3;
   

    public bool isCompleted;

    public Quest()
    {
        isCompleted = false;
    }

    public Quest(int IdQuest, string MainQuest, string Condition1, string Condition2, string Condition3)
    {
        idQuest = IdQuest;
        mainQuest = MainQuest;
        conditions1 = Condition1;
        conditions2 = Condition2;
        conditions3 = Condition3;
       
        isCompleted = false;
    }
}