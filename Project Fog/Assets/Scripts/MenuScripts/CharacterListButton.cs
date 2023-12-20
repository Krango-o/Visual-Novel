using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterListButton : MonoBehaviour {
    [SerializeField]
    public Button ButtonComponent;

    [SerializeField]
    private RectTransform TopEdgeTransform;
    [SerializeField]
    private Image TopEdgeImage;
    [SerializeField]
    private TextMeshProUGUI TopEdgeText;
    [SerializeField]
    private RectTransform RightEdgeTransform;
    [SerializeField]
    private Image RightEdgeImage;
    [SerializeField]
    private TextMeshProUGUI RightEdgeText;
    [SerializeField]
    private RectTransform LeftEdgeTransform;
    [SerializeField]
    private Image LeftEdgeImage;
    [SerializeField]
    private TextMeshProUGUI LeftEdgeText;
    [SerializeField]
    private RectTransform BottomEdgeRightTransform;
    [SerializeField]
    private Image BottomEdgeRightImage;
    [SerializeField]
    private TextMeshProUGUI BottomEdgeRightText;
    [SerializeField]
    private RectTransform BottomEdgeLeftTransform;
    [SerializeField]
    private Image BottomEdgeLeftImage;
    [SerializeField]
    private TextMeshProUGUI BottomEdgeLeftText;

    public CharacterProfileSO profileData;

    public void SetData(CharacterProfileSO profileDataSO, int index, int listSize) {
        profileData = profileDataSO;
        RectTransform activeBg = null;
        if(index == 0) {
            // Top list Image
            TopEdgeTransform.gameObject.SetActive(true);
            TopEdgeImage.sprite = profileData.listItemImage;
            activeBg = TopEdgeTransform;
            TopEdgeText.text = profileData.characterName;
        } else if(index < listSize - 1) {
            // Mid list Images
            if (index % 2 != 0) {
                RightEdgeTransform.gameObject.SetActive(true);
                RightEdgeImage.sprite = profileData.listItemImage;
                activeBg = RightEdgeTransform;
                RightEdgeText.text = profileData.characterName;
            } else {
                LeftEdgeTransform.gameObject.SetActive(true);
                LeftEdgeImage.sprite = profileData.listItemImage;
                activeBg = LeftEdgeTransform;
                LeftEdgeText.text = profileData.characterName;
            }
        } else {
            // Bottom list Images
            if (index % 2 != 0) {
                BottomEdgeRightTransform.gameObject.SetActive(true);
                BottomEdgeRightImage.sprite = profileData.listItemImage;
                activeBg = BottomEdgeRightTransform;
                BottomEdgeRightText.text = profileData.characterName;
            } else {
                BottomEdgeLeftTransform.gameObject.SetActive(true);
                BottomEdgeLeftImage.sprite = profileData.listItemImage;
                activeBg = BottomEdgeLeftTransform;
                BottomEdgeLeftText.text = profileData.characterName;
            }
        }
        if(activeBg != TopEdgeTransform) {
            TopEdgeTransform.gameObject.SetActive(false);
        }
        if (activeBg != RightEdgeTransform) {
            RightEdgeTransform.gameObject.SetActive(false);
        }
        if (activeBg != LeftEdgeTransform) {
            LeftEdgeTransform.gameObject.SetActive(false);
        }
        if (activeBg != BottomEdgeRightTransform) {
            BottomEdgeRightTransform.gameObject.SetActive(false);
        }
        if (activeBg != BottomEdgeLeftTransform) {
            BottomEdgeLeftTransform.gameObject.SetActive(false);
        }
    }
}
