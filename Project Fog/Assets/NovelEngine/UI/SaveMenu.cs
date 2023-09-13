using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Grid;

    public bool SaveMode = true;

    public void OnEnable()
    {
        List<SaveObject> saves = NovelManager.instance.SaveManager.GetSaves();
        SaveGridButton[] buttons = Grid.GetComponentsInChildren<SaveGridButton>();
        foreach(SaveObject save in saves)
        {
            if(save.slot >= 0 && save.slot < buttons.Length)
            {
                buttons[save.slot].SetData(save.date);
            }
        }
    }

    public void BackButton()
    {
        this.gameObject.SetActive(false);
    }

    public void SaveButton(Button button)
    {
        Button[] children = Grid.GetComponentsInChildren<Button>();
        int index = 0;
        foreach (Button butt in children)
        {
            if (butt == button)
            {
                break;
            }
            index++;
        }
        if (SaveMode)
        {
            List<SaveObject> saves = NovelManager.instance.SaveManager.GetSaves();
            foreach(SaveObject save in saves)
            {
                if(save.slot == index)
                {
                    GameObject a = NovelManager.instance.UIUtility.CreateAlertBox("Overwrite this save?", this.transform.parent, () => {
                        SendSave(button, index);
                    }, () => { });
                    return;
                }
            }
            SendSave(button, index);
        }
        else
        {
            NovelManager.instance.SaveManager.LoadGame(index);
        }
    }

    public void SendSave(Button button, int index)
    {
        AnimDialogueManager dm = GameObject.Find("NovelCanvas").GetComponent<AnimDialogueManager>();
        SaveGridButton gridButton = button.GetComponent<SaveGridButton>();
        gridButton.SetData(System.DateTime.Now.ToString());
        //can't use getsiblingindex
        NovelManager.instance.SaveManager.SaveGame(index, PlayerPrefs.GetString(DataConstants.PLAYERPREFS_CURRENTSCENE), dm.GetCurrentLine(), System.DateTime.Now, dm.GetChoices());
    }
}
