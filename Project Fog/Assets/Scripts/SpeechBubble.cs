using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

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
    private bool queueShowChoices = false;
    private bool choicesVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasRect = this.GetComponent<RectTransform>();
        Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain)
    {
        Vector2 playerViewportPoint = Vector2.zero;
        if (playerTransform != null) {
            Vector3 targetPos = new Vector3(playerTransform.position.x, playerTransform.position.y + camOffsetY - 1.0f, playerTransform.position.z);
            playerViewportPoint = Camera.main.WorldToViewportPoint(targetPos);

            choices.position = new Vector3(playerViewportPoint.x * canvasRect.sizeDelta.x - 10, playerViewportPoint.y * canvasRect.sizeDelta.y + 20, 0) * canvasRect.localScale.x;
        }
        if (characterTransform != null) {
            Vector3 targetPos = new Vector3(characterTransform.position.x, characterTransform.position.y + camOffsetY, characterTransform.position.z);
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(targetPos);
            float direction = 1f;
            if(playerTransform != null) {
                direction = (viewportPoint - playerViewportPoint).x > 0 ? 1f : -1f;
                speechBubbleBg.rectTransform.localScale = new Vector3(direction, 1f);
                dialogueText.rectTransform.localScale = new Vector3(direction, 1f);
            }
            speechBubbleBg.rectTransform.position = new Vector3(viewportPoint.x * canvasRect.sizeDelta.x + (60 * direction), viewportPoint.y * canvasRect.sizeDelta.y - 140, 0) * canvasRect.localScale.x;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && queueShowChoices && !GameManager.instance.InteractDisabled)
        {
            confirmBubble.rectTransform.localScale = new Vector3(0.01f, 0.01f);
            confirmBubble.rectTransform.DOScale(new Vector3(-1.0f, 1.0f), 0.4f);
            CanvasGroup confirmCanvasGroup = confirmBubble.GetComponent<CanvasGroup>();
            confirmCanvasGroup.DOFade(1.0f, 0.4f).onComplete = () => {
                confirmCanvasGroup.interactable = true;
                confirmCanvasGroup.blocksRaycasts = true;
            };
            cancelBubble.rectTransform.localScale = new Vector3(0.01f, 0.01f);
            cancelBubble.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 0.4f).OnComplete( () =>
            {
                confirmBubble.GetComponent<Button>().interactable = true;
                cancelBubble.GetComponent<Button>().interactable = true;
                choicesVisible = true;
                confirmBubble.GetComponent<Button>().Select();
            });
            CanvasGroup cancelCanvasGroup = cancelBubble.GetComponent<CanvasGroup>();
            cancelCanvasGroup.DOFade(1.0f, 0.4f).onComplete = () => {
                cancelCanvasGroup.interactable = true;
                cancelCanvasGroup.blocksRaycasts = true;
            };
            queueShowChoices = false;
        }
        if (choicesVisible && EventSystem.current.currentSelectedGameObject == null && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f) {
            if(Input.GetAxis("Horizontal") > 0) {
                EventSystem.current.SetSelectedGameObject(cancelBubble.gameObject);
            } else {
                EventSystem.current.SetSelectedGameObject(confirmBubble.gameObject);
            }
        }
    }

    public void ShowSpeechBubble(string dialogue, Transform characterTransform, string confirmString = "", string cancelString = "")
    {
        speechBubbleBg.GetComponent<CanvasGroup>().alpha = 0;
        speechBubbleBg.GetComponent<CanvasGroup>().DOFade(1, 0.2f).SetDelay(0.4f);
        dialogueText.SetText(dialogue);
        if(confirmString != "" && cancelString != "")
        {
            confirmText.SetText(confirmString);
            cancelText.SetText(cancelString);
            queueShowChoices = true;
            confirmBubble.GetComponent<Button>().Select();
            confirmBubble.GetComponent<Button>().interactable = false;
            cancelBubble.GetComponent<Button>().interactable = false;
            GameManager.instance.DelayInteract();
        }
        this.characterTransform = characterTransform;
        GameManager.instance.NPCCam.Follow = characterTransform;
        GameManager.instance.NPCCam.LookAt = characterTransform;
        GameManager.instance.NPCCam.Priority = (int)CAMERA_PRIORITY.OVERRIDE;
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
        GameManager.instance.NPCCam.Priority = (int)CAMERA_PRIORITY.INACTIVE;
        CanvasGroup confirmCanvasGroup = confirmBubble.GetComponent<CanvasGroup>();
        confirmCanvasGroup.interactable = false;
        confirmCanvasGroup.blocksRaycasts = false;
        confirmCanvasGroup.DOFade(0.0f, 0.2f);
        CanvasGroup cancelCanvasGroup = cancelBubble.GetComponent<CanvasGroup>();
        cancelCanvasGroup.interactable = false;
        cancelCanvasGroup.blocksRaycasts = false;
        cancelCanvasGroup.DOFade(0.0f, 0.2f);
        confirmBubble.rectTransform.DOScale(0.0f, 0.4f).OnComplete(() => {
            playerTransform = null;
        }); ;
        cancelBubble.rectTransform.DOScale(0.0f, 0.4f);
        choicesVisible = false;
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
