using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour, IDataPersistence
{
    public List<string> LostItemsUnlockedIds { get; private set; }
    public List<string> LostItemsCompletedIds { get; private set; }
    public List<string> CharacterInfoUnlockedIds { get; private set; }

    private void Start() {
        GameManager.instance.characterDataUnlocked.AddListener(UnlockCharacterDataId);
        GameManager.instance.lostItemUnlocked.AddListener(UnlockLostItemId);
        GameManager.instance.lostItemCompleted.AddListener(UnlockLostItemId);

        LostItemsUnlockedIds = new List<string>();
        LostItemsCompletedIds = new List<string>();
        CharacterInfoUnlockedIds = new List<string>();
    }

    public void UnlockCharacterDataId(string characterId) {
        if (!CharacterInfoUnlockedIds.Contains(characterId)) {
            CharacterInfoUnlockedIds.Add(characterId);
        }
    }

    public void UnlockLostItemId(string lostItemId) {
        if (!LostItemsUnlockedIds.Contains(lostItemId)) {
            LostItemsUnlockedIds.Add(lostItemId);
        }
    }

    public void CompleteLostItemId(string lostItemId) {
        if (!LostItemsCompletedIds.Contains(lostItemId)) {
            LostItemsCompletedIds.Add(lostItemId);
        }
    }

    public void SaveData(ref GameData gameData) {
        gameData.lostItemsUnlockedIds = LostItemsUnlockedIds;
        gameData.characterInfoUnlockedIds = CharacterInfoUnlockedIds;
    }

    void IDataPersistence.LoadData(GameData gameData) {
        LostItemsUnlockedIds = gameData.lostItemsUnlockedIds;
        CharacterInfoUnlockedIds = gameData.characterInfoUnlockedIds;
    }
}
