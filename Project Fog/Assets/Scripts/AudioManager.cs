using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource soundFXPrefab;
    [SerializeField]
    private AudioSource musicPrefab;
    [SerializeField]
    private AudioMixer audioMixer;

    private AudioSource musicSource = null;

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume = 1f) {
        AudioSource audioSource = Instantiate(soundFXPrefab, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength + 0.1f);
    }

    public void PlayMusicClip(AudioClip audioClip, float fadeDuration = 1f, float volume = 1f) {
        if(musicSource == null) {
            musicSource = Instantiate(musicPrefab, Vector3.zero, Quaternion.identity, GameManager.instance.gameObject.transform);
            musicSource.volume = 0;
        }
        if(musicSource.isPlaying && musicSource.clip == audioClip) { return; }

        if (musicSource.isPlaying) {
            musicSource.DOFade(0, fadeDuration).OnComplete( () => {
                musicSource.Stop();
                musicSource.clip = audioClip;
                musicSource.Play();
                musicSource.DOFade(volume, fadeDuration);
            });
        } else {
            musicSource.clip = audioClip;
            musicSource.Play();
            musicSource.DOFade(volume, fadeDuration);
        }
    }

    public void StopMusic(float fadeDuration = 1f) {
        if (musicSource != null) {
            musicSource.DOFade(0, fadeDuration).OnComplete(() => {
                musicSource.Stop();
            });
        }
    }

    public void SetMasterVolume(float level) {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume(float level) {
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level) {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
    }
}
