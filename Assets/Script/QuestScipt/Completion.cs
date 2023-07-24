using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour
{
    public GameObject quest1;
    public GameObject quest2;
    public GameObject quest3;
    
    public GameObject Chacracter0;
    public GameObject Chacracter1;

    //public GameObject quest2;
    public bool itemQuest1 = false;
    public bool itemQuest2 = false;
    public bool itemQuest3 = false;



    bool foundTuup = false;
    bool foundLightSteel = false;
    bool foundKey = false;
    bool fondElectricfuse = false;
    public List<GameObject> chackOj = new List<GameObject>();

    // Update is called once per frame

    void Start()
    {
        quest1.SetActive(false);
        quest2.SetActive(false);
        quest3.SetActive(false);
    }


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
        if(QuestManager.quest8 == true)
        {
            quest2.SetActive(true);
        }
        if (QuestManager.quest9 == true)
        {
            quest3.SetActive(true);
        }



        if (itemQuest1 == true)
        {
            QuestManager.quest1Completion = true;
        }
        if (itemQuest2 == true)
        {
            QuestManager.quest8Completion = true;

        }
        if (itemQuest3 == true)
        {
            QuestManager.quest9Completion = true;
        }


        if (QuestManager.quest7 == true)
        {
            Chacracter0.SetActive(true);
           
        }
        if (QuestManager.quest15 == true)
        {
            Chacracter1.SetActive(true);

        }
        if (QuestManager.quest13 == true)
        {
            Chacracter0.SetActive(false);

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
            if (item.itemName == "Key")
            {
                foundKey = true;
               
            }
            if(item.itemName == "Electric-fuse")
            {
                fondElectricfuse = true;
            }

            // If both items are found, set itemQuest1 to true and break out of the loop
            if (foundTuup && foundLightSteel)
            {
                itemQuest1 = true;

            }
            if(foundKey)
            {
                itemQuest2 = true;
               
            }
            if(fondElectricfuse)
            {
                itemQuest3 = true;
                break;
            }
  
        }
    }
    
}
   

       
