using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eflatun.SceneReference;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Reflection;
using System;

[ExecuteInEditMode]
public class AdditiveSceneData : MonoBehaviour {
    [Header("Audio")]
    [SerializeField]
    private AudioClip defaultSong;
    [SerializeField]
    private SceneReference baseScene;

    private Scene additiveActiveScene;
    private Scene openedScene;

#if UNITY_EDITOR
    private void Awake() {
        if (EditorApplication.isPlaying) return;
        if (EditorSceneManager.GetActiveScene().name == this.baseScene.Name) return; 
        int countLoaded = EditorSceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++) {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }
        foreach(Scene s in loadedScenes) {
            if (s.name == this.baseScene.Name) {
                EditorSceneManager.SetActiveScene(s);
                return;
            }
        }

        additiveActiveScene = EditorSceneManager.GetActiveScene();
        openedScene = EditorSceneManager.OpenScene(this.baseScene.Path, OpenSceneMode.Additive);
        EditorSceneManager.SetActiveScene(openedScene);
        EditorSceneManager.MoveSceneBefore(openedScene, additiveActiveScene);

        foreach (var window in Resources.FindObjectsOfTypeAll<SearchableEditorWindow>()) {
            if (window.GetType().Name != "SceneHierarchyWindow")
                continue;

            var method = window.GetType().GetMethod("SetExpanded",
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance, null,
                new[] { typeof(int), typeof(bool) }, null);

            if (method == null) {
                Debug.LogError(
                    "Could not find method 'UnityEditor.SceneHierarchyWindow.SetExpandedRecursive(int, bool)'.");
                return;
            }

            var field = additiveActiveScene.GetType().GetField("m_Handle",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (field == null) {
                Debug.LogError("Could not find field 'int UnityEngine.SceneManagement.Scene.m_Handle'.");
                return;
            }

            var sceneHandle = field.GetValue(additiveActiveScene);
            method.Invoke(window, new[] { sceneHandle, true });

            var baseMethod = window.GetType().GetMethod("SetExpanded",
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance, null,
                new[] { typeof(int), typeof(bool) }, null);

            if (baseMethod == null) {
                Debug.LogError(
                    "Could not find method 'UnityEditor.SceneHierarchyWindow.SetExpandedRecursive(int, bool)'.");
                return;
            }

            var baseField = openedScene.GetType().GetField("m_Handle",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (baseField == null) {
                Debug.LogError("Could not find field 'int UnityEngine.SceneManagement.Scene.m_Handle'.");
                return;
            }

            var baseSceneHandle = baseField.GetValue(openedScene);
            baseMethod.Invoke(window, new[] { baseSceneHandle, false });
        }
    }
#endif

    // Can do scene specific start things here
    void Start() {
        if(GameManager.instance != null) {
            if (defaultSong != null) {
                GameManager.instance.AudioManager.PlayMusicClip(defaultSong);
            } else {
                GameManager.instance.AudioManager.StopMusic();
            }
        }
    }
}
