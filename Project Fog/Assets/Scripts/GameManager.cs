using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

[System.Serializable]
public class SpeechBubbleUnityEvent : UnityEvent<string, string, string> { }

public enum GameState { OVERWORLD, NOVEL, WORLDDIALOGUE, PAUSEMENU, POPUP }

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool InteractDisabled { get; set; }
    public string SpawnPointToLoad { get; private set; }

    public UnityEvent pauseGameEvent = new UnityEvent();
    public UnityEvent unpauseGameEvent = new UnityEvent();
    public UnityEvent confirmChoiceEvent = new UnityEvent();
    public UnityEvent cancelChoiceEvent = new UnityEvent();
    public UnityEvent<string> vnSceneEnded = new UnityEvent<string>();
    public UnityEvent<LostItemSO> lostItemUnlocked = new UnityEvent<LostItemSO>();
    public UnityEvent<LostItemSO> lostItemCompleted = new UnityEvent<LostItemSO>();
    public UnityEvent<string> characterDataUnlocked = new UnityEvent<string>();

    public GameState CurrentGameState { get; private set; }
    public GameState PrevGameState { get; private set; }
    public PlayerController Player { get; private set; }
    public Cinemachine.CinemachineVirtualCamera PlayerCam { get; private set; }
    public Cinemachine.CinemachineVirtualCamera NPCCam { get; private set; }
    public Cinemachine.CinemachineBrain CameraBrain { get; private set; }
    public Vector3 ActiveCameraForward { get { return CameraBrain.ActiveVirtualCamera.VirtualCameraGameObject.transform.forward; } }
    public AnimDialogueManager DialogueManager { get; private set; }
    public CameraTriggerManager CameraTriggerManager { get; private set; }
    public DataPersistenceManager DataPersistenceManager { get; private set; }
    public NPCManager NPCManager { get; private set; }
    public PlayerDataManager PlayerDataManager { get; private set; }
    public AudioManager AudioManager { get; private set; }

    private List<GameObject> interactablesList;

    [SerializeField]
    private GameObject LoadingPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            //Starting up the game
            instance = this;
            CurrentGameState = GameState.OVERWORLD;
            Setup();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InteractDisabled = false;
    }

    private void Update() {
        if (interactablesList.Count > 1) {
            interactablesList.Sort((a, b) => {
                return Vector3.Distance(a.transform.position, Player.transform.position).CompareTo(Vector3.Distance(b.transform.position, Player.transform.position));
            });
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Setup();
    }

    private void Setup() {
        PlayerCam = GameObject.Find("FollowCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        NPCCam = GameObject.Find("NPCCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        CameraBrain = GameObject.Find("FollowCam").GetComponent<Cinemachine.CinemachineBrain>();
        DialogueManager = GameObject.Find("NovelCanvas").GetComponent<AnimDialogueManager>();
        CameraTriggerManager = gameObject.GetComponent<CameraTriggerManager>();
        DataPersistenceManager = gameObject.GetComponent<DataPersistenceManager>();
        NPCManager = gameObject.GetComponent<NPCManager>();
        PlayerDataManager = gameObject.GetComponent<PlayerDataManager>();
        AudioManager = gameObject.GetComponent<AudioManager>();
        if (GameObject.Find("Player") != null) {
            Player = GameObject.Find("Player").GetComponent<PlayerController>();
        }
        interactablesList = new List<GameObject>();
    }

    // Used for preventing players from spamming through interactions/dialogue
    public void DelayInteract()
    {
        InteractDisabled = true;
        DOVirtual.DelayedCall(0.5f, () =>
        {
            InteractDisabled = false;
        });
    }

    public void SetState(GameState newState) {
        PrevGameState = CurrentGameState;
        CurrentGameState = newState;
    }

    public void LoadScene(SpawnPointSO spawnPointSO = null) {
        SpawnPointToLoad = spawnPointSO.Id;
        //SceneManager.LoadScene(spawnPointSO.sceneToLoad.Name);

        LoadingScreen loadingScreen = GameObject.Instantiate(LoadingPrefab).GetComponent<LoadingScreen>();
        Tween transitionTween = loadingScreen.TransitionIn();
        transitionTween.OnComplete(() => {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(spawnPointSO.sceneToLoad.Name);
            loadingScreen.StartLoading(loadOperation);
        });
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAdditive(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void AddInteractable(GameObject interactable) {
        if (!interactablesList.Contains(interactable)) {
            interactablesList.Add(interactable);
        }
    }

    public void RemoveInteractable(GameObject interactable) {
        if (interactablesList.Contains(interactable)) {
            interactablesList.Remove(interactable);
        }
    }

    public GameObject GetClosestInteractable() {
        if (interactablesList.Count > 0) {
            return interactablesList[0];
        }
        return null;
    }

    public void PauseGame() {
        if(pauseGameEvent != null) {
            pauseGameEvent.Invoke();
        }
    }

    public void UnpauseGame() {
        if (unpauseGameEvent != null) {
            unpauseGameEvent.Invoke();
        }
    }

    public void UnlockLostItem(LostItemSO lostItem) {
        if(lostItemUnlocked != null) {
            lostItemUnlocked.Invoke(lostItem);
        }
    }

    public void CompleteLostItem(LostItemSO lostItem) {
        if (lostItemCompleted != null) {
            lostItemCompleted.Invoke(lostItem);
        }
    }

    public void UnlockCharacterData(string characterId) {
        if (characterDataUnlocked != null) {
            characterDataUnlocked.Invoke(characterId);
        }
    }
}