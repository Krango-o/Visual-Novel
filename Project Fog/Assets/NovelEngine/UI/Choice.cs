using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class Choice : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI choiceText;
    private CanvasGroup choiceGroup;
    private Button choiceButton;
    private string choiceKey;
    public string ChoiceKey
    {
        get { return choiceKey; }
    }

    private void Start()
    {
        choiceGroup = this.gameObject.GetComponent<CanvasGroup>();
        choiceButton = this.gameObject.GetComponent<Button>();
    }

    public void SetData(string[] choiceData, float delay = 0.0f)
    {
        if(choiceData != null)
        {
            if(choiceButton == null)
            {
                choiceButton = this.gameObject.GetComponent<Button>();
            }
            if(choiceGroup == null)
            {
                choiceGroup = this.gameObject.GetComponent<CanvasGroup>();
            }
            choiceButton.interactable = true;
            choiceText.text = choiceData[0];
            choiceKey = choiceData[1].Trim();
            this.gameObject.SetActive(true);
            this.choiceGroup.alpha = 0;
            this.choiceGroup.DOFade(1, 0.2f).SetDelay(delay);
            this.gameObject.transform.localScale = new Vector3(0.8f, 1.0f, 1.0f);
            this.gameObject.transform.DOScaleX(1.0f, 0.2f).SetDelay(delay);
        }
        else
        {
            choiceText.text = "";
            choiceKey = "";
            this.gameObject.SetActive(false);
        }
    }

    public void HideChoice(float delay = 0.0f)
    {
        choiceButton.interactable = false;
        this.choiceGroup.DOFade(0, 0.2f).SetDelay(delay);
    }
}
