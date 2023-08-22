using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour
{
    public GameObject quest1;
    public GameObject quest2;
    public GameObject quest3;
    public GameObject quest4;
    public GameObject quest5;
    public GameObject quest6;
    public GameObject quest7;
    public GameObject quest8;
    public GameObject quest9;
    
    public GameObject Chacracter0;
    public GameObject Chacracter1;
    public GameObject Chacracter2;
    public GameObject Chacracter3;

    public GameObject Enemy;

    

    //public GameObject quest2;
    public bool itemQuest1 = false;
    public bool itemQuest2 = false;
    public bool itemQuest3 = false;
    public bool itemQuest4 = false;

    //FinalQuest 


    bool foundTuup = false;
    bool foundLightSteel = false;
    bool foundKey = false;
    bool fondElectricfuse = false;
    bool fondFlannel = false;
    bool fondSchoolBag = false;
    bool fondHistoryBook = false;

    public List<GameObject> chackOj = new List<GameObject>();


    // Update is called once per frame

    void Start()
    {
        quest1.SetActive(false);
        quest2.SetActive(false);
        quest3.SetActive(false);
        quest4.SetActive(false);
        quest5.SetActive(false);
        quest6.SetActive(false);
        quest7.SetActive(false);
        quest8.SetActive(false);
        quest9.SetActive(false);




        Enemy.SetActive(false);
    }


    void Update()
    {
        QuestRun();
    }

    public void QuestRun()
    {
        
        //ItemSet
        if (QuestManager.questID == 1)
        {
            quest1.SetActive(true);
        } 
        if(QuestManager.questID == 8)
        {
            quest2.SetActive(true);
        }
        if (QuestManager.questID == 9)
        {
            quest3.SetActive(true);
        }
        if (QuestManager.questID == 16)
        {
            quest4.SetActive(true);
        }
        if (QuestManager.questID == 20)
        {
            quest5.SetActive(true);
        }
        if (QuestManager.questID == 21)
        {
            quest6.SetActive(true);
        }
        if (QuestManager.questID == 22)
        {
            quest7.SetActive(true);
        }
        if (QuestManager.questID == 23)
        {
            quest8.SetActive(true);
        }
        if (QuestManager.questID == 24)
        {
            quest9.SetActive(true);
        }

        //ChaSet
        if (QuestManager.questID == 1)
        {
            Chacracter2.SetActive(true);
        }
        if(QuestManager.questID == 2)
        {
            Chacracter2.SetActive(false);

        }
        if (QuestManager.questID == 7)
        {
            Chacracter0.SetActive(true);
        }
        if (QuestManager.questID == 15)
        {
            Chacracter1.SetActive(true);
        }
        if (QuestManager.questID == 13)
        {
            Chacracter0.SetActive(false);
        }
        if (QuestManager.questID == 16)
        {
            Chacracter1.SetActive(false);
        }
        if (QuestManager.questID == 18)
        {
            Chacracter3.SetActive(true);
        }

        // Enemy
        if (QuestManager.questID == 12)
        {
            Enemy.SetActive(true);
        }



        if (itemQuest1 == true)
        {
            QuestManager.quest1Completion=true;
        }

        if (itemQuest2 == true)
        {
            QuestManager.quest8Completion = true;

        }
        if (itemQuest3 == true)
        {
            QuestManager.quest9Completion = true;
        }
        if (itemQuest4 == true)
        {
            QuestManager.quest16Completion = true;
        }


        ItemRun();
    }

    public void ItemRun()
    {
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
            if (item.itemName == "Incense")
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
            if (item.itemName == "flannel")
            {
                fondFlannel= true;
            }
            if (item.itemName == "Bracelet")
            {
                fondSchoolBag = true;
            }
            if (item.itemName == "history book")
            {
                fondHistoryBook = true;
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
               
            }
            if(fondHistoryBook&&fondSchoolBag&&fondFlannel)
            {
                itemQuest4 = true;
                break;
            }
  
        }
    }

    
}
   

       
