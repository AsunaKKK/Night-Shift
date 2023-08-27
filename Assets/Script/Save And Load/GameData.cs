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

    //public List<Quest> questData;

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

        chackQuestId = 0;
        doorOnQ = 0;
        itemOnQ = 0;
        chacracterQ = 0;
        setDialogQ = 0;
    }
}
