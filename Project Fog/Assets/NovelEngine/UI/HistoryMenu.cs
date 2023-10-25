using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HistoryMenu : MonoBehaviour {
    [SerializeField]
    private RectTransform HistoryContainer;
    [SerializeField]
    private GameObject HistoryGroupPrefab;
    [SerializeField]
    private GameObject ScrollParent;
    [SerializeField]
    private AnimDialogueManager DialogueManager;
    [SerializeField]
    private ScrollRect ScrollRect;
    [SerializeField]
    private Image BlockerPanel;

    private int previousLine = -1;
    private float originalY = 0;
    private CanvasGroup canvasGroup;

    private void Start() {
        NovelManager.instance.EventManager.onResetVN.RemoveListener(ResetHistory);
        NovelManager.instance.EventManager.onResetVN.AddListener(ResetHistory);
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    public void ShowMenu() {
        canvasGroup.DOFade(1.0f, 0.2f);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        ScrollRect.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        BlockerPanel.DOFade(0.5f, 0.2f);
        HistoryContainer.anchoredPosition = new Vector2(HistoryContainer.anchoredPosition.x, originalY + 50);
        HistoryContainer.DOAnchorPosY(originalY, 0.2f);

        List<DialogueLine> lines = DialogueManager.GetLines();
        int currentLine = DialogueManager.GetCurrentLine();
        if(previousLine < currentLine)
        {
            previousLine += 1;
            for (int i = previousLine; i <= currentLine; i++)
            {
                GameObject group = GameObject.Instantiate<GameObject>(HistoryGroupPrefab, ScrollParent.transform);
                Text[] texts = group.GetComponentsInChildren<Text>();
                Text nameText = group.GetComponentsInChildren<Text>()[0];
                Text dialogueText = group.GetComponentsInChildren<Text>()[1];
                nameText.text = lines[i].Character;
                dialogueText.text = lines[i].Text;
            }
            previousLine = currentLine;
        }
        Canvas.ForceUpdateCanvases();
        ScrollParent.SetActive(false);
        StartCoroutine(ForceScrollDown());
    }

    public void HideMenu() {
        canvasGroup.DOFade(0.0f, 0.2f);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        ScrollRect.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        BlockerPanel.DOFade(0.0f, 0.2f);
        float endYPos = originalY - 50;
        HistoryContainer.DOAnchorPosY(endYPos, 0.2f).OnComplete(() => {
            HistoryContainer.anchoredPosition = new Vector2(HistoryContainer.anchoredPosition.x, originalY);
            NovelManager.instance.EventManager.Unpause();
        });
    }

    IEnumerator ForceScrollDown() {
        yield return new WaitForEndOfFrame();
        ScrollParent.SetActive(true);
        Canvas.ForceUpdateCanvases();
        yield return new WaitForEndOfFrame();
        ScrollRect.gameObject.SetActive(true);
        ScrollRect.verticalNormalizedPosition = 0f;
        ScrollRect.verticalScrollbar.value = 0;
        Canvas.ForceUpdateCanvases();
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            HideMenu();
        }
    }

    public void BackButton()
    {
        HideMenu();
    }

    private void ResetHistory() {
        foreach (Transform child in ScrollParent.transform) {
            Destroy(child.gameObject);
        }
    }
}
