using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public Button removeButton;
    public AudioSource soundUseItem;
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
                soundUseItem.Play();
                break;
            case Item.ItemType.Energy:
                PlayerController.instance.IncreaseEnergy(item.mpValue);
                soundUseItem.Play();
                break;
            case Item.ItemType.mixHpMp:
                PlayerController.instance.IncreaseMpAndHp(item.hpValue, item.mpValue);
                soundUseItem.Play();
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
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        SetToolTip(string.Empty);
    }

    public Item GetItem()
    {
        return item;
    }
}
