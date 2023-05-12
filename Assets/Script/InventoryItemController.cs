using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour , IPointerEnterHandler
{
    public Button removeButton;
    public Button useButton;
    Item item;
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
        if (item == null)
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
            default:
                break;
        }
        RemoveItem();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered the button!");
        // Additional code or actions to perform when the pointer enters the button
    }
}
