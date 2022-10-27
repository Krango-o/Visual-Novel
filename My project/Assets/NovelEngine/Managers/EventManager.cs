using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent TransitionMidMovement = new UnityEvent();
    public UnityEvent Pause = new UnityEvent();
    public UnityEvent Unpause = new UnityEvent();
}
