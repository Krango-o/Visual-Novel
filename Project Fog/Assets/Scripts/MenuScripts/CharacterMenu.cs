using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class CharacterMenu : Menu {
    [Header("Character Menu")]
    [SerializeField]
    private GameObject characterProfilePrefab;
    [SerializeField]
    private RectTransform listContentParent;

    [SerializeField]
    private Image characterPortrait;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI ageText;
    [SerializeField]
    private TextMeshProUGUI pronounsText;
    [SerializeField]
    private TextMeshProUGUI occupationText;
    [SerializeField]
    private TextMeshProUGUI firstBioText;
    [SerializeField]
    private TextMeshProUGUI secondBioText;

    public List<CharacterProfileSO> characterProfiles;

    public override void OnTransitionIn(bool skipAnimation = false) {
        base.OnTransitionIn(skipAnimation);

        ResetList();

        int i = 0;
        Button firstItem = null;
        foreach (CharacterProfileSO profile in characterProfiles) {
            if (!GameManager.instance.PlayerDataManager.CharacterInfoUnlockedIds.Contains(profile.Id)) { continue; }
            GameObject listItem = Instantiate(characterProfilePrefab, listContentParent.transform);
            CharacterListButton menuItem = listItem.GetComponent<CharacterListButton>();
            Button characterButton = menuItem.ButtonComponent;
            characterButton.onClick.AddListener(() => { OnCharacterClicked(characterButton); });
            menuItem.SetData(profile, i, characterProfiles.Count);
            if (i == 0) {
                firstItem = characterButton;
            }
            i++;
        }
        //Set the first item as selected
        if (firstItem != null) {
            firstItem.onClick.Invoke();
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstItem.gameObject);
        }
    }

    private void ResetList() {
        foreach (Transform child in listContentParent.transform) {
            Destroy(child.gameObject);
        }
    }

    public void OnCharacterClicked(Button button) {
        CharacterListButton menuItem = button.GetComponentInParent<CharacterListButton>();
        nameText.text = menuItem.profileData.characterName;
        characterPortrait.sprite = menuItem.profileData.portraitImage;
        ageText.text = menuItem.profileData.age;
        pronounsText.text = menuItem.profileData.pronouns;
        occupationText.text = menuItem.profileData.occupation;
        firstBioText.text = menuItem.profileData.firstBio;
        secondBioText.text = menuItem.profileData.secondBio;
    }
}
