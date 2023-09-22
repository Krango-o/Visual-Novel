using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NamePlate : MonoBehaviour
{
    private Text NameText;
    private CanvasGroup plateGroup;
    private RectTransform rectTransform;
    private float endY = -13f;
    private float startY = -120f;

    private void Start() {
        plateGroup = gameObject.GetComponent<CanvasGroup>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        NameText = gameObject.GetComponentInChildren<Text>();
    }

    public void ShowPlate(string name, bool skipAnimation) {
        plateGroup.alpha = 1;
        if (skipAnimation) {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, endY);
        } else {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, startY);
            rectTransform.DOAnchorPosY(endY, 0.4f);
        }
        NameText.text = name;
    }

    public void HidePlate() {
        plateGroup.DOFade(0, 0.2f);
    }
}
