using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>(4);
    public Transform ItemContent;
    public GameObject InventoryItem;
    public InventoryItemController[] inventoryItems;

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
    public void Add(Item item)
    {
        if (Items != null)
        {
            if (Items.Count < 4)
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
        inventoryItems = new InventoryItemController[4];

        for (int i = 0; i < Items.Count; i++)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("NameItem").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageItem").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = Items[i].itemName;
            itemIcon.sprite = Items[i].icon;
            removeButton.gameObject.SetActive(true);

            // Instantiate a new InventoryItemController and add it to the inventoryItems array
            InventoryItemController newItem = obj.GetComponent<InventoryItemController>();
            inventoryItems[i] = newItem;
            inventoryItems[i].AddItem(Items[i]);

        }
        // Remove any null elements from the inventoryItems array
        inventoryItems = inventoryItems.Where(x => x != null).ToArray();
    }

    public void DrawToolTip(string DetailItem)
    {
        tooltip.setTooltip(DetailItem);
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
    public void SaveData(GameData data )
    {
        data.inventoryItems = Items.ToArray().ToList();
    }

    public void LoadData(GameData data )
    {
        Items = new List<Item>(data.inventoryItems);
        ListItems();
    }


}