using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadControl : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;

    private PlayerController playerController;
    private InventoryManager inventoryManager;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        inventoryManager = GetComponent<InventoryManager>();

        // Find the SaveManager script in the scene
        saveManager = FindObjectOfType<SaveManager>();

        if (saveManager == null)
        {
            Debug.LogError("SaveManager script not found in the scene. Make sure it is attached to a GameObject.");
        }
        else
        {
            Debug.Log("SaveManager script found.");
        }
    }

    public void SaveGame()
    {
        if (saveManager == null)
        {
            Debug.LogError("SaveManager script not found. Make sure it is attached to a GameObject.");
            return;
        }

        PlayerData playerData = new PlayerData();
        playerData.currentHp = playerController.currenHp;
        playerData.currentEnergy = playerController.currenEnergy;
        playerData.positionX = playerController.transform.position.x;
        playerData.positionY = playerController.transform.position.y;
        playerData.positionZ = playerController.transform.position.z;

        List<ItemData> itemDataList = new List<ItemData>();
        foreach (Item item in inventoryManager.Items)
        {
            ItemData itemData = new ItemData(item.itemName, item.quantity);
            itemDataList.Add(itemData);
        }

        saveManager.SaveData(playerData, itemDataList);
    }

    public void LoadGame()
    {
        if (saveManager == null)
        {
            Debug.LogError("SaveManager script not found. Make sure it is attached to a GameObject.");
            return;
        }

        PlayerData playerData;
        List<ItemData> itemDataList;

        saveManager.LoadData(out playerData, out itemDataList);

        if (playerData != null)
        {
            playerController.currenHp = playerData.currentHp;
            playerController.currenEnergy = playerData.currentEnergy;
            Vector3 playerPosition = new Vector3(playerData.positionX, playerData.positionY, playerData.positionZ);
            playerController.transform.position = playerPosition;
        }

        if (itemDataList != null)
        {
            inventoryManager.ClearItems();

            foreach (ItemData itemData in itemDataList)
            {
                Item item = new Item();
                item.itemName = itemData.itemName;
                item.quantity = itemData.quantity;
                inventoryManager.Add(item);
            }
        }
    }

    public void DeleteSave()
    {
        if (saveManager == null)
        {
            Debug.LogError("SaveManager script not found. Make sure it is attached to a GameObject.");
            return;
        }

        saveManager.DeleteSave();
    }
}
