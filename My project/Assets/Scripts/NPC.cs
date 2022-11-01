using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private AnimDialogueManager dialogueManager;
    [SerializeField]
    private string DialogueFileName;
    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private SphereCollider triggerSphere;

    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("NovelCanvas").GetComponent<AnimDialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && canInteract && !GameManager.instance.characterDisabled)
        {
            dialogueManager.LoadDialogue(DialogueFileName);
            GameManager.instance.characterDisabled = true;
        }
        //Make sprite constantly look at camera
        sprite.forward = Camera.main.transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if(pc != null)
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            canInteract = false;
        }
    }
}
