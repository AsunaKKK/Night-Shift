using UnityEngine;

[CreateAssetMenu(fileName = "New QuestData", menuName = "Quests/Quest Data")]
public class QuestData : ScriptableObject
{
    public int idQuest;
    [field: TextArea]
    public string mainQuest;
    [field: TextArea]
    public string conditions1;
    [field: TextArea]
    public string conditions2;
    [field: TextArea]
    public string conditions3;
}