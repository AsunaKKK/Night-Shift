using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemQuestPicup : MonoBehaviour , IDataSave
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void FenerteGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public ItemQuest item;
    public GameObject itemUse;
    public float pickupDelay = 1f;
    private bool isPickingUp = false;
    private float pickupTimer = 0f;

    private bool isPicUp = false;

    public Image reloadBar;
    public GameObject reloadBarObj;

    private void Start()
    {
        itemUse.SetActive(false);
        reloadBarObj.SetActive(false);
    }

    private void Update()
    {
        if (!isPicUp)
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
                ShowBarReload();
                pickupTimer += Time.deltaTime;
                if (pickupTimer >= pickupDelay)
                {
                    Pickup();
                    pickupTimer = 0f;
                }
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
        Debug.Log(pickupTimer);
    }
}
