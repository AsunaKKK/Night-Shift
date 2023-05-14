using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataSave 
{
    void SaveData(ref GameData data);

    void LoadData(GameData data);
}
