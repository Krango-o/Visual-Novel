using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTasty : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private AudioSource HoverSource;
    [SerializeField]
    private AudioSource ClickSource;
    [SerializeField]
    private AudioSource ReleaseSource;
    [SerializeField]
    private Image ButtonImage;
    [SerializeField]
    private Sprite IdleSprite;
    [SerializeField]
    private Sprite HoverSprite;
    [SerializeField]
    private Sprite PressSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!button.interactable) { return; }
        HoverSource.Play();
        ButtonImage.sprite = HoverSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!button.interactable) { return; }
        ClickSource.Play();
        ButtonImage.sprite = PressSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!button.interactable) { return; }
        foreach (GameObject obj in eventData.hovered)
        {
            if(obj == this.gameObject)
            {
                ReleaseSource.Play();
                ButtonImage.sprite = HoverSprite;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!button.interactable) { return; }
        ButtonImage.sprite = IdleSprite;
    }
}
