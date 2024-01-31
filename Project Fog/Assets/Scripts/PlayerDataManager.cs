using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour, IDataPersistence
{
    public List<string> LostItemsUnlockedIds { get; private set; }
    public List<string> LostItemsCompletedIds { get; private set; }
    public List<string> CharacterInfoUnlockedIds { get; private set; }

    private float playTime = 0;

    private void Start() {
        GameManager.instance.characterDataUnlocked.AddListener(UnlockCharacterDataId);
        GameManager.instance.lostItemUnlocked.AddListener(UnlockLostItemId);
        GameManager.instance.lostItemCompleted.AddListener(UnlockLostItemId);

        LostItemsUnlockedIds = new List<string>();
        LostItemsCompletedIds = new List<string>();
        CharacterInfoUnlockedIds = new List<string>();
    }

    private void Update() {
        playTime += Time.deltaTime;
    }

    public void UnlockCharacterDataId(string characterId) {
        if (!CharacterInfoUnlockedIds.Contains(characterId)) {
            CharacterInfoUnlockedIds.Add(characterId);
        }
    }

    public void UnlockLostItemId(LostItemSO lostItem) {
        if (!LostItemsUnlockedIds.Contains(lostItem.Id)) {
            LostItemsUnlockedIds.Add(lostItem.Id);
        }
    }

    public void CompleteLostItemId(LostItemSO lostItem) {
        if (!LostItemsCompletedIds.Contains(lostItem.Id)) {
            LostItemsCompletedIds.Add(lostItem.Id);
        }
    }

    public void SaveData(ref GameData gameData) {
        gameData.lostItemsUnlockedIds = LostItemsUnlockedIds;
        gameData.characterInfoUnlockedIds = CharacterInfoUnlockedIds;
        gameData.playTime = playTime;
    }

    void IDataPersistence.LoadData(GameData gameData) {
        LostItemsUnlockedIds = gameData.lostItemsUnlockedIds;
        CharacterInfoUnlockedIds = gameData.characterInfoUnlockedIds;
        playTime = gameData.playTime;
    }
}
