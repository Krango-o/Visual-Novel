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
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CameraBrain.ActiveVirtualCamera.Priority = 0;
            cam.Priority = 1;
        }
    }
}
