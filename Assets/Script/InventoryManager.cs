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

    public InventoryItemController[] inventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        if(Items != null)
        {
            if (Items.Count < 3)
            {
                Items.Add(item);
            }
        }
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

            var frameItem = obj.transform.Find("FrameItem").GetComponent<Image>();
            var itemName = obj.transform.Find("NameItem").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageItem").GetComponent<Image>();
            var DetailItem = obj.transform.Find("DetailItem").GetComponent<Text>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var UseItem = obj.transform.Find("UseButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            DetailItem.text = item.detailItem;
            removeButton.gameObject.SetActive(true);
            UseItem.gameObject.SetActive(true);

        }

        SetInventoryItem();
    }
    public void SetInventoryItem()
    {
        inventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i< Items.Count; i++)
        {
            inventoryItems[i].AddItem(Items[i]);
        }
    }


}
