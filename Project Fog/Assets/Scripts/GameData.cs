using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public string currentScene;
    public List<string> completedDialogues;
    public List<string> lostItemsUnlockedIds;
    public List<string> lostItemsCompletedIds;
    public List<string> characterInfoUnlockedIds;

    public GameData()
    {
        this.currentScene = "";
        this.completedDialogues = new List<string>();
        this.lostItemsUnlockedIds = new List<string>();
        this.lostItemsCompletedIds = new List<string>();
        this.characterInfoUnlockedIds = new List<string>();
    }
}
