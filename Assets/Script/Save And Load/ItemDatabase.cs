using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items;

    // Method to retrieve an item based on its name
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.itemName == itemName);
    }
}
