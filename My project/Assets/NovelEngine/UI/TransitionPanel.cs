using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class TransitionPanel : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private Material mat;
    private float step = 0.012f;
    private float initialStep = 0.012f;
    [SerializeField]
    private float duration = 1.0f;
    [SerializeField]
    private float driftSpeed = -1.0f;
    private Tween tween;
    [SerializeField]
    private Color color;
    [SerializeField]
    private float delay = 0;
    [SerializeField]
    private UnityEvent midTransitionEvent;

    // Start is called before the first frame update
    void Start()
    {
        image.material = new Material(image.materialForRendering);
        mat = image.materialForRendering;
        mat.SetColor("_Color", color);
        step = mat.GetFloat("_Step");
        initialStep = step;
    }

    private void Update()
    {
        mat.mainTextureOffset = mat.mainTextureOffset + ((new Vector2(driftSpeed, driftSpeed)) * Time.deltaTime);
    }

    public void StartTransition()
    {
        step = initialStep;
        if(tween != null)
        {
            tween.Kill();
        }
        float previousStep = step;
        tween = DOTween.To(() => step, x => step = x, -5f, duration).OnUpdate(() =>
        {
            mat.SetFloat("_Step", step);
            if(previousStep >= -2 && step < -2)
            {
                midTransitionEvent.Invoke();
                mat.SetFloat("_Increment", 2.5f);
                driftSpeed *= -1;
            }
            previousStep = step;
        }).SetDelay(delay);
    }
}
