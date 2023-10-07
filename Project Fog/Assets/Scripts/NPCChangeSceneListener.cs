using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChangeSceneListener : MonoBehaviour {
    [SerializeField]
    private TextAsset VNSceneIdToListenTo;
    [SerializeField]
    private TextAsset VNSceneIdToChangeTo;

    private NPC npcComponent;

    // Start is called before the first frame update
    void Start()
    {
        npcComponent = this.gameObject.GetComponent<NPC>();
        GameManager.instance.vnSceneEnded.AddListener(OnVNSceneEnd);
    }

    private void OnVNSceneEnd(string lastSceneEnded) {
        if(VNSceneIdToListenTo.name == lastSceneEnded) {
            npcComponent.ChangeVNSceneId(VNSceneIdToChangeTo);
        }
    }
}
