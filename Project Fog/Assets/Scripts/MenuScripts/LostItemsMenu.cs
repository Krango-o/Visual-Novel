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

        Image[] lostItems = itemGrid.GetComponentsInChildren<Image>();
        int index = 0;
        foreach(Image item in lostItems) {
            if(lostItemList.Length > index) {
                item.sprite = lostItemList[index] != null ? lostItemList[index].itemImage : defaultItemSprite;
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
