using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public float playerCurrentHp;
    public float playerCurrentMp;
    public float playerHpMax;

    public SerealizableDictionary<string, bool> idItem;
    public List<Item> inventoryItems;
    public SerealizableDictionary<string, bool> idItemQuest;
    public List<ItemQuest> inventoryItemQuest;

    public int questID =1;
    public int setQuestID = 1;
    public int setCompletionID = 0;
    public int lightonQ;
    public int doorAlls = 0;
    public int buchaDoor = 0;


    public int chackQuestId;
    public int doorOnQ = 0;
    public int itemOnQ = 0;
    public int chacracterQ = 0;
    public int setDialogQ = 0;

    //Item
    public int saveItem1 = 0;
    public int saveItem2 = 0;
    public int saveItem3 = 0;
    public int saveItem4 = 0;
    public int saveItem5 = 0;
    public int saveItem6 = 0;
    public int saveItem7 = 0;

    //DialogSave
    public int dialogSave1s = 0;
    public int dialogSave2s = 0;
    public int dialogSave3s = 0;
    public int dialogSave4s = 0;
    public int dialogSave5s = 0;
    public int dialogSave6s = 0;
    public int dialogSave7s = 0;
    public int dialogSave8s = 0;
    public int dialogSave9s = 0;
    public int dialogSave10s = 0;
    public int dialogSave11s = 0;
    public int dialogSave12s = 0;
    public int dialogSave13s = 0;
    public int dialogSave14s = 0;

    //Save Elec
    public int electriFuseSave = 0;

    //SavetalisManpaper
    public int talisManpaper1Save = 0;
    public int talisManpaper2Save = 0;
    public int talisManpaper3Save = 0;
    public int talisManpaper4Save = 0;
    public int talisManpaper5Save = 0;

    //Save SenQuest
    public int seveSen1s = 0;
    public int seveSen2s = 0;
    public int seveSen3s = 0;
    public int seveSen4s = 0;
    public int seveSen5s = 0;
    public int seveSen6s = 0;
    public int seveSen7s = 0;
    public int seveSen8s = 0;
    public int seveSen9s = 0;
    public int seveSen10s = 0;

    public bool itemQuest1 = false;
    public bool itemQuest2 = false;
    public bool itemQuest3 = false;
    public bool itemQuest4 = false;

    public bool foundTuup = false;
    public bool foundLightSteel = false;
    public bool foundKey = false;
    public bool fondElectricfuse = false;
    public bool fondFlannel = false;
    public bool fondSchoolBag = false;
    public bool fondHistoryBook = false;

    //Save Enemy
    public int saaveEnemys = 0;

    public  bool quest1 = false;
    public  bool quest2 = false;
    public  bool quest3 = false;
    public  bool quest4 = false;
    public  bool quest5 = false;
    public  bool quest6 = false;
    public  bool quest7 = false;
    public  bool quest8 = false;
    public  bool quest9 = false;
    public  bool quest10 = false;
    public  bool quest11 = false;
    public  bool quest12 = false;
    public  bool quest13 = false;
    public  bool quest14 = false;
    public  bool quest15 = false;
    public  bool quest16 = false;
    public  bool quest17 = false;
    public  bool quest18 = false;
    public  bool quest19 = false;
    public  bool quest20 = false;
    public  bool quest21 = false;
    public  bool quest22 = false;
    public  bool quest23 = false;
    public  bool quest24 = false;


    public  bool quest1Completion = false;
    public  bool quest2Completion = false;
    public  bool quest3Completion = false;
    public  bool quest4Completion = false;
    public  bool quest5Completion = false;
    public  bool quest6Completion = false;
    public  bool quest7Completion = false;
    public  bool quest8Completion = false;
    public  bool quest9Completion = false;
    public  bool quest10Completion = false;
    public  bool quest11Completion = false;
    public  bool quest12Completion = false;
    public  bool quest13Completion = false;
    public  bool quest14Completion = false;
    public  bool quest15Completion = false;
    public  bool quest16Completion = false;
    public  bool quest17Completion = false;
    public  bool quest18Completion = false;
    public  bool quest19Completion = false;
    public  bool quest20Completion = false;
    public  bool quest21Completion = false;
    public  bool quest22Completion = false;
    public  bool quest23Completion = false;
    public  bool quest24Completion = false;

    public Vector3 playerMapPosition;
    public Quaternion playerMapRotation;
    public GameData()
    {
        this.playerHpMax = 100;
        this.playerCurrentMp = 100;
        this.playerCurrentHp = 100;
        playerPosition = Vector3.zero;
        idItem = new SerealizableDictionary<string, bool>();
        inventoryItems = new List<Item>();
        idItemQuest = new SerealizableDictionary<string, bool>();
        inventoryItemQuest = new List<ItemQuest>();
        playerMapPosition = new Vector3(654f, 1556f, 0f);
        playerMapRotation = Quaternion.identity;


        questID = 1;
        setQuestID = 1;
        setCompletionID = 0;
        lightonQ = 0;
        doorAlls = 0;
        buchaDoor = 0;

        saveItem1 = 0;
        saveItem2 = 0;
        saveItem3 = 0;
        saveItem4 = 0;
        saveItem5 = 0;
        saveItem6 = 0;
        saveItem7 = 0;

        dialogSave1s = 0;
        dialogSave2s = 0;
        dialogSave3s = 0;
        dialogSave4s = 0;
        dialogSave5s = 0;
        dialogSave6s = 0;
        dialogSave7s = 0;
        dialogSave8s = 0;
        dialogSave9s = 0;
        dialogSave10s = 0;
        dialogSave11s = 0;
        dialogSave12s = 0;
        dialogSave13s = 0;
        dialogSave14s = 0;

        electriFuseSave = 0;
        talisManpaper1Save = 0;
        talisManpaper2Save = 0;
        talisManpaper3Save = 0;
        talisManpaper4Save = 0;
        talisManpaper5Save = 0;

        seveSen1s = 0;
        seveSen2s = 0;
        seveSen3s = 0;
        seveSen4s = 0;
        seveSen5s = 0;
        seveSen6s = 0;
        seveSen7s = 0;
        seveSen8s = 0;
        seveSen9s = 0;
        seveSen10s = 0;
        itemQuest1 = false;
        itemQuest2 = false;
        itemQuest3 = false;
        itemQuest4 = false;

        foundTuup = false;
        foundLightSteel = false;
        foundKey = false;
        fondElectricfuse = false;
        fondFlannel = false;
        fondSchoolBag = false;
        fondHistoryBook = false;

        //Save Quest
        quest1 = false;
        quest2 = false;
        quest3 = false;
        quest4 = false;
        quest5 = false;
        quest6 = false;
        quest7 = false;
        quest8 = false;
        quest9 = false;
        quest10 = false;
        quest11 = false;
        quest12 = false;
        quest13 = false;
        quest14 = false;
        quest15 = false;
        quest16 = false;
        quest17 = false;
        quest18 = false;
        quest19 = false;
        quest20 = false;
        quest21 = false;
        quest22 = false;
        quest23 = false;
        quest24 = false;


        quest1Completion = false;
        quest2Completion = false;
        quest3Completion = false;
        quest4Completion = false;
        quest5Completion = false;
        quest6Completion = false;
        quest7Completion = false;
        quest8Completion = false;
        quest9Completion = false;
        quest10Completion = false;
        quest11Completion = false;
        quest12Completion = false;
        quest13Completion = false;
        quest14Completion = false;
        quest15Completion = false;
        quest16Completion = false;
        quest17Completion = false;
        quest18Completion = false;
        quest19Completion = false;
        quest20Completion = false;
        quest21Completion = false;
        quest22Completion = false;
        quest23Completion = false;
        quest24Completion = false;


        saaveEnemys = 0;

        chackQuestId = 0;
        doorOnQ = 0;
        itemOnQ = 0;
        chacracterQ = 0;
        setDialogQ = 0;
    }
}
