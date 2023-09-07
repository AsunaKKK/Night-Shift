using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour , IDataSave
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

    public GameObject PlayerCutSecne;
    

    //public GameObject quest2;
    public bool itemQuest1 = false;
    public bool itemQuest2 = false;
    public bool itemQuest3 = false;
    public bool itemQuest4 = false;

    //FinalQuest 
   public bool foundTuup = false;
   public bool foundLightSteel = false;
   public bool foundKey = false;
   public bool fondElectricfuse = false;
   public bool fondFlannel = false;
   public bool fondSchoolBag = false;
   public bool fondHistoryBook = false;
    public List<GameObject> chackOj = new List<GameObject>();
    //Save
    public int saveItem1 = 0;
    public int saveItem2 = 0;
    public int saveItem3 = 0;
    public int saveItem4 = 0;
    public int saveItem5 = 0;
    public int saveItem6 = 0;
    public int saveItem7 = 0;
    public int saaveEnemy = 0;
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
        PlayerCutSecne.SetActive(false);



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
            saaveEnemy = 1;
        }
        if(saaveEnemy == 1)
        {
            Enemy.SetActive(true);
        }
        //Animation
        if(QuestManager.questID == 11)
        {
            PlayerCutSecne.SetActive(true);
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


        if(Enemy_Controller.isChasingPlayer == false&&Enemy_Controller.chackQuest12)
        {
            QuestManager.quest12Completion = true;
        }
    }

    public void ItemRun()
    {
        foreach (ItemQuest item in InventoryQuestManager.Instance.ItemsQuest)
        {
            if (item.IdItems == 1)
            {
                saveItem1 = 1;
            }
            if(saveItem1 == 1)
            {
                foundTuup = true;
            }

            if (item.IdItems == 2)
            {
                saveItem2 = 1;
            }
            if (saveItem2 == 1)
            {
                foundLightSteel = true;
            }

            if (item.IdItems == 3)
            {
                saveItem3 = 1;
               
            }
            if (saveItem3 == 1)
            {
                foundKey = true;
            }

            if (item.IdItems == 4)
            {
                saveItem4 = 1;
            }
            if (saveItem4 == 1)
            {
                fondElectricfuse = true;
            }

            if (item.IdItems == 5)
            {
                saveItem5 = 1;
            }
            if (saveItem5 == 1)
            {
                fondFlannel = true;
            }

            if (item.IdItems == 6)
            {
                saveItem6 = 1;
            }
            if (saveItem6 == 1)
            {
                fondSchoolBag = true;
            }
            if (item.IdItems == 7)
            {
                saveItem7 = 1;
            }
            if (saveItem7 == 1)
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
    public void SaveData(GameData data)
    {
        data.saveItem1 = saveItem1;
        data.saveItem2 = saveItem2;
        data.saveItem3 = saveItem3;
        data.saveItem4 = saveItem4;
        data.saveItem5 = saveItem5;
        data.saveItem6 = saveItem6;
        data.saveItem7 = saveItem7;
        data.saaveEnemys = saaveEnemy;
        data.itemQuest1 = itemQuest1;
        data.itemQuest2 = itemQuest2;
        data.itemQuest3 = itemQuest3;
        data.itemQuest4 = itemQuest4;

        data.foundTuup = foundTuup;
        data.fondElectricfuse = fondElectricfuse;
        data.fondFlannel = fondFlannel;
        data.fondHistoryBook = fondHistoryBook;
        data.fondSchoolBag = fondSchoolBag;
        data.foundLightSteel = foundLightSteel;
        data.foundKey = foundKey;

    }

    public void LoadData(GameData data)
    {
        saveItem1 = data.saveItem1;
        saveItem2 = data.saveItem2;
        saveItem3 = data.saveItem3;
        saveItem4 = data.saveItem4;
        saveItem5 = data.saveItem5;
        saveItem6 = data.saveItem6;
        saveItem7 = data.saveItem7;
        saaveEnemy = data.saaveEnemys;
        itemQuest1 = data.itemQuest1;
        itemQuest2 = data.itemQuest2;
        itemQuest3 = data.itemQuest3;
        itemQuest4 = data.itemQuest4;

        foundKey = data.foundKey;
        foundLightSteel = data.foundLightSteel;
        foundTuup = data.foundTuup;
        fondElectricfuse = data.fondElectricfuse;
        fondFlannel = data.fondFlannel;
        fondHistoryBook = data.fondHistoryBook;
        fondSchoolBag = data.fondSchoolBag;

    }


}
   

       
