using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eflatun.SceneReference;

[CreateAssetMenu(fileName = "SpawnPointSO", menuName = "ScriptableObjects/SpawnPointSO", order = 2)]
public class SpawnPointSO : ScriptableObject {

    [field: SerializeField] public string Id { get; private set; }

    [SerializeField]
    public SceneReference sceneToLoad;

    private void OnValidate() {
#if UNITY_EDITOR
        Id = sceneToLoad.Name + "_" + this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
