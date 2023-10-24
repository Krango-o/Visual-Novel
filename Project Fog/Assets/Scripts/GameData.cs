using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public string currentScene;
    public List<string> completedDialogues;

    public GameData()
    {
        this.currentScene = "";
        this.completedDialogues = new List<string>();
    }
}
