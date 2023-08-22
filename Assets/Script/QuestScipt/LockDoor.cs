using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
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
            if (item.itemName == "Key")
            {
                key = true;
                
            }
            if(item.itemName == "Electric-fuse")
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
            doorAll.SetActive(true);
        }
       
        if (QuestManager.questID == 19)
        {
            buChaDoor.SetActive(true);
        }
    
    }

}
