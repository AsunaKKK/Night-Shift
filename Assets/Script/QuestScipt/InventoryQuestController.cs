using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryQuestController : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    ItemQuest items;

    private void Start()
    {
        // Hide the tooltip on start
        SetToolTip(string.Empty);
    }
    public void AddItem(ItemQuest newItem)
    {
        items = newItem;
    }
    private void SetToolTip(string detail)
    {
        InventoryManager.Instance.DrawToolTip(detail);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (items != null && items.detailItem != null)
        {
            SetToolTip(items.detailItem);
            //Debug.Log("Pointer entered the button!");
            // Additional code or actions to perform when the pointer enters the button
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        SetToolTip(string.Empty);
        //Debug.Log("Remove");
    }

    public ItemQuest GetItem()
    {
        return items;
    }
}
