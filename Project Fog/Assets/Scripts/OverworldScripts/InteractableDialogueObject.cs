using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableDialogueObject : Interactable {
    [Header("Dialogue")]
    [SerializeField]
    private string[] lines;
    [SerializeField]
    private GameObject dialoguePrefab;
    private bool interacting;
    private GameState prevGameState;

    public override void Interact() {
        base.Interact();
        if (!interacting) {
            interacting = true;
            prevGameState = GameManager.instance.CurrentGameState;
            GameManager.instance.SetState(GameState.WORLDDIALOGUE);
            InteractableDialogueManager.ShowDialogue(lines, dialoguePrefab, () => {
                interacting = false;
                GameManager.instance.SetState(prevGameState);
            });
        }
    }
}

public static class InteractableDialogueManager {
    public static void ShowDialogue(string[] lines, GameObject dialoguePrefab, Action onCompleteCallback) {
        DialoguePopup dialogueBox = GameObject.Instantiate(dialoguePrefab).GetComponent<DialoguePopup>();
        dialogueBox.ShowDialogue(lines, onCompleteCallback);
    }
}
