using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ChoiceButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler {
    [SerializeField]
    private bool flipped = false;

    public void OnPointerEnter(PointerEventData eventData) {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData) {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnSelect(BaseEventData eventData) {
        float direction = flipped ? -1f : 1f;
        this.gameObject.GetComponent<RectTransform>().DOScale(new Vector3(direction * 1.2f, 1.2f), 0.2f);
    }

    public void OnDeselect(BaseEventData data) {
        float direction = flipped ? -1f : 1f;
        this.gameObject.GetComponent<RectTransform>().DOScale(new Vector3(direction, 1.0f), 0.2f);
    }
}
