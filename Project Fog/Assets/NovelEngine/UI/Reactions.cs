using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactions : MonoBehaviour
{
    [SerializeField]
    private Animator shockedAnim;

    private void Start() {
        shockedAnim.gameObject.SetActive(false);
    }

    public void PlayReaction(string reaction) {
        switch (reaction) {
            case "Shocked":
                // Turning the game object off and on resets the animation
                shockedAnim.gameObject.SetActive(false);
                shockedAnim.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("The reaction '" + reaction + "' is not an implemented reaction.");
                break;
        }
    }
}
