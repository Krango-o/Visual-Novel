using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostItemInteractable : Interactable
{
    [Header("Lost Item")]
    [SerializeField]
    LostItemSO lostItemSO;

    public override void Interact() {
        base.Interact();
    }
}
