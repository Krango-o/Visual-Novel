using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LostItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    [SerializeField]
    private Image checkmark;
    private Button button;

    private Sprite defaultImage;
    private Sprite hoverImage;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    public void SetData(Sprite itemImage, Sprite hoverImage, bool completed) {
        defaultImage = itemImage;
        this.hoverImage = hoverImage;
        button.image.sprite = itemImage;

        checkmark.gameObject.SetActive(completed);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        button.image.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData) {
        button.image.sprite = defaultImage;
    }
}
