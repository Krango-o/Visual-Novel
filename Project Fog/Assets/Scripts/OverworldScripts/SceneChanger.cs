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

    protected override void ToggleClosest(bool isClosest) {
        base.ToggleClosest(isClosest);
        if (isClosest) {
            GameManager.instance.Player.ShowInteractionHint(InteractionType.RUN);
        } else {
            GameManager.instance.Player.HideInteractionHint();
        }
    }
}
