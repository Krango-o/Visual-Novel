using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    [Header("Interactable")]
    [SerializeField]
    protected GameObject closeIndicator;
    protected bool inRange = false;
    protected bool isClosest = false;
    protected bool isInteracting = false;

    //[Header("Quest")]
    //[SerializeField]
    //private QuestInfoSO questInfo;
    //[SerializeField]
    //private bool startPoint = false;
    //[SerializeField]
    //private bool finishPoint = false;
    //private string questId;
    //private QuestState currentQuestState;

    private void Awake() {
        //if (questInfo != null) {
        //    questId = questInfo.id;
        //}
    }

    //private void OnEnable() {
    //    GameManager.instance.EventsManager.onQuestStateChange.AddListener(QuestStateChange);
    //}

    //private void OnDisable() {
    //    GameManager.instance.EventsManager.onQuestStateChange.RemoveListener(QuestStateChange);
    //}

    //private void QuestStateChange(Quest quest) {
    //    if (quest.info.id.Equals(questId)) {
    //        currentQuestState = quest.state;
    //        Debug.Log("Quest with id: " + questId + " updated to state: " + currentQuestState);
    //    }
    //}

    // Update is called once per frame
    void Update() {
        if (inRange && !isInteracting) {
            // Checking if isClosest is changing so we don't change it every frame for animation purposes
            if (!isClosest && GameManager.instance.GetClosestInteractable() == this.gameObject) {
                ToggleClosest(true);
            } else if (isClosest && GameManager.instance.GetClosestInteractable() != this.gameObject) {
                ToggleClosest(false);
            }
        }
    }

    public virtual void Interact() {
        //if (!isInteracting && questInfo != null) {
        //    if (currentQuestState.Equals(QuestState.CAN_START) && startPoint) {
        //        GameManager.instance.EventsManager.StartQuest(questId);
        //    } else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint) {
        //        GameManager.instance.EventsManager.FinishQuest(questId);
        //    }
        //}
    }

    public virtual void EndInteract() {
        isInteracting = false;
    }

    protected virtual void ToggleClosest(bool isClosest) {
        this.isClosest = isClosest;
        closeIndicator.SetActive(isClosest);
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.CompareTag(GameManager.instance.Player.gameObject.tag)) {
            GameManager.instance.AddInteractable(this.gameObject);
            inRange = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other) {
        if (other.CompareTag(GameManager.instance.Player.gameObject.tag)) {
            GameManager.instance.RemoveInteractable(this.gameObject);
            inRange = false;
            ToggleClosest(false);
        }
    }
}