using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    /*[Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;*/

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
            Debug.Log("Found more than one Data Presistence Manager in the scene. , Destroying the newst one.");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHendler = new FileDataControl(Application.persistentDataPath, fileName);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnLoaded;
    }

    public void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        this.dataSavesObjects = FindAllDataSaveObjects();
        LoadGame();
    }
    public void OnSceneUnLoaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }


    public void SaveGame()
    {
        if (this.gameObject == null)
        {
            Debug.LogWarning("No data was found. A new game needs to be started.");
            return;
        }

        foreach (IDataSave dataSaveObj in dataSavesObjects)
        {
            dataSaveObj.SaveData(gameData);
        }

        dataHendler.Save(gameData);
    }

    public void LoadGame()
    {

        this.gameData = dataHendler.Load();

       /* if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }*/

        if(this.gameData == null)
        {
            Debug.Log("No data not found , a new game need to be start befor data can be load");
            return;
        }

        foreach(IDataSave dataSaveObj in dataSavesObjects)
        {
            dataSaveObj.LoadData(gameData);
        }

    }

    private List<IDataSave> FindAllDataSaveObjects()
    {
        IEnumerable<IDataSave> dataSavesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataSave>();

        return new List<IDataSave>(dataSavesObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
