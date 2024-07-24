using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum InteractionType { TALKNEW, TALKOLD, TALKKEY, TALKGIFT, LOOK, RUN }

public class InteractionHint : MonoBehaviour
{
    [SerializeField]
    private Animator interactionAnimation;
    [SerializeField]
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start() {
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain) {
        //Make sprite constantly look at camera
        //interactionAnimation.transform.forward = Camera.main.transform.forward;
    }

    public void SetInteractionType(InteractionType interactionType) {
        interactionAnimation.SetInteger("InteractionType", (int)interactionType);
    }

    public void SetVisible(bool isVisible) {
        if (isVisible) {
            Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
            sprite.enabled = true;
            gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            gameObject.transform.DOScale(1.5f, 0.2f).SetEase(Ease.OutQuad);
        } else {
            Cinemachine.CinemachineCore.CameraUpdatedEvent.RemoveListener(CinemachineUpdate);
            sprite.enabled = false;
        }
    }

}
