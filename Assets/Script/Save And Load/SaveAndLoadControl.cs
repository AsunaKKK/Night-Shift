using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadControl : MonoBehaviour
{
    private SaveManager saveManager;
    private PlayerController playerController;
    private InventoryManager inventoryManager;

    private void Start()
    {
        saveManager = GetComponent<SaveManager>();
        playerController = GetComponent<PlayerController>();
        inventoryManager = GetComponent<InventoryManager>();
        Debug.Log("Save Run");
    }

    public void SaveGame()
    {

        PlayerData playerData = new PlayerData();
        // Set the player data fields based on your game logic
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
        PlayerData playerData;
        List<ItemData> itemDataList;

        saveManager.LoadData(out playerData, out itemDataList);

        if (playerData != null)
        {
            // Apply the player data to your game logic
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
        saveManager.DeleteSave();
    }
}
