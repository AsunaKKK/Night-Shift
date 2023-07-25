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
    public GameObject Chacracter2;

    //public GameObject quest2;
    public bool itemQuest1 = false;
    public bool itemQuest2 = false;
    public bool itemQuest3 = false;



    bool foundTuup = false;
    bool foundLightSteel = false;
    bool foundKey = false;
    bool fondElectricfuse = false;
    public List<GameObject> chackOj = new List<GameObject>();

    public int itemOn = 0;


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

    /*public void SetOnObj()
    {
        //Item
        if(itemOn == 1)
        {
            quest1.SetActive(true);
        }
        if (itemOn == 2)
        {
            quest2.SetActive(true);
        }
        if (itemOn == 3)
        {
            quest3.SetActive(true);
        }

        //Character
        if (chacracterOn == 1)
        {
            Chacracter0.SetActive(true);
        }
        if (chacracterOn == 2)
        {
            Chacracter1.SetActive(true);
        }
        if (chacracterOn == 3)
        {
            Chacracter0.SetActive(false);
        }
    }*/



    public void SaveData(ref GameData data)
    {
        data.itemOnQ = itemOn;
    }

    public void LoadData(GameData data)
    {
        itemOn = data.itemOnQ;
    }

}
   

       
