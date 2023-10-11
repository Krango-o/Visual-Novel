using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTriggerBox : MonoBehaviour
{
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera cam;
    [SerializeField]
    private bool followPlayer;

    private void Start()
    {
        cam.Follow = followPlayer ? GameManager.instance.Player.transform : null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            GameManager.instance.CameraTriggerManager.OnEnterCameraTrigger(this);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GameManager.instance.CameraTriggerManager.OnExitCameraTrigger(this);
        }
    }

    public void ActivateCamera() {
        cam.Priority = (int)CAMERA_PRIORITY.OVERRIDE;
    }

    public void DeactivateCamera() {
        cam.Priority = (int)CAMERA_PRIORITY.INACTIVE;
    }
}
