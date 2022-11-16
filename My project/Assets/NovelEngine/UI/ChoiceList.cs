using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceList : MonoBehaviour
{
    [SerializeField]
    protected List<Choice> Choices;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(string[] choice1, string[] choice2, string[] choice3)
    {
        Choices[0].SetData(choice1, 0.4f);
        Choices[1].SetData(choice2, 0.2f);
        Choices[2].SetData(choice3);
    }

    public void OnChoiceClicked(Button choiceButton)
    {
        Choice choice = choiceButton.gameObject.GetComponent<Choice>();
        if (choice != null)
        {
            AnimDialogueManager dm = GameObject.Find("NovelCanvas").GetComponent<AnimDialogueManager>();
            dm.MakeChoice(choice.ChoiceKey);
            for (int i = 0; i < Choices.Count; i++)
            {
                if (Choices[i].isActiveAndEnabled)
                {
                    Choices[i].HideChoice(i * 0.2f);
                }
            }
        }
    }
}
