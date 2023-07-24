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
    public int setQuestID = 0;
    public int setCompletionID = 0;
    public int chackQuestId;
    public int lightonQ;
    public int doorOnQ = 0;
    public int itemOnQ = 0;
    public int chacracterQ = 0;
    public int setDialogQ = 0;

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
        chackQuestId = 0;
        lightonQ = 0;
        doorOnQ = 0;
        itemOnQ = 0;
        chacracterQ = 0;
        setDialogQ = 0;
    }
}
