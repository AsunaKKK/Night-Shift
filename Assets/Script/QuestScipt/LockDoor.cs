using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour , IDataSave
{
    public GameObject doorAll;
    public GameObject buChaDoor;
    
    public bool key = false;
    public bool electricFuse;
    public bool talisManpaper1;
    public bool talisManpaper2;
    public bool talisManpaper3;
    public bool talisManpaper4;
    public bool talisManpaper5;
    public int doorOn = 0;


    public int doorAllSave = 0;
    public int buChaDoorSave = 0;

    //Save Elec
    public int electriFuseSave = 0;

    //SavetalisManpaper
    public int talisManpaper1Save = 0;
    public int talisManpaper2Save = 0;
    public int talisManpaper3Save = 0;
    public int talisManpaper4Save = 0;
    public int talisManpaper5Save = 0;

    // Start is called before the first frame update
    void Start()
    {
        doorAll.SetActive(false);
        buChaDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
            if (item.IdItems == 3)
            {
                key = true;
            }

            if(item.IdItems == 4)
            {
                electriFuseSave = 1;
            }
            if(electriFuseSave == 1)
            {
                electricFuse = true;
            }

            if(item.IdItems == 8)
            {
                talisManpaper1Save = 1;
            }
            if(talisManpaper1Save == 1)
            {
                talisManpaper1 = true;
            }
            if (item.IdItems == 9)
            {
                talisManpaper2Save = 1;
            }
            if (talisManpaper2Save == 1)
            {
                talisManpaper2 = true;
            }
            if (item.IdItems == 10)
            {
                talisManpaper3Save = 1;
            }
            if (talisManpaper3Save == 1)
            {
                talisManpaper3 = true;
            }
            if (item.IdItems == 11)
            {
                talisManpaper4Save = 1;
            }
            if (talisManpaper4Save == 1)
            {
                talisManpaper4 = true;
            }
            if (item.IdItems == 12)
            {
                talisManpaper5Save = 1;
            }
            if (talisManpaper5Save == 1)
            {
                talisManpaper5 = true;
                break;
            }

        }
        if (QuestManager.questID == 8 && key == true)
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
        data.electriFuseSave = electriFuseSave;
        data.talisManpaper1Save = talisManpaper1Save;
        data.talisManpaper2Save = talisManpaper2Save;
        data.talisManpaper3Save = talisManpaper3Save;
        data.talisManpaper4Save = talisManpaper4Save;
        data.talisManpaper5Save = talisManpaper5Save;
    }

    public void LoadData(GameData data)
    {
        doorAllSave = data.doorAlls;
        buChaDoorSave = data.buchaDoor;
        electriFuseSave = data.electriFuseSave;
        talisManpaper1Save= data.talisManpaper1Save;
        talisManpaper2Save = data.talisManpaper2Save;
        talisManpaper3Save= data.talisManpaper3Save;
        talisManpaper4Save= data.talisManpaper4Save;
        talisManpaper5Save= data.talisManpaper5Save;
    }

}
