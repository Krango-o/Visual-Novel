using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LostItemSO", menuName = "ScriptableObjects/LostItemSO", order = 1)]
public class LostItemSO : ScriptableObject {

    [Header("Item Images")]
    public Sprite itemImage;
    public Sprite selectedItemImage;

    [Header("Description")]
    [TextArea(5, 20)]
    public string itemDescription;
}
