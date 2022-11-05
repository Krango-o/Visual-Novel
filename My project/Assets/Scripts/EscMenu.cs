using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public Animator playerAnim;
    public static bool isPaused;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
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
        GameManager.instance.characterDisabled = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        anim.SetBool("Show", false);
        playerAnim.SetBool("isPaused", false);
        GameManager.instance.characterDisabled = false;
        isPaused = false;
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
