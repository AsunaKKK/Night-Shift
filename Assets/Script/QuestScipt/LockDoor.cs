using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public GameObject doorAll;
    
    public static bool key;
    public bool electricFuse;
    public int doorOn = 0;
    // Start is called before the first frame update
    void Start()
    {
        doorAll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
            if (item.itemName == "Key")
            {
                key = true;
                
            }
            if(item.itemName == "Electric-fuse")
            {
                electricFuse = true;
                
                break;
            }

        }
        if (QuestManager.questID == 9 && key == true)
        {
            doorOn = 1;
        }
        if (doorOn == 1)
        {
            doorAll.SetActive(true);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.doorOnQ = doorOn;
    }

    public void LoadData(GameData data)
    {
        doorOn = data.doorOnQ;
    }

}
