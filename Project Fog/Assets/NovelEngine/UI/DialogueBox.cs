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
    protected Image Box;
    [SerializeField]
    protected NamePlate[] NamePlates;
    [SerializeField]
    protected float textSpeed = 0.025f;

    public float timer = 0;
    protected int currentCharacter = 0;
    protected DialogueLine currentLine;
    protected bool isExclaimBox;
    private Vector3 originalBoxPosition;
    private Tween nameTween = null;
    private RectTransform boxRect;

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
    }

    public void ResetText()
    {
        BoxText.text = "";
        currentCharacter = 0;
        timer = 0;
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
            NameText.text = currentLine.Character;
        }
    }

    public bool isLineComplete()
    {
        return currentCharacter != currentLine.Text.Length;
    }

    public void NextLine(DialogueLine newLine)
    {
        string currentName = currentLine != null ? currentLine.Character : "";
        if ((currentName != newLine.Character) && newLine.Character != "")
        {
            if (currentName == "")
            {
                //character from narrator
                if (!GameManager.instance.DialogueManager.MoveOn) {
                    currentCharacter = 0;
                }
                timer = 0;
                GameManager.instance.DialogueManager.Active = true;
                NameText.text = newLine.Character;
            }
            else
            {
                //new character speaking, tween across and lift new plate up
                nameTween = NameText.DOFade(0, 0.2f).OnComplete(() => {
                    NameText.DOFade(1, 0.2f);
                    if (!GameManager.instance.DialogueManager.MoveOn) {
                        currentCharacter = 0;
                    }
                    timer = 0;
                    GameManager.instance.DialogueManager.Active = true;
                    NameText.text = newLine.Character;
                });
            }
        }
        else if (newLine.Character == "")
        {
            //narrator, move nameplate underneath text box
            nameTween = NameText.DOFade(0, 0.2f).OnComplete(() => {
                if (!GameManager.instance.DialogueManager.MoveOn)
                {
                    currentCharacter = 0;
                }
                timer = 0;
                GameManager.instance.DialogueManager.Active = true;
                NameText.text = "";
            });
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
        currentLine = newLine;
    }

    public void SkipAnimation()
    {
        BoxText.text = currentLine.Text;
        currentCharacter = currentLine.Text.Length;
        nameTween?.Complete();
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
