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
    private Tween plateTween = null;

    private void Start() {
        plateGroup = gameObject.GetComponent<CanvasGroup>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        NameText = gameObject.GetComponentInChildren<Text>();
    }

    public Tween ShowPlate(string name, bool skipAnimation = false) {
        plateGroup.alpha = 1;
        this.transform.SetAsLastSibling();
        if(plateTween != null) {
            plateTween.Kill();
            plateTween = null;
        }
        if (skipAnimation) {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, endY);
        } else {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, startY);
            plateTween = rectTransform.DOAnchorPosY(endY, 0.4f).SetEase(Ease.OutBack, 1.0f);
        }
        NameText.text = name;
        return plateTween;
    }

    public Tween HidePlate() {
        if (plateTween != null) {
            plateTween.Kill();
            plateTween = null;
        }
        plateTween = plateGroup.DOFade(0, 0.2f);
        return plateTween;
    }
}
