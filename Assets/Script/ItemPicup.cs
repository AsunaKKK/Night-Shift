using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPicup : MonoBehaviour, IDataSave
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void FenerteGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public Item item;
    public GameObject itemUse;
    public float pickupDelay = 1f;
    private bool isPickingUp = false; 
    private float pickupTimer = 0f;

    private bool isPicUp = false;

    public Image reloadBar;
    public GameObject reloadBarObj;
    public GameObject giftTextBar;
    public TextMeshProUGUI textgift;
    public float giftTimer = 0.5f;
    public bool checkGift = false;


    private void Start()
    {
        itemUse.SetActive(false);
        reloadBarObj.SetActive(false);
        giftTextBar.SetActive(false);
        checkGift = true;
    }

    private void Update()
    {
        if(!isPicUp)
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
        }

        if (!isPicUp)
        {
            if (isPickingUp)
            {
                TextGift();
                ShowBarReload();
                pickupTimer += Time.deltaTime;
                if (pickupTimer >= pickupDelay)
                {
                    Pickup();
                    checkGift = false;
                    pickupTimer = 0f;
                    ShowBarReload();
                    
                }
            }
        }

        if(!checkGift)
        {
            giftTextBar.SetActive(true);
            giftTimer -= Time.deltaTime;
            if(giftTimer == 0)
            {
                giftTimer = 0.5f;
                giftTextBar.SetActive(false);
            }
            
        }
        /*if(checkGift)
        {
            giftTextBar.SetActive(false);
        }*/
        //ShowBarReload();
    }
    void StartPickup()
    {
        isPickingUp = true;
        reloadBarObj.SetActive(true);
        
    }

    void StopPickup()
    {
        isPickingUp = false;
        pickupTimer = 0f;
        reloadBarObj.SetActive(false);
    }

    void Pickup()
    {
        if (item == null)
        {
            return;
        }

        InventoryManager.Instance.Add(item);
        isPicUp = true;
        SaveManager.instance.SaveGame();
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!isPicUp)
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

    public void LoadData(GameData data)
    {
        data.idItem.TryGetValue(id, out isPicUp);
        if (isPicUp)
        {
            Destroy(gameObject);
        }
    }
    public void SaveData(GameData data)
    {
        /*if(data.idItem.ContainsKey(id))
        {
            data.idItem.Remove(id);
        }
        data.idItem.Add(id,isPicUp);*/
        if (data == null)
        {
            Debug.LogWarning("Data is null. Cannot save the item state.");
            return;
        }
        if (data.idItem.ContainsKey(id))
        {
            data.idItem.Remove(id);
        }

        data.idItem.Add(id, isPicUp);
    }

    public void ShowBarReload()
    {
        reloadBar.fillAmount = pickupTimer;
    }
    public void TextGift()
    {
        textgift.text = item.itemName;
    }
}
