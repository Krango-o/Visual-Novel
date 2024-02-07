using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TMPro;

public class GeneralPopupData {
    public string title = "";
    public string description = "";
    public string cancelString = "Cancel";
    public string confirmString = "Confirm";
    public Action confirmCallback = null;
    public Action cancelCallback = null;
}

public class GeneralPopup : MonoBehaviour {
    [SerializeField]
    CanvasGroup canvasGroup;

    [SerializeField]
    RectTransform boxContainer;
    [SerializeField]
    CanvasGroup boxCanvasGroup;

    [SerializeField]
    TextMeshProUGUI titleText;
    [SerializeField]
    TextMeshProUGUI descriptionText;
    [SerializeField]
    TextMeshProUGUI cancelText;
    [SerializeField]
    TextMeshProUGUI confirmText;

    private GeneralPopupData popupData;
    private float startPosition = 0;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        startPosition = boxContainer.anchoredPosition.y;
    }

    public void ShowPopup(GeneralPopupData popupData) {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1.0f, 0.2f);

        boxCanvasGroup.alpha = 0;
        boxCanvasGroup.DOFade(1.0f, 0.2f);
        boxContainer.anchoredPosition = new Vector2(boxContainer.anchoredPosition.x, startPosition - 50);
        boxContainer.DOAnchorPosY(startPosition, 0.4f);

        this.popupData = popupData;

        titleText.text = popupData.title;
        descriptionText.text = popupData.description;
        cancelText.text = popupData.cancelString;
        confirmText.text = popupData.confirmString;

        GameManager.instance.SetState(GameState.POPUP);
    }

    public void ClosePopup() {
        canvasGroup.DOFade(0.0f, 0.2f).OnComplete(() => {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            GameManager.instance.SetState(GameManager.instance.PrevGameState);
            Destroy(gameObject);
        });
    }

    public void OnConfirm() {
        if(popupData.confirmCallback != null) {
            popupData.confirmCallback.Invoke();
        }
        ClosePopup();
    }

    public void OnCancel() {
        if(popupData.cancelCallback != null) {
            popupData.cancelCallback.Invoke();
        }
        ClosePopup();
    }
}

public static class PopupManager {
    public static void ShowPopup(GeneralPopupData popupData) {
        GeneralPopup popup = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/GeneralPopup")).GetComponent<GeneralPopup>();
        popup.ShowPopup(popupData);
    }
}
