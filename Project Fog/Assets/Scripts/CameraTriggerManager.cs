using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CAMERA_PRIORITY {
    INACTIVE = 0,
    DEFAULT = 1,
    OVERRIDE = 2,
    PAUSE = 3
}

public class CameraTriggerManager : MonoBehaviour
{
    private List<CameraTriggerBox> triggerList;

    // Start is called before the first frame update
    void Start()
    {
        triggerList = new List<CameraTriggerBox>();
    }

    public void OnEnterCameraTrigger(CameraTriggerBox trigger) {
        foreach(CameraTriggerBox triggerItem in triggerList) {
            triggerItem.DeactivateCamera();
        }
        trigger.ActivateCamera();
        triggerList.Add(trigger);
    }

    public void OnExitCameraTrigger(CameraTriggerBox trigger) {
        if (triggerList.Contains(trigger)) {
            trigger.DeactivateCamera();
            triggerList.Remove(trigger);
        }
        if(triggerList.Count > 0) {
            triggerList[triggerList.Count - 1].ActivateCamera();
        }
    }
}
