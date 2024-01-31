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
    [SerializeField]
    RectTransform infoContainer;
    [SerializeField]
    RectTransform noDataContainer;

    int saveIndex;
    bool hasSave;
    SAVEMENU_STATE buttonState = SAVEMENU_STATE.NONE;

    public void SetData(int index, GameData gameData) {
        hasSave = gameData.playTime > 0;
        infoContainer.gameObject.SetActive(hasSave);
        noDataContainer.gameObject.SetActive(!hasSave);
        saveIndex = index;

        if (hasSave) {
            titleText.text = "Slot " + (index + 1);
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(gameData.playTime);
            string timeString = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                    timeSpan.Hours,
                    timeSpan.Minutes,
                    timeSpan.Seconds);
            TimePlayedText.text = "Time Played: " + timeString;
        }
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
                if (hasSave) {
                    //TODO: Genpop alert to overwrite save data
                }
                GameData newSaveData = GameManager.instance.DataPersistenceManager.SaveGame(saveIndex);
                SetData(saveIndex, newSaveData);
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
