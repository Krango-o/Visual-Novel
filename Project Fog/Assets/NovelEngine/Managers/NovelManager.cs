using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelManager : MonoBehaviour, IDataPersistence
{
    public static NovelManager instance = null;
    
    public EventManager EventManager { get; private set; }
    public UIUtility UIUtility { get; private set; }
    public SaveManager SaveManager { get; private set; }

    private List<string> completedDialogues;

    private void Awake()
    {
        if (instance == null)
        {
            //Starting up the game
            instance = this;
            EventManager = this.GetComponent<EventManager>();
            UIUtility = this.GetComponent<UIUtility>();
            SaveManager = this.GetComponent<SaveManager>();
            completedDialogues = new List<string>();
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void EndScene(TextAsset dialogueTextAsset)
    {
        GameManager.instance.vnSceneEnded.Invoke(dialogueTextAsset.name);
        if(!completedDialogues.Contains(dialogueTextAsset.name)) {
            completedDialogues.Add(dialogueTextAsset.name);
        }
    }

    public void LoadData(GameData gameData)
    {
        completedDialogues = gameData.completedDialogues;
    }

    public void SaveData(ref GameData gameData)
    {
        foreach (string item in completedDialogues)
        {
            if (!gameData.completedDialogues.Contains(item))
            {
                gameData.completedDialogues.Add(item);
            }
        }
    }
}
