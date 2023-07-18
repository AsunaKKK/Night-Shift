using UnityEngine;

[CreateAssetMenu(fileName = "New ItemQuest", menuName = "ItemQuest/Create New ItemQuest")]
public class ItemQuest : ScriptableObject
{
    public string itemName;
    public int IdItems;
   
    public Sprite icon;

    [field: TextArea]
    public string detailItem;

    


}