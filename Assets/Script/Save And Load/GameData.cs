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

    public Vector3 playerMapPosition;
    public GameData()
    {
        this.playerHpMax = 100;
        this.playerCurrentMp = 100;
        this.playerCurrentHp = 100;
        playerPosition = Vector3.zero;
        idItem = new SerealizableDictionary<string, bool>();
        inventoryItems = new List<Item>();
        playerMapPosition = Vector3.zero;
    }
}
