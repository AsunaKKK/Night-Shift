using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] inventoryItemss;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        if(Items.Count < 6)
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
            //var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            //var UseItem = obj.transform.Find("UseButton").GetComponent<Button>();
            //var DetailItem = obj.transform.Find("details").GetComponent<Text>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }

        SetInventoryItem();
    }

    public void SetInventoryItem()
    {
        inventoryItemss = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            inventoryItemss[i].AddItem(Items[i]);
        }
    }

    /*public void ShowItem()
    {
        foreach (Transform item in ItemContent)
        {
            item.Find("RemoveButton").gameObject.SetActive(true);
            item.Find("details").gameObject.SetActive(true);
        }
    }*/
}
