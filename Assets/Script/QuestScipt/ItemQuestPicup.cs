using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemQuestPicup : MonoBehaviour , IDataSave
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void FenerteGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public ItemQuest item;
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
        reloadBarObj.SetActive(false);
        giftTextBar.SetActive(false);
        checkGift = true;
    }

    private void Update()
    {
        if (!isPicUp)
        {
            if (gameObject.tag == "ItemQuet")
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
                    checkGift = false;
                    Pickup();
                    pickupTimer = 0f;
                }
            }
        }

        if (!checkGift)
        {
            giftTextBar.SetActive(true);
            giftTimer -= Time.deltaTime;
            if (giftTimer == 0)
            {
                giftTimer = 0.5f;
                giftTextBar.SetActive(false);
            }

        }

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

        InventoryQuestManager.Instance.Add(item);
        isPicUp = true;
        SaveManager.instance.SaveGame();
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isPicUp)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.tag = "ItemQuest";

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
            gameObject.tag = "notItem";
        }
    }

    public void LoadData(GameData data)
    {
        data.idItemQuest.TryGetValue(id, out isPicUp);
        if (isPicUp)
        {
            Destroy(gameObject);
        }
    }
    public void SaveData(ref GameData data)
    {
        if (data.idItemQuest.ContainsKey(id))
        {
            data.idItemQuest.Remove(id);
        }
        data.idItemQuest.Add(id, isPicUp);
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
