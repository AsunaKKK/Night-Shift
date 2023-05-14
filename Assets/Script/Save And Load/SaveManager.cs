using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataSave> dataSavesObjects;

    private FileDataControl dataHendler;

    public static SaveManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Presistence Manager in the scene.");
        }

        instance = this;
    }

    private void Start()
    {
        this.dataHendler = new FileDataControl(Application.persistentDataPath, fileName);
        Debug.Log(Application.persistentDataPath);
        this.dataSavesObjects = FindAllDataSaveObjects();
        LoadGame();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }


    public void SaveGame()
    {
        foreach (IDataSave dataSaveObj in dataSavesObjects)
        {
            dataSaveObj.SaveData(ref gameData);
        }

        dataHendler.Save(gameData);
    }

    public void LoadGame()
    {

        this.gameData = dataHendler.Load();


        if(this.gameData == null)
        {
            Debug.Log("No data not found");
            NewGame();
        }

        foreach(IDataSave dataSaveObj in dataSavesObjects)
        {
            dataSaveObj.LoadData(gameData);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataSave> FindAllDataSaveObjects()
    {
        IEnumerable<IDataSave> dataSavesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataSave>();

        return new List<IDataSave>(dataSavesObjects);
    }
}
