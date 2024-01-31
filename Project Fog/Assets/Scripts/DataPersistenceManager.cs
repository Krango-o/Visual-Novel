using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEditor;

public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField]
    protected string fileName = "game.data";
    [SerializeField]
    protected bool useEncryption = true;
    FileDataHandler fileDataHandler;
    GameData gameData = null;
    List<IDataPersistence> dataPersistenceObjects;
    private int maxSaves = 3;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dataPersistenceObjects = GetAllDataPersistenceObjects();
    }

    void OnSceneUnloaded(Scene scene)
    {
        // Auto Save?
        //SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public GameData LoadGame(int index = -1)
    {
        this.gameData = fileDataHandler.Load(index);

        dataPersistenceObjects = GetAllDataPersistenceObjects();
        //Get all data persistance things in the scene
        foreach (IDataPersistence item in dataPersistenceObjects)
        {
            item.LoadData(gameData);
        }
        GameManager.instance.LoadScene(this.gameData.currentScene);
        GameManager.instance.UnpauseGame();
        GameManager.instance.SetState(GameState.OVERWORLD);
        return this.gameData;
    }

    public GameData SaveGame(int index = -1) {
        if (this.gameData == null) {
            this.gameData = new GameData();
        }
        dataPersistenceObjects = GetAllDataPersistenceObjects();
        foreach (IDataPersistence item in dataPersistenceObjects)
        {
            item.SaveData(ref gameData);
        }
        gameData.currentScene = SceneManager.GetActiveScene().name;
        fileDataHandler.Save(gameData, index);
        return gameData;
    }

    public void DeleteGameFromEditor() {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        fileDataHandler.Delete();
    }

    List<IDataPersistence> GetAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistences);
    }

    public List<GameData> GetAllSaveData() {
        List<GameData> gameDataList = new List<GameData>();
        for(int i=0; i < maxSaves; i++) {
            gameDataList.Add(fileDataHandler.Load(i));
        }
        return gameDataList;
    }
}

[CustomEditor(typeof(DataPersistenceManager))]
public class DataPersistenceEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Delete Save Data")) {
            if (EditorUtility.DisplayDialog("Delete the save data?", "Are you sure you want to delete the game save data?", "Yes")) {
                DataPersistenceManager myScript = (DataPersistenceManager)target;
                myScript.DeleteGameFromEditor();
            }
        }
    }
}
