using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour {
    [SerializeField]
    private SpawnPointSO spawnPointSO;
    [SerializeField]
    private GameObject referenceSphere;

    private void Awake() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start() {
        referenceSphere.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (GameManager.instance.SpawnPointToLoad == spawnPointSO.Id) {
            // MUST disable the character controller in order to position the player 
            GameManager.instance.Player.gameObject.GetComponent<CharacterController>().enabled = false;

            Vector3 newPosition = transform.position;
            GameManager.instance.Player.transform.position = newPosition;

            GameManager.instance.Player.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}
