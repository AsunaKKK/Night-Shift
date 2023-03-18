using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;

    public Button UseButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch(item.itemType)
        {
            case Item.ItemType.Hp:
                PlayerController.instance.IncreaseHp(item.value);
                break;
            case Item.ItemType.Energy:
                PlayerController.instance.IncreaseEnergy(item.value);
                break;
            case Item.ItemType.mixEnergy:
                break ;
        }

        RemoveItem();
    }

    /*public void ShowItem()
    {
        RemoveButton.gameObject.SetActive(true);
        UseButton.gameObject.SetActive(true);
    }*/
}
