using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Febucci.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI dialogueText;
    [SerializeField]
    protected TypewriterByCharacter typewriter;
    [SerializeField]
    protected Image boxImage;
    [SerializeField]
    protected NamePlate[] namePlates;
    [SerializeField]
    protected float textSpeed = 0.025f;

    public float timer = 0;
    protected int currentCharacter = 0;
    protected int currentPlate = 0;
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
                //dialogueText.text = currentLine.Text.Substring(0, currentCharacter + 1);
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
        dialogueText.text = "";
        currentCharacter = 0;
        timer = 0;
        currentPlate = 0;
        for (int i = 0; i < namePlates.Length; i++) {
            namePlates[i].HidePlate();
        }
    }

    public void ResetText()
    {
        dialogueText.text = "";
        currentCharacter = 0;
        timer = 0;
    }

    public void SetLine(DialogueLine newLine)
    {
        currentLine = newLine;
    }

    public void SetCompleteLine(DialogueLine newLine)
    {
        dialogueText.text = newLine.Text;
        typewriter.SkipTypewriter();
        currentCharacter = newLine.Text.Length;
        currentLine = newLine;
        if (currentLine.Character != "")
        {
            namePlates[currentPlate].ShowPlate(currentLine.Character, true);
        }
    }

    public bool isLineComplete()
    {
        return currentCharacter != currentLine.Text.Length;
    }

    public void NextLine(DialogueLine newLine)
    {
        string currentName = currentLine is not null ? currentLine.Character : "";
        if ((currentName != newLine.Character) && newLine.Character != "")
        {
            if (currentName == "")
            {
                //character from narrator
                nameTween = namePlates[currentPlate].ShowPlate(newLine.Character).OnComplete(() => {
                    if (!GameManager.instance.DialogueManager.MoveOn) {
                        currentCharacter = 0;
                    }
                    timer = 0;
                    GameManager.instance.DialogueManager.Active = true;
                });
                IteratePlateCount();
            }
            else
            {
                nameTween = namePlates[currentPlate].ShowPlate(newLine.Character).OnComplete(() => {
                    if (!GameManager.instance.DialogueManager.MoveOn) {
                        currentCharacter = 0;
                    }
                    timer = 0;
                    GameManager.instance.DialogueManager.Active = true;
                });
                IteratePlateCount();
            }
        }
        else if (newLine.Character == "")
        {
            //narrator, move nameplate underneath text box
            nameTween = namePlates[0].HidePlate().OnComplete(() => {
                if (!GameManager.instance.DialogueManager.MoveOn) {
                    currentCharacter = 0;
                }
                timer = 0;
                GameManager.instance.DialogueManager.Active = true;
            });
            for (int i = 1; i < namePlates.Length; i++) {
                namePlates[i].HidePlate();
            }
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
        typewriter.ShowText(currentLine.Text);
    }

    public void SkipAnimation()
    {
        //dialogueText.text = currentLine.Text;
        typewriter.SkipTypewriter();
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

    private void IteratePlateCount() {
        currentPlate++;
        if(currentPlate >= namePlates.Length) {
            currentPlate = 0;
        }
        int plateToHide = currentPlate;
        if (plateToHide >= namePlates.Length) {
            plateToHide = 0;
        }
        namePlates[plateToHide].HidePlate();
    }
}
