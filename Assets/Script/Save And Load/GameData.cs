using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public float playerCurrentHp;

    public GameData()
    {
        this.playerCurrentHp = 100;
        playerPosition = Vector3.zero;
    }
}
