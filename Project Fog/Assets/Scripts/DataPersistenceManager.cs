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

    public void DeleteGameFromEditor() {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        fileDataHandler.Delete();
    }

    List<IDataPersistence> GetAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistences);
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
