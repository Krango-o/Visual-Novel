using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[System.Serializable]
public class SpeechBubbleUnityEvent : UnityEvent<string, string, string> { }

public enum GameState { OVERWORLD, NOVEL, WORLDDIALOGUE, PAUSEMENU }

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool interactDisabled { get; set; }

    public UnityEvent pauseGameEvent = new UnityEvent();
    public UnityEvent unpauseGameEvent = new UnityEvent();
    public UnityEvent confirmChoiceEvent = new UnityEvent();
    public UnityEvent cancelChoiceEvent = new UnityEvent();
    private GameState currentGameState;
    public GameState CurrentGameState { get { return currentGameState; } }
    private GameState prevGameState;
    public GameState PrevGameState { get { return prevGameState; } }
    private PlayerController player;
    public PlayerController Player { get { return player; } set { player = value; } }
    private Cinemachine.CinemachineVirtualCamera playerCam;
    public Cinemachine.CinemachineVirtualCamera PlayerCam { get { return playerCam; } set { playerCam = value; } }
    private Cinemachine.CinemachineVirtualCamera npcCam;
    public Cinemachine.CinemachineVirtualCamera NPCCam { get { return npcCam; } set { npcCam = value; } }
    private Cinemachine.CinemachineBrain cameraBrain;
    public Cinemachine.CinemachineBrain CameraBrain { get { return cameraBrain; } set { cameraBrain = value; } }
    public Vector3 ActiveCameraForward { get { return cameraBrain.ActiveVirtualCamera.VirtualCameraGameObject.transform.forward; } }
    public AnimDialogueManager DialogueManager { get { return dialogueManager; } }
    private AnimDialogueManager dialogueManager;

    private void Awake()
    {
        if (instance == null)
        {
            //Starting up the game
            instance = this;
            if (GameObject.Find("Player") != null)
            {
                player = GameObject.Find("Player").GetComponent<PlayerController>();
            }
            currentGameState = GameState.OVERWORLD;
            playerCam = GameObject.Find("FollowCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            npcCam = GameObject.Find("NPCCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            cameraBrain = GameObject.Find("FollowCam").GetComponent<Cinemachine.CinemachineBrain>();
            dialogueManager = GameObject.Find("NovelCanvas").GetComponent<AnimDialogueManager>();
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        interactDisabled = false;
    }

    // Used for preventing players from spamming through interactions/dialogue
    public void DelayInteract()
    {
        interactDisabled = true;
        DOVirtual.DelayedCall(0.5f, () =>
        {
            interactDisabled = false;
        });
    }

    public void SetState(GameState newState) {
        prevGameState = currentGameState;
        currentGameState = newState;
    }
}