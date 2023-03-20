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
        if(item == null)
        {
            return;
        }

        switch (item.itemType)
        {
            case Item.ItemType.Hp:
                PlayerController.instance.IncreaseHp(item.hpValue);
                break;
            case Item.ItemType.Energy:
                PlayerController.instance.IncreaseEnergy(item.mpValue);
                break;
            case Item.ItemType.mixHpMp:
                PlayerController.instance.IncreaseMpAndHp(item.hpValue, item.mpValue);
                break;
        }
        RemoveItem();
    }

    

}
