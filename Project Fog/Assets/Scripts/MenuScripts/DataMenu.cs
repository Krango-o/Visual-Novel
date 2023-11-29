using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SAVEMENU_STATE { NONE, SAVE, LOAD, DELETE }

public class DataMenu : MonoBehaviour, IScreenInterface
{
    [SerializeField]
    private List<SaveDataPrefab> saveDataList;

    public void OnTransitionIn() {
        int index = 0;
        foreach(SaveDataPrefab save in saveDataList) {
            save.SetData(index, new GameData());
            save.SetButtonState(SAVEMENU_STATE.NONE);
            index++;
        }
    }

    public void OnSaveButtonClick() {
        foreach (SaveDataPrefab save in saveDataList) {
            save.SetButtonState(SAVEMENU_STATE.SAVE);
        }
    }

    public void OnLoadButtonClick() {
        foreach (SaveDataPrefab save in saveDataList) {
            save.SetButtonState(SAVEMENU_STATE.LOAD);
        }
    }

    public void OnDeleteButtonClick() {
        foreach (SaveDataPrefab save in saveDataList) {
            save.SetButtonState(SAVEMENU_STATE.DELETE);
        }
    }
}
