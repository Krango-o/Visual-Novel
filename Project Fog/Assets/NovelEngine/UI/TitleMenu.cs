using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    GameObject TitleObject;
    [SerializeField]
    GameObject MainObject;
    [SerializeField]
    GameObject SelectSceneObject;
    [SerializeField]
    GameObject SaveMenuObject;
    [SerializeField]
    TransitionLines TransitionObject;
    [SerializeField]
    ParticleSystem ClickParticles;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Canvas myCanvas = this.GetComponent<Canvas>();
            Vector2 newPos = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, Camera.main, out newPos);
            RectTransform r = ClickParticles.GetComponent<RectTransform>();
            r.localPosition = newPos;
            r.localPosition += new Vector3(0, 0, -200);
            //ClickParticles.Play();
        }
    }

    public void TransitionTitleScreen()
    {
        NovelManager.instance.EventManager.onTransitionMidMovement.AddListener(ShowMainMenuAnim);
        TransitionObject.StartTransition();
    }

    public void StartButton()
    {

    }

    public void ContinueButton()
    {

    }

    public void ShowMainMenuAnim()
    {
        NovelManager.instance.EventManager.onTransitionMidMovement.RemoveListener(ShowMainMenuAnim);
        TitleObject.SetActive(false);
        SelectSceneObject.SetActive(false);
        SaveMenuObject.SetActive(false);
        MainObject.SetActive(true);
        //TransitionObject.EndTransition();
    }

    public void ShowMainMenu()
    {
        TitleObject.SetActive(false);
        SelectSceneObject.SetActive(false);
        SaveMenuObject.SetActive(false);
        MainObject.SetActive(true);
    }

    public void ShowSaveMenu()
    {
        MainObject.SetActive(false);
        SaveMenuObject.GetComponent<SaveMenu>().SaveMode = false;
        SaveMenuObject.SetActive(true);
    }

    public void ShowSceneSelection()
    {
        MainObject.SetActive(false);
        SelectSceneObject.SetActive(true);
    }
}
