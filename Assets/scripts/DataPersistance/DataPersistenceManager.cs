using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    [SerializeField] private bool initializedateifnull = false;

    public static DataPersistenceManager instace { get; private set; }
    private GameData gamedata;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandle dataHandler;


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      
        this.dataPersistenceObjects = FindAllDatapersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
       
        SaveGame();

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void Awake()
    {
        if (instace != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene., destroying newest one");
            Destroy(this.gameObject);
            return;

        }
        instace = this;

        this.dataHandler = new FileDataHandle(Application.persistentDataPath, fileName);
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        this.dataHandler = new FileDataHandle(Application.persistentDataPath, fileName);

        this.dataPersistenceObjects = FindAllDatapersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.gamedata = new GameData();
    }
     
    public void LoadGame()
    {
        this.gamedata = dataHandler.Load();

        if (this.gamedata == null && initializedateifnull)
        {
            Debug.Log("newgame started");
            NewGame();

        }

        if (this.gamedata == null)
        {
            Debug.Log("No data was found, A new game needs to be started before data can be loaded");
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
           
            dataPersistenceObj.LoadData(gamedata);
        }
       
    }

    public void SaveGame()
    {

        if (this.gamedata == null)
        {
            Debug.LogWarning("no data was found. A new game needs to be started before data ca nbe saved.");
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gamedata);
            Debug.Log(gamedata);

        }


       
        dataHandler.Save(gamedata);

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDatapersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gamedata != null;
    }
}
