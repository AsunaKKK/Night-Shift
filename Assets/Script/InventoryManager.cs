using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>(6);

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        if(Items.Count <6)
        Items.Add(item);
        
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("NameItem").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageItem").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }

        SetInventoryItem();
    }

    public void SetInventoryItem()
    {
        inventoryItem = ItemContent.GetComponentInChildren<InventoryItemController[]>();

        for (int i = 0; i < Items.Count; i++)
        {
            inventoryItem[i].AddItem(Items[i]);
        }
    }
}
