using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    //public GameObject door102;
   
   // public static bool key102;
    // Start is called before the first frame update
    void Start()
    {
       // door102.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
           /* if (item.itemName == "Key102")
            {
                key102 = true;
                break;
            }*/

        }
       /* if (QuestManager.quest2 == true && key102 == true)
        {
            door102.SetActive(true);

        }*/

    }
    
}
