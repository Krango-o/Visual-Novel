using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsItem : MonoBehaviour
{
    public void OnMasterVolumeChanged(float value) {
        GameManager.instance.AudioManager.SetMasterVolume(value);
    }

    public void OnMusicVolumeChanged(float value) {
        GameManager.instance.AudioManager.SetMusicVolume(value);
    }

    public void OnSFXVolumeChanged(float value) {
        GameManager.instance.AudioManager.SetSoundFXVolume(value);
    }
}
