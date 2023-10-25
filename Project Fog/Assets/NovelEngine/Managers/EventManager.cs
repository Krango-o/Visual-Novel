using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent onTransitionMidMovement = new UnityEvent();
    public void TransitionMidMovement() {
        if(onTransitionMidMovement != null) {
            onTransitionMidMovement.Invoke();
        }
    }
    public UnityEvent onPause = new UnityEvent();
    public void Pause() {
        if(onPause != null) {
            onPause.Invoke();
        }
    }
    public UnityEvent onUnpause = new UnityEvent();
    public void Unpause() {
        if(onUnpause != null) {
            onUnpause.Invoke();
        }
    }
}
