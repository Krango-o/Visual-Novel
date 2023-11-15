using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class EscMenu : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private RectTransform contentContainer;
    [SerializeField]
    private CanvasGroup inputBlocker;

    [SerializeField]
    private float pauseCooldown = 0.5f;
    private float pauseTimer = 0.0f;

    private float endPosY = 0;

    private Animator playerAnim;
    private CinemachineVirtualCamera EscCamera;
    private CinemachineVirtualCamera FollowCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.pauseGameEvent.AddListener(PauseGame);
        GameManager.instance.unpauseGameEvent.AddListener(ResumeGame);
        playerAnim = GameManager.instance.Player.GetAnimator();
        EscCamera = GameObject.Find("EscCamera").GetComponent<CinemachineVirtualCamera>();
        FollowCamera = GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        contentContainer.anchoredPosition = new Vector2(contentContainer.anchoredPosition.x, GetOffScreenPosition());
    }

    // Update is called once per frame
    void Update()
    {
        pauseTimer -= Time.deltaTime;
        if (pauseTimer > 0) { return; }
        if (Input.GetButtonDown("Cancel"))
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
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        inputBlocker.DOFade(1, 0.2f);
        contentContainer.localScale = new Vector3(0.6f, 0.6f, 1.0f);
        contentContainer.DOScale(new Vector3(1, 1, 1), 0.4f);
        contentContainer.DOAnchorPosY(0, 0.4f).SetEase(Ease.OutBack);
        if (GameManager.instance.CurrentGameState == GameState.OVERWORLD) 
        {
            playerAnim.SetBool("isPaused" , true);
            //EscCamera.m_Priority = (int)CAMERA_PRIORITY.PAUSE;
            //EscCamera.gameObject.transform.position = FollowCamera.gameObject.transform.position + (FollowCamera.gameObject.transform.right * 4.5f);
            //EscCamera.gameObject.transform.rotation = FollowCamera.gameObject.transform.rotation;
        }
        GameManager.instance.SetState(GameState.PAUSEMENU);
    }

    public void ResumeGame()
    {
        isPaused = false;
        canvasGroup.interactable = false;
        contentContainer.DOAnchorPosY(GetOffScreenPosition(), 0.2f).SetEase(Ease.OutBack);
        inputBlocker.DOFade(0, 0.2f).onComplete = () => {
            canvasGroup.alpha = 0;
            if (GameManager.instance.PrevGameState == GameState.OVERWORLD) {
                playerAnim.SetBool("isPaused", false);
                //EscCamera.m_Priority = (int)CAMERA_PRIORITY.INACTIVE;
            }
            GameManager.instance.SetState(GameManager.instance.PrevGameState);
        };
    }

    private float GetOffScreenPosition() {
        float endPos = canvas.pixelRect.height / 2;
        endPos = (contentContainer.rect.height / 2) + endPos;
        endPos *= -1;
        return endPos;
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
