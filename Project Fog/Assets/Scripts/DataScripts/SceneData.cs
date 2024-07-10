using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eflatun.SceneReference;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneData : MonoBehaviour {
    [Header("Additive Scenes")]
    [SerializeField]
    public SceneReference chapter1Scene;
    [SerializeField]
    public SceneReference chapter2Scene;
    [SerializeField]
    public SceneReference chapter3Scene;
    [SerializeField]
    public SceneReference chapter4Scene;
    [SerializeField]
    public SceneReference chapter5Scene;
    [SerializeField]
    public SceneReference chapter6Scene;
    [SerializeField]
    public SceneReference chapter7Scene;

    void Awake()
    {
        LoadAdditiveChapter();
    }

    public void LoadAdditiveChapter() {
        //TODO add chapter switch case
        if(chapter1Scene != null) {
            GameManager.instance.LoadSceneAdditive(chapter1Scene.Name);
        }
    }
}

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Load Chapter 1")) {
            SceneData myScript = (SceneData)target;
            if(GUID.TryParse(myScript.chapter1Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter1Scene.Path, OpenSceneMode.Additive);
            }
        }
        if (GUILayout.Button("Load Chapter 2")) {
            SceneData myScript = (SceneData)target;
            if (GUID.TryParse(myScript.chapter2Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter2Scene.Path, OpenSceneMode.Additive);
            }
        }
        if (GUILayout.Button("Load Chapter 3")) {
            SceneData myScript = (SceneData)target;
            if (GUID.TryParse(myScript.chapter3Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter3Scene.Path, OpenSceneMode.Additive);
            }
        }
        if (GUILayout.Button("Load Chapter 4")) {
            SceneData myScript = (SceneData)target;
            if (GUID.TryParse(myScript.chapter4Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter4Scene.Path, OpenSceneMode.Additive);
            }
        }
        if (GUILayout.Button("Load Chapter 5")) {
            SceneData myScript = (SceneData)target;
            if (GUID.TryParse(myScript.chapter5Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter5Scene.Path, OpenSceneMode.Additive);
            }
        }
        if (GUILayout.Button("Load Chapter 6")) {
            SceneData myScript = (SceneData)target;
            if (GUID.TryParse(myScript.chapter6Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter6Scene.Path, OpenSceneMode.Additive);
            }
        }
        if (GUILayout.Button("Load Chapter 7")) {
            SceneData myScript = (SceneData)target;
            if (GUID.TryParse(myScript.chapter7Scene.Guid, out _)) {
                EditorSceneManager.OpenScene(myScript.chapter7Scene.Path, OpenSceneMode.Additive);
            }
        }
    }
}
