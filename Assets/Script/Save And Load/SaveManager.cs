using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public  class SaveManager : MonoBehaviour
{

    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "savedata.json");
        Debug.Log(Application.persistentDataPath);
    }

    public void SaveData(PlayerData playerData, List<ItemData> itemDataList)
    {
        if (playerData == null)
        {
            return;
        }
        Debug.Log("KK");
        SaveData saveData = new SaveData();
        saveData.playerData = playerData;
        saveData.itemDataList = itemDataList;

        string json = JsonConvert.SerializeObject(saveData);
        File.WriteAllText(savePath, json);
    }

    public void LoadData(out PlayerData playerData, out List<ItemData> itemDataList)
    {
        playerData = null;
        itemDataList = null;

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

            playerData = saveData.playerData;
            itemDataList = saveData.itemDataList;
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }

    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }
}
