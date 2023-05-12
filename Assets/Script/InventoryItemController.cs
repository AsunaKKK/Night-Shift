using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public Button removeButton;
    Item item;
    private void Start()
    {
        // Hide the tooltip on start
        SetToolTip(string.Empty);
    }
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
        SetToolTip(string.Empty);
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
        SetToolTip(string.Empty);
    }

    private void SetToolTip(string detail)
    {
        InventoryManager.Instance.DrawToolTip(detail);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null && item.detailItem != null)
        {
            SetToolTip(item.detailItem);
            //Debug.Log("Pointer entered the button!");
            // Additional code or actions to perform when the pointer enters the button
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        SetToolTip(string.Empty);
        //Debug.Log("Remove");
    }
}
