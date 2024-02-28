using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Febucci.UI;
using DG.Tweening;

public class DialoguePopup : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TypewriterByCharacter typewriter;

    private string[] lines;
    private float delayTimer;
    private float delayTimerMax = 0.4f;
    private int currentLine = 0;
    private Action onCompleteCallback;

    public void ShowDialogue(string[] lines, Action onCompleteCallback) {
        this.lines = lines;
        this.onCompleteCallback = onCompleteCallback;
        delayTimer = delayTimerMax + 0.2f;
        currentLine = 0;
        canvasGroup.DOFade(1.0f, 0.2f).OnComplete(() => {
            typewriter.ShowText(lines[0]);
        });
    }

    private void Update() {
        if (delayTimer > 0) {
            delayTimer -= Time.deltaTime;
            return;
        }
        if (Input.GetButtonDown("Interact")) {
            currentLine += 1;
            if(currentLine >= lines.Length) {
                ClosePopup();
            } else {
                typewriter.ShowText(lines[currentLine]);
            }
        }
    }

    public void ClosePopup() {
        canvasGroup.DOFade(0.0f, 0.2f).OnComplete(() => {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            onCompleteCallback.Invoke();
            Destroy(gameObject);
        });
    }
}
