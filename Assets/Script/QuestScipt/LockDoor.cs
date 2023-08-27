using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour , IDataSave
{
    public GameObject doorAll;
    public GameObject buChaDoor;
    
    public static bool key;
    public bool electricFuse;
    public bool talisManpaper1;
    public bool talisManpaper2;
    public bool talisManpaper3;
    public bool talisManpaper4;
    public bool talisManpaper5;
    public int doorOn = 0;


    public int doorAllSave = 0;
    public int buChaDoorSave = 0;
    // Start is called before the first frame update
    void Start()
    {
        doorAll.SetActive(false);
        buChaDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorAll != null)
        {
            doorAll.SetActive(false);
        }

        if (buChaDoor != null)
        {
            buChaDoor.SetActive(false);
        }
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
            if (item.IdItems == 3)
            {
                key = true;
                
            }
            if(item.IdItems == 4)
            {
                electricFuse = true;
            }
            if(item.IdItems == 8)
            {
                talisManpaper1 = true;
            }
            if (item.IdItems == 9)
            {
                talisManpaper2 = true;
            }
            if (item.IdItems == 10)
            {
                talisManpaper3 = true;
            }
            if (item.IdItems == 11)
            {
                talisManpaper4 = true;
            }
            if (item.IdItems == 12)
            {
                talisManpaper5 = true;
                break;
            }

        }
        if (QuestManager.questID == 9 && key == true)
        {
            doorAllSave = 1;
        }
        if(doorAllSave == 1)
        {
            doorAll.SetActive(true);
        }
       
        if (QuestManager.questID == 19)
        {
            buChaDoorSave = 1;
        }
        if(buChaDoorSave == 1)
        {
            buChaDoor.SetActive(true);
        }
    
    }
    public void SaveData(GameData data)
    {
        data.doorAlls = doorAllSave;
        data.buchaDoor = buChaDoorSave;
    }

    public void LoadData(GameData data)
    {
        doorAllSave = data.doorAlls;
        buChaDoorSave = data.buchaDoor;
    }

}
