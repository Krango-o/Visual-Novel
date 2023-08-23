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
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseTimer -= Time.deltaTime;
        if (pauseTimer > 0) { return; }
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.CurrentGameState != GameState.WORLDDIALOGUE)
        {
            pauseTimer = pauseCooldown;
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        anim.SetBool("Show", true);
        playerAnim.SetBool("isPaused" , true);
        GameManager.instance.SetState(GameState.PAUSEMENU);
        isPaused = true;
        EscCamera.m_Priority = 2;
        EscCamera.gameObject.transform.position = FollowCamera.gameObject.transform.position + (FollowCamera.gameObject.transform.right * 4.5f);
        EscCamera.gameObject.transform.rotation = FollowCamera.gameObject.transform.rotation;
        GameManager.instance.pauseGameEvent.Invoke();
    }

    public void ResumeGame()
    {
        anim.SetBool("Show", false);
        playerAnim.SetBool("isPaused", false);
        GameManager.instance.SetState(GameManager.instance.PrevGameState);
        isPaused = false;
        EscCamera.m_Priority = 0;
        GameManager.instance.unpauseGameEvent.Invoke();
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
