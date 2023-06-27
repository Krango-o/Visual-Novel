using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    protected Text BoxText;
    [SerializeField]
    protected Text NameText;
    [SerializeField]
    protected Image Box;
    [SerializeField]
    protected Image NamePlate;
    [SerializeField]
    protected float textSpeed = 0.025f;

    public float timer = 0;
    protected int currentCharacter = 0;
    protected DialogueLine currentLine;
    protected bool isExclaimBox;
    private Vector3 originalBoxPosition;
    private Tween plateTween = null;
    private RectTransform boxRect;
    private bool skip = false;

    // Start is called before the first frame update
    void Start()
    {
        boxRect = this.GetComponent<RectTransform>();
        originalBoxPosition = boxRect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool TextAnimation(float timeScale)
    {
        if (currentCharacter < currentLine.Text.Length)
        {
            timer += Time.deltaTime * timeScale;
            if (timer >= textSpeed)
            {
                BoxText.text = currentLine.Text.Substring(0, currentCharacter + 1);
                timer = 0;
                currentCharacter++;
                if (currentCharacter >= currentLine.Text.Length)
                {
                    //end of line
                    return true;
                }
            }
        }
        return false;
    }

    public void ResetBox()
    {
        BoxText.text = "";
        currentCharacter = 0;
        timer = 0;
        NamePlate.rectTransform.anchoredPosition = new Vector2(0, -NamePlate.rectTransform.sizeDelta.y);
    }

    public void ResetText()
    {
        BoxText.text = "";
    }

    public void SetLine(DialogueLine newLine)
    {
        currentLine = newLine;
    }

    public void SetCompleteLine(DialogueLine newLine)
    {
        BoxText.text = newLine.Text;
        currentCharacter = newLine.Text.Length;
        currentLine = newLine;
        if (currentLine.Character != "")
        {
            NamePlate.rectTransform.anchoredPosition = new Vector2(NamePlate.rectTransform.anchoredPosition.x, 0);
            Color plateColor;
            ColorUtility.TryParseHtmlString(CharacterData.CharacterPlateColor(currentLine.Character), out plateColor);
            NamePlate.GetComponent<Image>().color = plateColor;
            NameText.text = currentLine.Character;
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(NamePlate.rectTransform);
        }
    }

    public bool isLineComplete()
    {
        return currentCharacter != currentLine.Text.Length;
    }

    public void NextLine(DialogueLine newLine)
    {
        currentLine = newLine;
        if ((NameText.text != newLine.Character) && newLine.Character != "")
        {
            if (NameText.text == "")
            {
                //character from narrator, tween up from behind
                plateTween = NamePlate.rectTransform.DOAnchorPosY(0, 0.3f, true);
                plateTween.onComplete = () =>
                {
                    if (!GameManager.instance.DialogueManager.MoveOn)
                    {
                        currentCharacter = 0;
                    }
                    timer = 0;
                    GameManager.instance.DialogueManager.Active = true;
                };
                NameText.text = newLine.Character;
                Canvas.ForceUpdateCanvases();
                LayoutRebuilder.ForceRebuildLayoutImmediate(NamePlate.rectTransform);
                Color plateColor;
                ColorUtility.TryParseHtmlString(CharacterData.CharacterPlateColor(newLine.Character), out plateColor);
                NamePlate.GetComponent<Image>().color = plateColor;
            }
            else
            {
                //new character speaking, tween across and lift new plate up
                NamePlate.rectTransform.DOAnchorPosX(100, 0.2f, true);
                NameText.DOFade(0, 0.2f);
                NamePlate.DOFade(0, 0.2f).OnComplete(() => {
                    NamePlate.rectTransform.anchoredPosition = new Vector2(0, -NamePlate.rectTransform.sizeDelta.y);
                    NamePlate.DOFade(1, 0.01f);
                    NameText.DOFade(1, 0.01f);
                    plateTween = NamePlate.rectTransform.DOAnchorPosY(0, 0.3f);
                    plateTween.onComplete = () =>
                    {
                        if (!GameManager.instance.DialogueManager.MoveOn)
                        {
                            currentCharacter = 0;
                        }
                        timer = 0;
                        if (!skip)
                        {
                            GameManager.instance.DialogueManager.Active = true;
                        }
                        skip = false;
                    };
                    NameText.text = newLine.Character;
                    Canvas.ForceUpdateCanvases();
                    LayoutRebuilder.ForceRebuildLayoutImmediate(NamePlate.rectTransform);
                    Color plateColor;
                    ColorUtility.TryParseHtmlString(CharacterData.CharacterPlateColor(newLine.Character), out plateColor);
                    NamePlate.GetComponent<Image>().color = plateColor;
                });
            }
        }
        else if (newLine.Character == "")
        {
            //narrator, move nameplate underneath text box
            plateTween = NamePlate.rectTransform.DOAnchorPosY(-NamePlate.rectTransform.sizeDelta.y, 0.3f, true);
            plateTween.onComplete = () =>
            {
                if (!GameManager.instance.DialogueManager.MoveOn)
                {
                    currentCharacter = 0;
                }
                timer = 0;
                GameManager.instance.DialogueManager.Active = true;
                NameText.text = "";
            };
        }
        else
        {
            if (!GameManager.instance.DialogueManager.MoveOn)
            {
                currentCharacter = 0;
            }
            timer = 0;
            GameManager.instance.DialogueManager.Active = true;
        }
    }

    public void SkipAnimation()
    {
        BoxText.text = currentLine.Text;
        currentCharacter = currentLine.Text.Length;
        plateTween?.Complete();
        skip = true;
    }

    public void SetTextBoxImage(bool isExclaimBox)
    {
        //TODO: Implement different text boxes 
        if(isExclaimBox != this.isExclaimBox)
        {
            if (isExclaimBox)
            {
                Debug.Log("ExclaimTextBox");
            }
            else
            {
                Debug.Log("NormalTextBox");
            }
        }
        this.isExclaimBox = isExclaimBox;
    }

    public Tween FadeBoxIn()
    {
        boxRect.anchoredPosition = originalBoxPosition - new Vector3(0, 300, 0);
        this.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        return boxRect.DOAnchorPosY(originalBoxPosition.y, 0.5f).SetEase(Ease.OutBack);
    }

    public Tween FadeBoxOut()
    {
        Vector3 fadePos = originalBoxPosition - new Vector3(0, 50, 0);
        this.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        return boxRect.DOAnchorPosY(fadePos.y, 0.3f);
    }
}
