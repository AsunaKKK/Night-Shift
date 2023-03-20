using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicup : MonoBehaviour
{
    public Item item;

    public GameObject itemUse;

    private void Start()
    {
        itemUse.SetActive(false);
    }
    private void Update()
    {

    }
    void PickUp()
    {
        if (item == null)
        {
            return;
        }
        if(item != null)
        {
            InventoryManager.Instance.Add(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                PickUp();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            itemUse.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            itemUse.SetActive(false);
        }
    }
}
