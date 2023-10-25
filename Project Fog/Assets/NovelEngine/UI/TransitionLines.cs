using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class TransitionLines : MonoBehaviour
{
    [SerializeField]
    List<Image> panels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTransition()
    {
        gameObject.SetActive(true);
        int count = 0;
        foreach(Image panel in panels)
        {
            count++;
            panel.rectTransform.localPosition = new Vector3(panel.rectTransform.localPosition.x - 300.0f, -2300.0f, panel.rectTransform.localPosition.z);
            Tween t = DOTween.To(() => panel.rectTransform.localPosition, y => panel.rectTransform.localPosition = y, new Vector3(panel.rectTransform.localPosition.x - 150.0f, -150.0f, panel.rectTransform.localPosition.z), 0.5f).SetDelay(Random.Range(0.0f, 0.5f));
            DOTween.To(() => panel.rectTransform.sizeDelta, y => panel.rectTransform.sizeDelta = y, new Vector2(panel.rectTransform.sizeDelta.x + (200 * Random.Range(-2.0f, 2.0f)), panel.rectTransform.sizeDelta.y), 2f);
            if (count == panels.Count)
            {
                t.SetDelay(0.5f);
                t.OnComplete(OnHalfwayTransition);
            }
        }
    }

    public void OnHalfwayTransition()
    {
        NovelManager.instance.EventManager.onTransitionMidMovement.Invoke();
    }
    public void EndTransition()
    {
        int count = 0;
        foreach (Image panel in panels)
        {
            count++;
            Tween t = DOTween.To(() => panel.rectTransform.localPosition, y => panel.rectTransform.localPosition = y, new Vector3(panel.rectTransform.localPosition.x, 2000.0f, panel.rectTransform.localPosition.z), 0.5f).SetDelay(Random.Range(0.5f, 1.0f));
            if (count == panels.Count)
            {
                t.SetDelay(0.0f);
            }
        }
    }
}
