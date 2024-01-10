using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    List<NPCChangeSceneListener> NPCListenerList;

    // Start is called before the first frame update
    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        NPCListenerList = new List<NPCChangeSceneListener>(Resources.FindObjectsOfTypeAll<NPCChangeSceneListener>());
        foreach(NPCChangeSceneListener npc in NPCListenerList) {
            npc.CheckCompletedDialogues(NovelManager.instance.CompletedDialogues);
        }
    }
}
