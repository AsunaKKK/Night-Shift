using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSaveAndLoad : MonoBehaviour
{
   public void OnClickSaveGame()
    {
        SaveManager.instance.SaveGame();
    }

    public void OnClickLoadGame()
    {
        SaveManager.instance.LoadGame();
    }
}
