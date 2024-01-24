using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum SAVEMENU_STATE { NONE, SAVE, LOAD, DELETE }

public class DataMenu : Menu {
    [SerializeField]
    private List<SaveDataPrefab> saveDataList;

    public override void OnTransitionIn(bool skipAnimation = false) {
        base.OnTransitionIn(skipAnimation);
        int index = 0;
        foreach(SaveDataPrefab save in saveDataList) {
            //TODO - Get game data from datapersistencemanager
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
