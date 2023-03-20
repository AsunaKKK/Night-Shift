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

    }
    void PickUp()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                PickUp();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            detailUse.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detailUse.SetActive(false);
    }
}
