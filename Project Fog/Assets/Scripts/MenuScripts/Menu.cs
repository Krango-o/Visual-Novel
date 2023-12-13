using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour {
    [SerializeField]
    private Color TopColor = Color.blue;
    [SerializeField]
    private Color BottomColor = Color.blue;
    [SerializeField]
    private RawImage patternBg;
    private CanvasGroup patternCanvasGroup;
    [SerializeField]
    private CanvasGroup canvasGroup;

    private Vector2 patternSpeed = new Vector2(-0.5f, 0.5f);
    private float patternSpeedMultiplier = 1;
    private float maxSpeed = 10;

    private float fadeDuration = 0.2f;

    public virtual void Start() {
        patternCanvasGroup = patternBg.GetComponent<CanvasGroup>();
        patternCanvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update() {
        Rect uvRect = patternBg.uvRect;
        uvRect.x = uvRect.x + (Time.deltaTime * patternSpeed.x * patternSpeedMultiplier);
        if (Mathf.Abs(uvRect.x) > 100) {
            uvRect.x = Mathf.Abs(uvRect.x) - 100;
        }
        uvRect.y = uvRect.y + (Time.deltaTime * patternSpeed.y * patternSpeedMultiplier);
        if (Mathf.Abs(uvRect.y) > 100) {
            uvRect.y = Mathf.Abs(uvRect.y) - 100;
        }
        patternBg.uvRect = uvRect;
    }

    public virtual void OnTransitionIn(bool skipAnimation = false) {
        if (skipAnimation) {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            patternCanvasGroup.alpha = 1;

        } else {
            patternCanvasGroup.DOFade(1, fadeDuration * 2).SetEase(Ease.InQuad).SetDelay(fadeDuration);
            DOVirtual.Float(1, maxSpeed, fadeDuration * 3f, v => patternSpeedMultiplier = v).SetEase(Ease.InQuad).onComplete = () => {
                DOVirtual.Float(maxSpeed, 1, fadeDuration * 3f, v => patternSpeedMultiplier = v).SetEase(Ease.OutQuad);
            };
            canvasGroup.DOFade(1, fadeDuration).SetDelay(fadeDuration*3).onComplete = () => {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            };
        }
    }

    public virtual void OnTransitionOut(bool skipAnimation = false) {
        if (skipAnimation) {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            patternCanvasGroup.alpha = 0;
        } else {
            patternCanvasGroup.DOFade(0, fadeDuration * 2).SetEase(Ease.InQuad).SetDelay(fadeDuration);
            DOVirtual.Float(1, maxSpeed, fadeDuration * 3f, v => patternSpeedMultiplier = v).SetEase(Ease.InQuad).onComplete = () => {
                DOVirtual.Float(maxSpeed, 1, fadeDuration * 3f, v => patternSpeedMultiplier = v).SetEase(Ease.OutQuad);
            };
            canvasGroup.DOFade(0, fadeDuration);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public Color GetTopColor() {
        return TopColor;
    }

    public Color GetBottomColor() {
        return BottomColor;
    }
}
