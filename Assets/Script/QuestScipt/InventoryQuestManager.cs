using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class InventoryQuestManager : MonoBehaviour
{
    public static InventoryQuestManager Instance;
    public List<ItemQuest> ItemsQuest = new List<ItemQuest>(50);
    public Transform ItemContent;
    public GameObject InventoryItemQuest;
    public InventoryQuestController[] inventoryItemsQuest;

    private Tooltip tooltip;

    private void Awake()
    {
        Instance = this;
        tooltip = FindObjectOfType<Tooltip>();
        if (tooltip == null)
        {
            Debug.LogError("Tooltip component not found in the scene.");
        }

    }
    public void Add(ItemQuest itemQ)
    {
        if (ItemsQuest != null)
        {
            if (ItemsQuest.Count < 50)
            {
                ItemsQuest.Add(itemQ);
                Debug.Log("w1");
                ListItemsQuest(); // Call ListItems() to update the inventory UI
            }
        }
    }
    public void Remove(ItemQuest items)
    {
        ItemsQuest.Remove(items);
        ListItemsQuest(); // Call ListItems() to update the inventory UI
    }

    public void ListItemsQuest()
    {
        if (ItemContent == null)
        {
            Debug.LogError("ItemContent is not assigned in the Inspector.");
            return;
        }

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        inventoryItemsQuest = new InventoryQuestController[50];

        for (int i = 0; i < ItemsQuest.Count; i++)
        {
            GameObject obj = Instantiate(InventoryItemQuest, ItemContent);
            var itemName = obj.transform.Find("NameItem").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageItem").GetComponent<Image>();

            itemName.text = ItemsQuest[i].itemName;
            itemIcon.sprite = ItemsQuest[i].icon;

            // Instantiate a new InventoryItemController and add it to the inventoryItems array
            InventoryQuestController newItem = obj.GetComponent<InventoryQuestController>();
            inventoryItemsQuest[i] = newItem;
            inventoryItemsQuest[i].AddItem(ItemsQuest[i]);

            if (i < inventoryItemsQuest.Length)
            {
                inventoryItemsQuest[i] = newItem;
                inventoryItemsQuest[i].AddItem(ItemsQuest[i]);
            }
        }

        // Remove any null elements from the inventoryItems array
        inventoryItemsQuest = inventoryItemsQuest.Where(x => x != null).ToArray();

    }

    public void DrawToolTip(string DetailItem)
    {
        tooltip.setTooltip(DetailItem);
    }
    public void SetInventoryItem()
    {
        inventoryItemsQuest = ItemContent.GetComponentsInChildren<InventoryQuestController>()
       .Where(item => item != null)
       .ToArray();

        for (int i = 0; i < ItemsQuest.Count; i++)
        {
            inventoryItemsQuest[i].AddItem(ItemsQuest[i]);
        }
    }

}
