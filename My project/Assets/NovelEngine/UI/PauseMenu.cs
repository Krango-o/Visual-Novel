using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private Button HistoryButton;
    [SerializeField]
    private HistoryMenu HistoryMenu;

    private EventSystem eventSystem;
    private Button previousButton;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        previousButton = HistoryButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.characterDisabled) { return; }
    }

    public void OnPointerEnter(PointerEventData e)
    {
        eventSystem.SetSelectedGameObject(null);
    }

    public void OnBackButton()
    {
        eventSystem.SetSelectedGameObject(previousButton.gameObject);
    }

    public void OnHistoryButtonClicked(Button button)
    {
        previousButton = button;
        HistoryMenu.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
    }

    public void OnFastForwardButtonClicked()
    {

    }
}
