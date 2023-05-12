using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicup : MonoBehaviour
{
    public Item item;
    public GameObject itemUse;
    public float pickupDelay = 1f;
    private bool isPickingUp = false; 
    private float pickupTimer = 0f;

    private void Start()
    {
        itemUse.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.tag == "Item")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartPickup();
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                StopPickup();
            }
        }

        if (isPickingUp)
        {
            pickupTimer += Time.deltaTime;
            if (pickupTimer >= pickupDelay)
            {
                Pickup();
                pickupTimer = 0f;
            }
        }
    }

    void StartPickup()
    {
        isPickingUp = true;
    }

    void StopPickup()
    {
        isPickingUp = false;
        pickupTimer = 0f;
    }

    void Pickup()
    {
        if (item == null)
        {
            return;
        }

        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.tag = "Item";
            itemUse.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                StartPickup();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopPickup();
            itemUse.SetActive(false);
            gameObject.tag = "notItem";
        }
    }
}
