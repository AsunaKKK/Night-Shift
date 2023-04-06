using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicup : MonoBehaviour
{
    public Item item;

    public GameObject itemUse;
    private float timeCooldown;
    public float maxDelay;
    private float delayCooldown;   


    //public Image reload;
    private void Start()
    {
        itemUse.SetActive(false);
        //reload.gameObject.SetActive(false);
        timeCooldown = maxDelay;
        delayCooldown = maxDelay;

    }
    private void Update()
    {

        if (gameObject.tag == "Item")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp(); 
                //reload.gameObject.SetActive(true);

            }
        }
        //reload.fillAmount = delayCooldown / maxDelay;
    }
    void PickUp()
    {
        if (item == null)
        {
            return;
        }
        if(item != null)
        {
            /*InventoryManager.Instance.Add(item);
            Destroy(gameObject);*/
            StartCoroutine(CooldownPicup());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
        
            gameObject.tag = "Item";
            /*if (gameObject.tag == "Item")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    PickUp();
                    print("e");
                    reload.gameObject.SetActive(true);
                }
           
            }*/
        }
      
    }
    IEnumerator CooldownPicup()
    {
        yield return new WaitForSeconds(timeCooldown);
        //delayCooldown -= Time.deltaTime;
        //reload.gameObject.SetActive(false);
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
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
            gameObject.tag = "notItem";
        }
    }


}
