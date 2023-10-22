using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField]
    protected string fileName = "game.data";
    FileDataHandler fileDataHandler;
    GameData gameData = null;
    List<IDataPersistence> dataPersistenceObjects;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dataPersistenceObjects = GetAllDataPersistenceObjects();
        LoadGame();
    }

    void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();

        //Get all data persistance things in the scene
        foreach (IDataPersistence item in dataPersistenceObjects)
        {
            item.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence item in dataPersistenceObjects)
        {
            item.SaveData(ref gameData);
        }
        fileDataHandler.Save(gameData);
    }

    List<IDataPersistence> GetAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistences);
    }
}
