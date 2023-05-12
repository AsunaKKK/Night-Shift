using UnityEngine;

[CreateAssetMenu(fileName ="New Item" , menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int hpValue;
    public int mpValue;
    public Sprite icon;

    [field: TextArea]
    public string detailItem;

    public ItemType itemType;


    public enum ItemType
    {
        Hp,
        Energy,
        mixHpMp
    }


}
