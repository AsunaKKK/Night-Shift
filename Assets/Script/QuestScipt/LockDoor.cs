using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public GameObject doorAll;
    
    public static bool key;
    public bool electricFuse;
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
         if (QuestManager.quest9 == true && key == true)
         {
             doorAll.SetActive(true);

         }
     

    }
   
}
