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
    public List<GameObject> chackOj = new List<GameObject>();

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
    public void CheckAndCompleteQuest(string objectName)
    {
        if (objectName == "quest101" && QuestManager.quest2)
        {
            // Set quest2Completion to true
            QuestManager.quest2Completion = true;

            // Find the GameObject with the name "quest101" in the list and destroy it
            GameObject questObject = chackOj.Find(obj => obj.name == "quest101");
            if (questObject != null)
            {
                chackOj.Remove(questObject);
                Destroy(questObject);
            }
        }
        else if (objectName == "quest102" && QuestManager.quest4)
        {
            // Set quest2Completion to true
            QuestManager.quest4Completion = true;

            // Find the GameObject with the name "quest101" in the list and destroy it
            GameObject questObject = chackOj.Find(obj => obj.name == "quest102");
            if (questObject != null)
            {
                chackOj.Remove(questObject);
                Destroy(questObject);
            }
        }
        /* else if (objectName == "quest102" && QuestManager.quest3)
         {
             // Set quest3Completion to true
             QuestManager.quest3Completion = true;

             // Find the GameObject with the name "quest102" in the list and destroy it
             GameObject questObject = chackOj.Find(obj => obj.name == "quest102");
             if (questObject != null)
             {
                 chackOj.Remove(questObject);
                 Destroy(questObject);
             }
         }*/
    }
}
   

       
