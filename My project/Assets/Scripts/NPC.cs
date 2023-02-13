using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private string DialogueId;
    [SerializeField]
    private string startVNScene;
    [SerializeField]
    private string confirmChoiceString;
    [SerializeField]
    private string cancelChoiceString;
    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private GameObject speakIcon;

    private bool canInteract;
    private bool speechOpen = false;
    private SpeechBubble speechBubble;
    private AnimDialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        speakIcon.SetActive(false);
        speechBubble = GameObject.Find("SpeechbubbleCanvas").GetComponent<SpeechBubble>();
        Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
        dialogueManager = GameObject.Find("NovelCanvas").GetComponent<AnimDialogueManager>();
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain)
    {
        //Make sprite constantly look at camera
        sprite.forward = Camera.main.transform.forward;
        speakIcon.transform.forward = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            // If the speech bubble is already open, close it. Delay interact
            if (!GameManager.instance.interactDisabled && speechOpen && startVNScene == "")
            {
                onCloseBubble();
            }
            // If the player can interact then we can show the speech bubble
            if (!GameManager.instance.interactDisabled && !GameManager.instance.characterDisabled && canInteract)
            {
                if(!speechOpen)
                {
                    // Show the speech bubble here. Get rid of the interact icon for now and disable character movement
                    speechBubble.ShowSpeechBubble(DialogueId, gameObject.transform, confirmChoiceString, cancelChoiceString);
                    speakIcon.transform.DOScale(0.00f, 0.2f).SetEase(Ease.OutQuad);
                    GameManager.instance.characterDisabled = true;
                    speechOpen = true;
                    GameManager.instance.DelayInteract();
                    GameManager.instance.confirmChoiceEvent.AddListener(OnConfirmBubble);
                    GameManager.instance.cancelChoiceEvent.AddListener(OnCancelBubble);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if(pc != null)
        {
            canInteract = true;
            speakIcon.SetActive(true);
            speakIcon.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            speakIcon.transform.DOScale(1.0f, 0.2f).SetEase(Ease.OutQuad);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            canInteract = false;
            speakIcon.SetActive(false);
        }
    }

    private void onCloseBubble()
    {
        speechOpen = false;
        speechBubble.HideSpeechBubble();
        speakIcon.transform.DOScale(1.0f, 0.2f).SetEase(Ease.OutQuad);
        GameManager.instance.characterDisabled = false;
        GameManager.instance.DelayInteract();
        GameManager.instance.confirmChoiceEvent.RemoveListener(OnConfirmBubble);
        GameManager.instance.cancelChoiceEvent.RemoveListener(OnCancelBubble);
    }

    public void OnConfirmBubble()
    {
        if (startVNScene != "")
        {
            speechOpen = false;
            speechBubble.HideSpeechBubble();
            GameManager.instance.DelayInteract();
            GameManager.instance.confirmChoiceEvent.RemoveListener(OnConfirmBubble);
            GameManager.instance.cancelChoiceEvent.RemoveListener(OnCancelBubble);
            dialogueManager.LoadDialogue(startVNScene);
            GameManager.instance.characterDisabled = true;
        }
        else
        {
            onCloseBubble();
        }
    }
    public void OnCancelBubble()
    {
        onCloseBubble();
    }
}
