using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour
{
    public GameObject quest1;
    //public GameObject quest2;
    public bool itemQuest1 = false;
    bool foundTuup = false;
    bool foundLightSteel = false;


    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        QuestRun();
    }

    public void QuestRun()
    {
        if (QuestManager.quest1 == true)
        {
            quest1.SetActive(true);
        }
       

        if (itemQuest1 == true)
        {
            QuestManager.quest1Completion = true;
        }


       
        ItemRun();
    }

    public void ItemRun()
    {
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
            if (item.itemName == "Tuup")
            {
                foundTuup = true;
            }

            if (item.itemName == "light-steel")
            {
                foundLightSteel = true;
            }

            // If both items are found, set itemQuest1 to true and break out of the loop
            if (foundTuup && foundLightSteel)
            {
                itemQuest1 = true;
                break;
            }
        }
    }
}