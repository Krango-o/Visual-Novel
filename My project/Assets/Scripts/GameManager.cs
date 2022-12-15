using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool characterDisabled { get; set; }

    public UnityEvent pauseGameEvent = new UnityEvent();
    public UnityEvent unpauseGameEvent = new UnityEvent();

    private void Awake()
    {
        if (instance == null)
        {
            //Starting up the game
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        characterDisabled = false;
    }
}