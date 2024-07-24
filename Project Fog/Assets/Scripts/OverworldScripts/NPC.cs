using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NPC : Interactable {
    [Header("NPC")]
    [SerializeField]
    private string shortDialogue;
    [SerializeField]
    private TextAsset vnSceneObject;
    [SerializeField]
    private string confirmChoiceString;
    [SerializeField]
    private string cancelChoiceString;
    [SerializeField]
    private Transform spriteHolder;
    [SerializeField]
    private Transform sprite;

    [Header("Lost Item")]
    [SerializeField]
    private LostItemSO LostItemRequired;
    [SerializeField]
    private TextAsset LostItemVNScene;

    [Header("Load Scene")]
    [SerializeField]
    private SpawnPointSO NextSceneSpawnPoint;
    [SerializeField]
    private bool SpawnAfterLostItem;

    private bool canInteract;
    private bool speechOpen = false;
    private SpeechBubble speechBubble;

    // Start is called before the first frame update
    void Start()
    {
        speechBubble = GameObject.Find("SpeechbubbleCanvas").GetComponent<SpeechBubble>();
        Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
        interactionHint.SetInteractionType(InteractionType.TALKNEW);
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain)
    {
        //Make sprite constantly look at camera
        spriteHolder.forward = Camera.main.transform.forward;
    }

    public override void Interact() {
        base.Interact();
        if (!isInteracting) {
            // If the speech bubble is already open, close it. Delay interact
            if (speechOpen && vnSceneObject == null) {
                onCloseBubble();
            }
            // If the player can interact then we can show the speech bubble
            if (GameManager.instance.CurrentGameState == GameState.OVERWORLD && canInteract) {
                if (!speechOpen) {
                    if(LostItemRequired != null && LostItemVNScene != null && 
                            GameManager.instance.PlayerDataManager.CheckIfItemUnlocked(LostItemRequired) && 
                            !NovelManager.instance.CheckIfDialogueCompleted(LostItemVNScene)) {
                        SpawnPointSO nextScene = SpawnAfterLostItem ? NextSceneSpawnPoint : null;
                        StartVNScene(LostItemVNScene, nextScene);
                        return;
                    }
                    // Show the speech bubble here. Get rid of the interact icon for now and disable character movement
                    speechBubble.ShowSpeechBubble(shortDialogue, gameObject.transform, confirmChoiceString, cancelChoiceString);
                    interactionHint.SetVisible(false);
                    GameManager.instance.SetState(GameState.WORLDDIALOGUE);
                    speechOpen = true;
                    GameManager.instance.DelayInteract();
                    GameManager.instance.confirmChoiceEvent.AddListener(OnConfirmBubble);
                    GameManager.instance.cancelChoiceEvent.AddListener(OnCancelBubble);
                }
            }
        }
    }

    protected override void ToggleClosest(bool isClosest) {
        base.ToggleClosest(isClosest);
        if (isClosest) {
            canInteract = true;
            UpdateInteractionHint();
        } else {
            canInteract = false;
        }
    }

    private void UpdateInteractionHint() {
        //Lost Item
        if (LostItemRequired != null && LostItemVNScene != null &&
                            GameManager.instance.PlayerDataManager.CheckIfItemUnlocked(LostItemRequired) &&
                            !NovelManager.instance.CheckIfDialogueCompleted(LostItemVNScene)) {
            interactionHint.SetInteractionType(InteractionType.TALKGIFT);
        }
        //Already Read
        else if (vnSceneObject != null && NovelManager.instance.CheckIfDialogueCompleted(vnSceneObject)) {
            interactionHint.SetInteractionType(InteractionType.TALKOLD);
        }
        //New Text
        else {
            interactionHint.SetInteractionType(InteractionType.TALKNEW);
        }
    }

    private void onCloseBubble()
    {
        speechOpen = false;
        speechBubble.HideSpeechBubble();
        interactionHint.SetVisible(true);
        GameManager.instance.SetState(GameState.OVERWORLD);
        GameManager.instance.DelayInteract();
        GameManager.instance.confirmChoiceEvent.RemoveListener(OnConfirmBubble);
        GameManager.instance.cancelChoiceEvent.RemoveListener(OnCancelBubble);
    }

    private void StartVNScene(TextAsset vnScene, SpawnPointSO nextScene = null) {
        GameManager.instance.DelayInteract();
        GameManager.instance.DialogueManager.LoadDialogue(vnScene, nextScene);
        GameManager.instance.SetState(GameState.NOVEL);
    }

    public void OnConfirmBubble()
    {
        if (vnSceneObject != null)
        {
            speechOpen = false;
            speechBubble.HideSpeechBubble();
            GameManager.instance.confirmChoiceEvent.RemoveListener(OnConfirmBubble);
            GameManager.instance.cancelChoiceEvent.RemoveListener(OnCancelBubble);
            SpawnPointSO nextScene = SpawnAfterLostItem ? null : NextSceneSpawnPoint;
            StartVNScene(vnSceneObject, nextScene);
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

    public void ChangeVNSceneId(TextAsset newVNTextAsset) {
        vnSceneObject = newVNTextAsset;
    }
}
