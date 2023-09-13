using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum Reaction { SHOCKED }

public class AnimatedSprite : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Reactions reactionContainer;
    float blinkTimer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.InitializeAsync();
        Image spriteImage = gameObject.GetComponent<Image>();
        spriteImage.preserveAspect = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Talking") == false)
        {
            blinkTimer -= Time.deltaTime;
            if(blinkTimer <= 0)
            {
                AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
                animator.Play(state.fullPathHash, -1, 0f);
                blinkTimer = (Random.value * 4.0f) + 3.0f;
            }
        }
    }

    //public void SetData(string pCharacterName, string pSpawnAnim = null)
    //{
    //    AsyncOperationHandle<Animator> animatorHandle = Addressables.LoadAssetAsync<Animator>("Assets/TestingFolder/" + pCharacterName + "/" + pCharacterName + "_Animator.controller");
    //    animatorHandle.Completed += AnimatorLoaded;
    //    spawnAnim = pSpawnAnim;
    //}

    //void AnimatorLoaded(AsyncOperationHandle<Animator> handleToCheck)
    //{
    //    if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        Animator animatorArray = handleToCheck.Result;
    //        animator.runtimeAnimatorController = animatorArray.runtimeAnimatorController;
    //        if(spawnAnim != null)
    //        {
    //            PlayAnimation(spawnAnim);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Issue with Loading Animator: " + handleToCheck.Status);
    //    }
    //}

    public void PlayReaction(string reactionString) {
        reactionContainer.PlayReaction(reactionString);
    }

    public void ToggleTalking(bool isTalking)
    {
        animator.SetBool("Talking", isTalking);
    }

    public void PlayAnimation(string pAnimName)
    {
        bool exists = false;
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if(param.name == pAnimName)
            {
                animator.SetTrigger(pAnimName);
                exists = true;
                break;
            }
        }
        if (!exists)
        {
            Debug.Log("Animation state doesn't exist: " + pAnimName);
        }
    }
}
