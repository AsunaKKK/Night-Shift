using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSaveAndLoad : MonoBehaviour
{
   public void OnClickSaveGame()
    {
        if (SaveManager.instance.HasGameData())
        {
            SaveManager.instance.SaveGame();
            Debug.Log("Save Game");
        }
        else
        {
            Debug.LogWarning("No GameData object found. Create a new game before saving.");
        }
    }
}
