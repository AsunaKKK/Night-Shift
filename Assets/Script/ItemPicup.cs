using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicup : MonoBehaviour
{
    public Item item;

    public GameObject detailUse;

    private void Start()
    {
        detailUse.SetActive(false);
    }
    private void Update()
    {
        /*if(Input.GetKey(KeyCode.E))
        {
            PickUp();
        }*/
    }
    void PickUp()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detailUse.SetActive(true);
        if(collision.tag == "Player" )
        {
            detailUse.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                PickUp();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detailUse.SetActive(false);
    }
}
