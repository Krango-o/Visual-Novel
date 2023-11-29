using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SaveDataPrefab : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI titleText;
    [SerializeField]
    TextMeshProUGUI actText;
    [SerializeField]
    TextMeshProUGUI TimePlayedText;
    [SerializeField]
    Image KoiLocationImage;
    [SerializeField]
    Button buttonComponent;

    int saveIndex;
    SAVEMENU_STATE buttonState = SAVEMENU_STATE.NONE;

    public void SetData(int index, GameData gameData) {
        titleText.text = "Slot " + (index + 1);
        saveIndex = index;
    }

    public void SetIsInteractable(bool isInteractable) {
        buttonComponent.interactable = isInteractable;
    }

    public void SetButtonState(SAVEMENU_STATE saveState) {
        buttonState = saveState;
        SetIsInteractable(buttonState != SAVEMENU_STATE.NONE);
    }

    public void OnClick() {
        switch (buttonState) {
            case SAVEMENU_STATE.SAVE:
                GameManager.instance.DataPersistenceManager.SaveGame(saveIndex);
                break;
            case SAVEMENU_STATE.LOAD:
                GameManager.instance.DataPersistenceManager.LoadGame(saveIndex);
                break;
            case SAVEMENU_STATE.DELETE:
                //Todo
                break;
            case SAVEMENU_STATE.NONE:
                break;
        }
    }
}
