using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class EscMenu : MonoBehaviour
{
    public Animator playerAnim;
    public static bool isPaused;
    public Animator anim;

    [SerializeField]
    private CinemachineVirtualCamera EscCamera;
    [SerializeField]
    private CinemachineVirtualCamera FollowCamera;
    [SerializeField]
    private float pauseCooldown = 0.5f;
    private float pauseTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.pauseGameEvent.AddListener(PauseGame);
        GameManager.instance.unpauseGameEvent.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        pauseTimer -= Time.deltaTime;
        if (pauseTimer > 0) { return; }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseTimer = pauseCooldown;
            if(isPaused)
            {
                GameManager.instance.unpauseGameEvent.Invoke();
            }
            else if(GameManager.instance.CurrentGameState != GameState.WORLDDIALOGUE)
            {
                GameManager.instance.pauseGameEvent.Invoke();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        anim.SetBool("Show", true);
        if (GameManager.instance.CurrentGameState == GameState.OVERWORLD) 
        {
            playerAnim.SetBool("isPaused" , true);
            EscCamera.m_Priority = 2;
            EscCamera.gameObject.transform.position = FollowCamera.gameObject.transform.position + (FollowCamera.gameObject.transform.right * 4.5f);
            EscCamera.gameObject.transform.rotation = FollowCamera.gameObject.transform.rotation;
        }
        GameManager.instance.SetState(GameState.PAUSEMENU);
    }

    public void ResumeGame()
    {
        isPaused = false;
        anim.SetBool("Show", false);
        if (GameManager.instance.PrevGameState == GameState.OVERWORLD) 
        {
            playerAnim.SetBool("isPaused", false);
            EscCamera.m_Priority = 0;
        }
        GameManager.instance.SetState(GameManager.instance.PrevGameState);
    }

    public void GoToMainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
