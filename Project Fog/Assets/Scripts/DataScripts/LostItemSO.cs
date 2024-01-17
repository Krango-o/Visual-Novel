using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LostItemSO", menuName = "ScriptableObjects/LostItemSO", order = 1)]
public class LostItemSO : ScriptableObject
{
    [field: SerializeField] public string Id { get; private set; }

    [Header("Item Images")]
    public Sprite itemImage;
    public Sprite hoverItemImage;
    public Sprite selectedItemImage;

    [Header("Description")]
    [TextArea(5, 20)]
    public string itemDescription;

    private void OnValidate()
    {
#if UNITY_EDITOR
        Id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
