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
    private Image tabletBg;

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

    private CinemachineVirtualCamera EscCamera;
    private CinemachineVirtualCamera FollowCamera;

    private Menu activeMenu;

    private GameState previousState;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.pauseGameEvent.AddListener(PauseGame);
        GameManager.instance.unpauseGameEvent.AddListener(ResumeGame);
        EscCamera = GameObject.Find("EscCamera").GetComponent<CinemachineVirtualCamera>();
        FollowCamera = GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        contentContainer.anchoredPosition = new Vector2(contentContainer.anchoredPosition.x, GetOffScreenPosition());
        tabletBg.material = new Material(tabletBg.material);
    }

    // Update is called once per frame
    void Update()
    {
        pauseTimer -= Time.deltaTime;
        if (pauseTimer > 0) { return; }
        if (GameManager.instance.CurrentGameState != GameState.POPUP && Input.GetButtonDown("Cancel"))
        {
            pauseTimer = pauseCooldown;
            if(isPaused)
            {
                GameManager.instance.UnpauseGame();
            }
            else if(GameManager.instance.CurrentGameState != GameState.WORLDDIALOGUE)
            {
                GameManager.instance.PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        inputBlocker.DOFade(1, 0.2f);
        contentContainer.localScale = new Vector3(0.6f, 0.6f, 1.0f);
        contentContainer.DOScale(new Vector3(1, 1, 1), 0.4f);
        contentContainer.DOAnchorPosY(0, 0.4f).SetEase(Ease.OutBack);
        if (GameManager.instance.CurrentGameState == GameState.OVERWORLD) 
        {
            GameManager.instance.Player.GetAnimator().SetBool("isPaused" , true);
            //EscCamera.m_Priority = (int)CAMERA_PRIORITY.PAUSE;
            //EscCamera.gameObject.transform.position = FollowCamera.gameObject.transform.position + (FollowCamera.gameObject.transform.right * 4.5f);
            //EscCamera.gameObject.transform.rotation = FollowCamera.gameObject.transform.rotation;
        }
        previousState = GameManager.instance.CurrentGameState;
        GameManager.instance.SetState(GameState.PAUSEMENU);
        activeMenu = mainMenu.GetComponent<Menu>();
        ShowMenu(ESC_SCREEN.MAINMENU, true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        contentContainer.DOAnchorPosY(GetOffScreenPosition(), 0.2f).SetEase(Ease.OutBack);
        inputBlocker.DOFade(0, 0.2f).onComplete = () => {
            canvasGroup.alpha = 0;
            if (previousState == GameState.OVERWORLD) {
                GameManager.instance.Player.GetAnimator().SetBool("isPaused", false);
                //EscCamera.m_Priority = (int)CAMERA_PRIORITY.INACTIVE;
            }
            GameManager.instance.SetState(previousState);
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

        Menu screen = menuTransform.GetComponent<Menu>();
        if(screen != null) {
            screen.OnTransitionIn(skipAnimation);
        }

        if (skipAnimation) {
            tabletBg.materialForRendering.SetColor("_TopColor", screen.GetTopColor());
            tabletBg.materialForRendering.SetColor("_BottomColor", screen.GetBottomColor());
        } else {
            Menu currentActiveMenu = activeMenu;
            DOVirtual.Float(0, 1, 1.2f, v => {
                Color activeTopColor = currentActiveMenu.GetTopColor();
                Color screenTopColor = screen.GetTopColor();
                Color newTopColor = Color.Lerp(activeTopColor, screenTopColor, v);
                Color newBottomColor = Color.Lerp(currentActiveMenu.GetBottomColor(), screen.GetBottomColor(), v);
                tabletBg.materialForRendering.SetColor("_TopColor", newTopColor);
                tabletBg.materialForRendering.SetColor("_BottomColor", newBottomColor);
            });
        }

        activeMenu = screen;

        float backButtonAlpha = screenToShow != ESC_SCREEN.MAINMENU ? 1 : 0;
        float backButtonDelay = screenToShow != ESC_SCREEN.MAINMENU ? 0.4f : 0;
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
        Menu screen = menu.GetComponent<Menu>();
        if(screen != null) {
            screen.OnTransitionOut(skipAnimation);
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
        GeneralPopupData popupData = new GeneralPopupData();
        popupData.confirmCallback = () => {
            QuitGame();
        };
        popupData.title = "Quit Game?";
        popupData.description = "Would you like to close the game?";
        PopupManager.ShowPopup(popupData);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
