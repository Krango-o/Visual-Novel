using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LostItemsMenu : Menu {
    [Header("Lost Items Menu")]
    [SerializeField]
    RectTransform itemGrid;
    [SerializeField]
    Image selectedItem;
    [SerializeField]
    TextMeshProUGUI itemText;
    [SerializeField]
    Sprite defaultItemSprite;

    [SerializeField]
    LostItemSO[] lostItemList;

    public override void OnTransitionIn(bool skipAnimation = false) {
        base.OnTransitionIn(skipAnimation);

        selectedItem.DOFade(0, 0);
        itemText.text = "";

        LostItemButton[] lostItems = itemGrid.GetComponentsInChildren<LostItemButton>();
        int index = 0;
        foreach(LostItemButton item in lostItems) {
            if(lostItemList.Length > index && lostItemList[index] != null) {
                // Check what items we've unlocked to show.
                if (GameManager.instance.PlayerDataManager.LostItemsUnlockedIds.Contains(lostItemList[index].name)) {
                    item.SetData(lostItemList[index].itemImage, lostItemList[index].hoverItemImage, GameManager.instance.PlayerDataManager.LostItemsCompletedIds.Contains(lostItemList[index].name));
                } else {
                    item.SetData(defaultItemSprite, defaultItemSprite, false);
                }
                // DEBUG - hardcode show the image
                item.SetData(lostItemList[index].itemImage, lostItemList[index].hoverItemImage, GameManager.instance.PlayerDataManager.LostItemsCompletedIds.Contains(lostItemList[index].name));
            } else {
                item.SetData(defaultItemSprite, defaultItemSprite, false);
            }
            index++;
        }
    }

    public void OnItemClick(Button clickedButton) {
        int index = clickedButton.GetComponent<RectTransform>().GetSiblingIndex();
        if (lostItemList.Length > index) {
            selectedItem.DOFade(1, 0);
            selectedItem.sprite = lostItemList[index] != null ? lostItemList[index].itemImage : defaultItemSprite;
            itemText.text = lostItemList[index] != null ? lostItemList[index].itemDescription : "";
        }
    }
}
