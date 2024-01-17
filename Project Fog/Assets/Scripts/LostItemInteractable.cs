using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostItemInteractable : Interactable
{
    [Header("Lost Item")]
    [SerializeField]
    private LostItemSO lostItemSO;
    [SerializeField]
    private Transform spriteHolder;
    [SerializeField]
    private SpriteRenderer itemSprite;

    private bool pickedUp = false;

    private void OnValidate()
    {
        if(lostItemSO != null && itemSprite != null)
        {
            itemSprite.sprite = lostItemSO.selectedItemImage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain)
    {
        //Make sprite constantly look at camera
        spriteHolder.forward = Camera.main.transform.forward;
    }

    private void OnDestroy()
    {
        GameManager.instance.RemoveInteractable(this.gameObject);
    }

    public override void Interact() {
        base.Interact();
        if (!pickedUp)
        {
            GameManager.instance.UnlockLostItem(lostItemSO.Id);
            pickedUp = true;
            Destroy(gameObject);
        }
    }
}
