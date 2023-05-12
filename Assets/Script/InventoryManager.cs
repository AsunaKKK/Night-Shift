using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>(3);
    public Transform ItemContent;
    public GameObject InventoryItem;
    public InventoryItemController[] inventoryItems;


    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item item)
    {
        if (Items != null)
        {
            if (Items.Count < 3)
            {
                Items.Add(item);
                Debug.Log("w1");
                ListItems(); // Call ListItems() to update the inventory UI
            }
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems(); // Call ListItems() to update the inventory UI
    }
    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        inventoryItems = new InventoryItemController[3];

        for (int i = 0; i < Items.Count; i++)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var frameItem = obj.transform.Find("FrameItem").GetComponent<Image>();
            var itemName = obj.transform.Find("NameItem").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageItem").GetComponent<Image>();
            var DetailItem = obj.transform.Find("DetailItem").GetComponent<Text>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var UseItem = obj.transform.Find("UseButton").GetComponent<Button>();

            itemName.text = Items[i].itemName;
            itemIcon.sprite = Items[i].icon;
            DetailItem.text = Items[i].detailItem;
            removeButton.gameObject.SetActive(true);
            UseItem.gameObject.SetActive(true);

            // Instantiate a new InventoryItemController and add it to the inventoryItems array
            InventoryItemController newItem = obj.GetComponent<InventoryItemController>();
            inventoryItems[i] = newItem;
            inventoryItems[i].AddItem(Items[i]);

        }
        // Remove any null elements from the inventoryItems array
        inventoryItems = inventoryItems.Where(x => x != null).ToArray();


       
    }


    public void SetInventoryItem()
    {
    inventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>()
        .Where(item => item != null)
        .ToArray();

    for (int i = 0; i < Items.Count; i++)
    {
        inventoryItems[i].AddItem(Items[i]);
    }
}

}