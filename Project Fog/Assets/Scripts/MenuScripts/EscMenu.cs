using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public enum ESC_SCREEN { MAINMENU, CHARACTERMENU, LOSTITEMSMENU, DATAMENU, SETTINGSMENU }

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
    private RawImage patternBg;

    [SerializeField]
    private RectTransform mainMenu;
    [SerializeField]
    private RectTransform characterMenu;
    [SerializeField]
    private RectTransform lostItemsMenu;
    [SerializeField]
    private RectTransform dataMenu;
    [SerializeField]
    private RectTransform settingsMenu;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private float pauseCooldown = 0.5f;
    private float pauseTimer = 0.0f;

    private float endPosY = 0;

    private Vector2 patternSpeed = new Vector2(-0.5f, 0.5f);

    private Animator playerAnim;
    private CinemachineVirtualCamera EscCamera;
    private CinemachineVirtualCamera FollowCamera;

    private RectTransform activeMenu;

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
        Rect uvRect = patternBg.uvRect;
        uvRect.x = uvRect.x + (Time.deltaTime * patternSpeed.x);
        if(Mathf.Abs(uvRect.x) > 100) {
            uvRect.x = Mathf.Abs(uvRect.x) - 100;
        }
        uvRect.y = uvRect.y + (Time.deltaTime * patternSpeed.y);
        if (Mathf.Abs(uvRect.y) > 100) {
            uvRect.y = Mathf.Abs(uvRect.y) - 100;
        }
        patternBg.uvRect = uvRect;

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
        ShowMenu(ESC_SCREEN.MAINMENU, true);
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

    private void ShowMenu(ESC_SCREEN screenToShow, bool skipAnimation = false) {
        RectTransform menuTransform;
        switch (screenToShow) {
            case ESC_SCREEN.MAINMENU:
                menuTransform = mainMenu;
                break;
            case ESC_SCREEN.CHARACTERMENU:
                menuTransform = characterMenu;
                break;
            case ESC_SCREEN.LOSTITEMSMENU:
                menuTransform = lostItemsMenu;
                break;
            case ESC_SCREEN.DATAMENU:
                menuTransform = dataMenu;
                break;
            case ESC_SCREEN.SETTINGSMENU:
                menuTransform = settingsMenu;
                break;
            default:
                return;
        }

        //Hide other menus
        if (menuTransform != mainMenu) {
            HideMenu(mainMenu, skipAnimation);
        }
        if (menuTransform != characterMenu) {
            HideMenu(characterMenu, skipAnimation);
        }
        if (menuTransform != lostItemsMenu) {
            HideMenu(lostItemsMenu, skipAnimation);
        }
        if (menuTransform != dataMenu) {
            HideMenu(dataMenu, skipAnimation);
        }
        if (menuTransform != settingsMenu) {
            HideMenu(settingsMenu, skipAnimation);
        }

        CanvasGroup menuCanvasGroup = menuTransform.GetComponent<CanvasGroup>();
        if (skipAnimation) {
            menuCanvasGroup.alpha = 1;
            menuCanvasGroup.interactable = true;
            menuCanvasGroup.blocksRaycasts = true;

        } else {
            menuCanvasGroup.DOFade(1, 0.2f).SetDelay(0.2f).onComplete = () => {
                menuCanvasGroup.interactable = true;
                menuCanvasGroup.blocksRaycasts = true;
            };
        }
        IScreenInterface screen = menuTransform.GetComponent<IScreenInterface>();
        if(screen != null) {
            screen.OnTransitionIn();
        }

        float backButtonAlpha = screenToShow != ESC_SCREEN.MAINMENU ? 1 : 0;
        float backButtonDelay = screenToShow != ESC_SCREEN.MAINMENU ? 0.2f : 0;
        CanvasGroup buttonCanvasGroup = backButton.GetComponent<CanvasGroup>();
        if (skipAnimation) {
            buttonCanvasGroup.alpha = backButtonAlpha;
            buttonCanvasGroup.interactable = true;
            buttonCanvasGroup.blocksRaycasts = true;
        } else {
            buttonCanvasGroup.DOFade(backButtonAlpha, 0.2f).SetDelay(backButtonDelay).onComplete = () => {
                buttonCanvasGroup.interactable = true;
                buttonCanvasGroup.blocksRaycasts = true;
            };
        }
    }

    private void HideMenu(RectTransform menu, bool skipAnimation = false) {
        CanvasGroup menuCanvasGroup = menu.GetComponent<CanvasGroup>();
        if (skipAnimation) {
            menuCanvasGroup.alpha = 0;
            menuCanvasGroup.interactable = false;
            menuCanvasGroup.blocksRaycasts = false;
        } else {
            menuCanvasGroup.DOFade(0, 0.2f);
            menuCanvasGroup.interactable = false;
            menuCanvasGroup.blocksRaycasts = false;
        }
        IScreenInterface screen = menu.GetComponent<IScreenInterface>();
        if(screen != null) {
            screen.OnTransitionOut();
        }
    }

    public void OnBackButton() {
        ShowMenu(ESC_SCREEN.MAINMENU);
    }

    public void OnCharacterButton() {
        ShowMenu(ESC_SCREEN.CHARACTERMENU);
    }

    public void OnLostItemsButton() {
        ShowMenu(ESC_SCREEN.LOSTITEMSMENU);
    }

    public void OnSaveButton() {
        ShowMenu(ESC_SCREEN.DATAMENU);
    }

    public void OnSettingsButton() {
        ShowMenu(ESC_SCREEN.SETTINGSMENU);
    }

    public void OnExitButton() {
        //TODO: make an alert that will ask the player if they want to close the game or go to main menu
        QuitGame();
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
