using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public string currentScene;
    public float playTime;
    public List<string> completedDialogues;
    public List<string> lostItemsUnlockedIds;
    public List<string> lostItemsCompletedIds;
    public List<string> characterInfoUnlockedIds;

    public GameData()
    {
        this.currentScene = "";
        this.playTime = 0;
        this.completedDialogues = new List<string>();
        this.lostItemsUnlockedIds = new List<string>();
        this.lostItemsCompletedIds = new List<string>();
        this.characterInfoUnlockedIds = new List<string>();
    }
}
