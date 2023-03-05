using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    protected Image speechBubbleBg;
    [SerializeField]
    protected TextMeshProUGUI dialogueText;
    [SerializeField]
    protected RectTransform choices;
    [SerializeField]
    protected Image confirmBubble;
    [SerializeField]
    protected TextMeshProUGUI confirmText;
    [SerializeField]
    protected Image cancelBubble;
    [SerializeField]
    protected TextMeshProUGUI cancelText;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera npcCam;
    [SerializeField]
    private float camOffsetY = 2.0f;

    private Transform characterTransform;
    private Transform playerTransform;
    private RectTransform canvasRect;
    private bool showChoices = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasRect = this.GetComponent<RectTransform>();
        Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain)
    {
        if (characterTransform != null)
        {
            Vector3 targetPos = new Vector3(characterTransform.position.x, characterTransform.position.y + camOffsetY, characterTransform.position.z);
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(targetPos);

            speechBubbleBg.rectTransform.position = new Vector3(viewportPoint.x * canvasRect.sizeDelta.x, viewportPoint.y * canvasRect.sizeDelta.y, 0) * canvasRect.localScale.x;
        }
        if (playerTransform != null)
        {
            Vector3 targetPos = new Vector3(playerTransform.position.x, playerTransform.position.y + camOffsetY - 1.0f, playerTransform.position.z);
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(targetPos);

            choices.position = new Vector3(viewportPoint.x * canvasRect.sizeDelta.x, viewportPoint.y * canvasRect.sizeDelta.y, 0) * canvasRect.localScale.x;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && showChoices && !GameManager.instance.interactDisabled)
        {
            confirmBubble.rectTransform.localScale = new Vector3(0.01f, 0.01f);
            confirmBubble.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 0.4f);
            confirmBubble.GetComponent<CanvasGroup>().DOFade(1.0f, 0.4f);
            confirmBubble.GetComponent<Button>().Select();
            cancelBubble.rectTransform.localScale = new Vector3(0.01f, 0.01f);
            cancelBubble.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 0.4f).OnComplete( () =>
            {
                confirmBubble.GetComponent<Button>().interactable = true;
                cancelBubble.GetComponent<Button>().interactable = true;
            });
            cancelBubble.GetComponent<CanvasGroup>().DOFade(1.0f, 0.4f);
            showChoices = false;
        }
    }

    public void ShowSpeechBubble(string dialogue, Transform characterTransform, string confirmString = "", string cancelString = "")
    {
        speechBubbleBg.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        dialogueText.SetText(dialogue);
        if(confirmString != "" && cancelString != "")
        {
            confirmText.SetText(confirmString);
            cancelText.SetText(cancelString);
            showChoices = true;
            confirmBubble.GetComponent<Button>().Select();
            confirmBubble.GetComponent<Button>().interactable = false;
            cancelBubble.GetComponent<Button>().interactable = false;
            GameManager.instance.DelayInteract();
        }
        speechBubbleBg.rectTransform.localScale = new Vector3(0.01f, 0.01f);
        speechBubbleBg.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 0.4f);
        this.characterTransform = characterTransform;
        GameManager.instance.NPCCam.Follow = characterTransform;
        GameManager.instance.NPCCam.LookAt = characterTransform;
        GameManager.instance.NPCCam.Priority = 2;
        Cinemachine.CinemachineOrbitalTransposer npcOrbitalCam = GameManager.instance.NPCCam.GetCinemachineComponent<Cinemachine.CinemachineOrbitalTransposer>();
        npcOrbitalCam.m_XAxis.Value = GameManager.instance.Player.GetCameraAxisPosition();
        playerTransform = GameManager.instance.Player.transform;
        LayoutRebuilder.ForceRebuildLayoutImmediate(speechBubbleBg.rectTransform);
    }

    public void HideSpeechBubble()
    {
        speechBubbleBg.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        speechBubbleBg.rectTransform.DOScale(0.0f, 0.4f).OnComplete(() => {
            characterTransform = null;
        });
        GameManager.instance.NPCCam.Priority = 0;
        confirmBubble.GetComponent<CanvasGroup>().DOFade(0.0f, 0.2f);
        cancelBubble.GetComponent<CanvasGroup>().DOFade(0.0f, 0.2f);
        confirmBubble.rectTransform.DOScale(0.0f, 0.4f).OnComplete(() => {
            playerTransform = null;
        }); ;
        cancelBubble.rectTransform.DOScale(0.0f, 0.4f);
    }

    public void ConfirmBubble()
    {
        GameManager.instance.confirmChoiceEvent.Invoke();
        confirmBubble.GetComponent<Button>().interactable = false;
        cancelBubble.GetComponent<Button>().interactable = false;
    }

    public void CancelBubble()
    {
        GameManager.instance.cancelChoiceEvent.Invoke();
        confirmBubble.GetComponent<Button>().interactable = false;
        cancelBubble.GetComponent<Button>().interactable = false;
    }
}