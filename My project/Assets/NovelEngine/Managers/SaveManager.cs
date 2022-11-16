using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private string savesPath;
    private SaveObject currentSave;
    private bool loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        savesPath = Application.persistentDataPath + "/saves/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<SaveObject> GetSaves()
    {
        List<SaveObject> saves = new List<SaveObject>();
        if (Directory.Exists(savesPath))
        {
            foreach (string file in Directory.EnumerateFiles(savesPath, "*.save"))
            {
                string json = File.ReadAllText(file);
                saves.Add(JsonUtility.FromJson<SaveObject>(json));
            }
        }
        return saves;
    }

    public void SaveGame(int slot, string sceneName, int line, DateTime date, string[] choices)
    {
        SaveObject save = new SaveObject();
        save.slot = slot;
        save.sceneName = sceneName;
        save.line = line;
        save.date = date.ToString();
        save.choices = choices;
        string json = JsonUtility.ToJson(save);
        string currentPath = savesPath + "save" + slot + ".save";
        if (!Directory.Exists(savesPath))
        {
            Directory.CreateDirectory(savesPath);
        }
        File.WriteAllText(currentPath, json);
        Debug.Log("Saved at " + currentPath);
    }

    public void LoadGame(int slot)
    {
        string json = File.ReadAllText(savesPath + "save" + slot + ".save");
        currentSave = JsonUtility.FromJson<SaveObject>(json);
        loaded = true;
        SceneManager.LoadScene("TestScene");
    }

    public SaveObject GetLoaded()
    {
        if (loaded)
        {
            loaded = false;
            return currentSave;
        }
        else
        {
            return null;
        }
    }
}
