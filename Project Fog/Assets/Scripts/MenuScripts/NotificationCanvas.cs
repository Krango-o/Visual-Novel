using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NotificationCanvas : MonoBehaviour
{
    [SerializeField]
    RectTransform notificationHolder;
    [SerializeField]
    Image notificationIcon;
    [SerializeField]
    TMPro.TextMeshProUGUI notificationTitle;
    [SerializeField]
    TMPro.TextMeshProUGUI notificationDescription;

    private Queue<NotificationData> notificationQueue;
    private bool notificationShowing = false;
    private float notificationWidth = 0;
    private float duration = 4f;

    // Start is called before the first frame update
    void Start(){
        GameManager.instance.lostItemUnlocked.AddListener(OnLostItemUnlocked);
        notificationWidth = notificationHolder.rect.width;
        notificationQueue = new Queue<NotificationData>();
    }

    private void Update() {
        if(notificationQueue.Count > 0 && !notificationShowing) {
            ShowNotification(notificationQueue.Dequeue());
        }
    }

    private void OnDestroy() {
        GameManager.instance.lostItemUnlocked.RemoveListener(OnLostItemUnlocked);
    }

    private void ShowNotification(NotificationData data) {
        notificationShowing = true;

        notificationTitle.text = data.title;
        notificationDescription.text = data.description;
        notificationIcon.enabled = data.imageSprite != null;
        if(data.imageSprite != null) {
            notificationIcon.sprite = data.imageSprite;
        }

        notificationHolder.DOAnchorPosX(-notificationWidth, 0.4f).SetEase(Ease.OutBack);
        notificationHolder.DOAnchorPosX(0, 0.2f).SetDelay(duration).SetEase(Ease.OutQuad).onComplete = () => {
            notificationShowing = false;
        };
    }

    public void OnLostItemUnlocked(LostItemSO lostItem) {
        notificationQueue.Enqueue(new NotificationData("You found a lost item!", "Press [ESC] to view.", lostItem.selectedItemImage));
    }
}

public class NotificationData {
    public Sprite imageSprite;
    public string title;
    public string description;

    public NotificationData(string title, string description = "", Sprite imageSprite = null) {
        this.title = title;
        this.description = description;
        this.imageSprite = imageSprite;
    }
}
