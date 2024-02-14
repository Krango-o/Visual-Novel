using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eflatun.SceneReference;

public class SceneChanger : Interactable {
    [Header("Scene Changer")]
    [SerializeField]
    private SpawnPointSO spawnPointSO;

    public override void Interact() {
        GameManager.instance.LoadScene(spawnPointSO);
    }
}
