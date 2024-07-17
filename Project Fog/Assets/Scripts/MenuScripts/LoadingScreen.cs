using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Slider loadingBar;
    [SerializeField]
    private CanvasGroup canvasGroup;

    private void Awake() {
        canvasGroup.alpha = 0;
        DontDestroyOnLoad(gameObject);
    }

    public Tween TransitionIn() {
        Tween transitionTween = canvasGroup.DOFade(1, 0.5f);
        return transitionTween;
    }

    public void StartLoading(AsyncOperation loadOperation) {
        StartCoroutine(LoadLevelAsync(loadOperation, TransitionOut));
    }

    private void TransitionOut() {
        canvasGroup.DOFade(0, 0.5f).OnComplete(() => {
            GameObject.Destroy(gameObject);
        });
    }

    IEnumerator LoadLevelAsync(AsyncOperation loadOperation, System.Action callback = null) {
        while (!loadOperation.isDone) {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingBar.value = progressValue;
            yield return null;
        }
        callback?.Invoke();
    }
}
