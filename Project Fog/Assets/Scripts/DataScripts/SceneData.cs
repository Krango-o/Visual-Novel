using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField]
    private AudioClip defaultSong;

    // Can do scene specific start things here
    void Start()
    {
        if(defaultSong != null) {
            GameManager.instance.AudioManager.PlayMusicClip(defaultSong);
        } else {
            GameManager.instance.AudioManager.StopMusic();
        }
    }
}
